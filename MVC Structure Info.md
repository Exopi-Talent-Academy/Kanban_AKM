# Kanban_AKM: MVC and React Structure

This guide describes where to put code as the Kanban board grows. The repository currently contains a .NET 10 ASP.NET Core MVC starter project at the repository root. The database, API, and React application described below are planned structure; they have not been added yet.

## Architecture at a glance

Use ASP.NET Core as the backend and React as the browser UI:

1. React renders the board and handles interactive UI state.
2. React calls ASP.NET Core API endpoints using HTTP and JSON.
3. API controllers validate requests and pass work to application services.
4. Services apply the Kanban rules and use Entity Framework Core (EF Core) to read or save data.
5. EF Core maps backend entities to the chosen database.

This is still a useful MVC separation of responsibilities, but React replaces Razor Views for the main user interface. Keep Razor views only if the app also needs server-rendered pages, such as a simple landing page or error page. Do not put React components in the `Views` folder.

## Suggested Solution Explorer layout

As the app grows, organize the repository like this:

```text
Kanban_AKM/
├── Kanban_AKM.sln
├── src/
│   └── Kanban_AKM.Web/
│       ├── Kanban_AKM.Web.csproj
│       ├── Controllers/
│       │   ├── Api/
│       │   │   ├── BoardsController.cs
│       │   │   ├── ColumnsController.cs
│       │   │   └── CardsController.cs
│       │   └── HomeController.cs             # Only for Razor pages, if needed
│       ├── Data/
│       │   ├── KanbanDbContext.cs
│       │   ├── Configurations/
│       │   └── Migrations/
│       ├── DTOs/
│       │   ├── Boards/
│       │   ├── Columns/
│       │   └── Cards/
│       ├── Models/
│       │   └── Entities/
│       ├── Services/
│       ├── Views/                             # Optional; server-rendered Razor only
│       ├── wwwroot/                           # Static files / built frontend, if hosted here
│       ├── appsettings.json
│       └── Program.cs
├── client/
│   └── kanban-board/
│       ├── package.json
│       ├── index.html
│       └── src/
│           ├── api/
│           ├── components/
│           ├── features/
│           │   ├── boards/
│           │   ├── columns/
│           │   └── cards/
│           ├── hooks/
│           ├── types/
│           └── App.tsx
└── tests/
    └── Kanban_AKM.Tests/
```

The current project is at the repository root, not under `src/`. There is no need to move it just to start adding code. The layout above is a good target when you are ready to create a solution file and separate the backend, frontend, and tests. In Visual Studio, add the backend project to the solution and use a solution folder or open the repository folder to work with the React app; React is managed with Node.js tooling rather than as a C# project.

## Backend: where code belongs

| Location | Responsibility | Example |
|---|---|---|
| `Controllers/Api/` | HTTP boundary: routes, request binding, status codes, and calling services. Keep business rules and database queries out of controllers. | `CardsController` exposes endpoints for listing, creating, and moving cards. |
| `DTOs/` | Request and response shapes used by the API. These are the JSON contract with React, not database entities. | `MoveCardRequest` contains the destination column and position. |
| `Models/Entities/` | Persistent domain data and relationships. | `Board`, `BoardColumn`, `Card`. |
| `Data/` | EF Core `DbContext`, entity configuration, and generated migrations. | `KanbanDbContext` defines the board, column, and card sets. |
| `Services/` | Application operations and Kanban rules, called by controllers. | `CardService.MoveCardAsync` checks the move and updates ordering. |
| `Views/` | Optional Razor `.cshtml` pages rendered by ASP.NET Core. Not for React `.tsx` files. | Existing `Views/Home/Index.cshtml` is a server-rendered page. |
| `wwwroot/` | Public static files served by ASP.NET Core. Use for images, CSS, or the built React app if the backend hosts it. | Production frontend assets after a configured build. |
| `Program.cs` | Registers MVC/API services, the database context, and application services; configures middleware and routes. | Register `KanbanDbContext` and `CardService` with dependency injection. |
| `appsettings*.json` | Non-secret configuration, such as logging and a local database connection string placeholder. | Put real passwords and production secrets in user secrets or environment variables, never in committed files. |

For a Kanban board, a typical starting data model is:

- A `Board` has many `BoardColumn` records.
- A `BoardColumn` belongs to a board and has many `Card` records.
- A `Card` belongs to a column and has a position/order value, title, description, and optional due date or assignee.

Agree on how card ordering works and enforce it in one service operation when moving a card. Use EF Core relationships and database constraints to protect data integrity. Keep API DTOs separate from EF entities so database changes do not accidentally change the public API.

## Frontend: where React code belongs

Keep React source in `client/kanban-board/src/`, separate from C# backend code:

- `features/boards`, `features/columns`, and `features/cards/`: feature-specific UI and state.
- `components/`: reusable UI that is not tied to one feature.
- `api/`: HTTP client functions for the backend, such as `getBoard` or `moveCard`.
- `types/`: frontend TypeScript types matching the API DTOs.
- `hooks/`: reusable React hooks.
- `App.tsx`: top-level app composition and routing.

React should call the backend API; it should not connect directly to the database or reference EF Core entities. Keep the frontend's API calls in `api/` rather than scattering `fetch` calls through components.

## Request flow example

For dragging a card into another column:

1. A React card/board component calls `api/cards.ts` with the card ID, destination column ID, and desired position.
2. `CardsController` receives the request at an endpoint such as `PUT /api/cards/{id}/move` and returns an appropriate HTTP status.
3. `CardService` checks that the destination is valid and applies the move and ordering rules.
4. `KanbanDbContext` saves the changes; use a transaction if the move requires multiple related updates.
5. The controller returns a response DTO, and React updates or refreshes the board.

Use asynchronous database calls, validate incoming data, and return clear error responses. Add authorization checks before exposing boards to multiple users.

## Database setup and migrations

Use EF Core with a database provider chosen by the team. Keep provider registration and connection configuration in the backend. Create migrations from the backend project and review generated migration files before applying them. Do not edit generated migration history by hand to represent ordinary schema changes; create a new migration instead.

When the database provider and hosting approach are selected, document the exact EF Core package and migration commands for that setup. Do not commit credentials or production connection strings.

## Tests

Add backend tests under `tests/Kanban_AKM.Tests/`. Test service rules such as moving a card and preserving order, controller/API behavior where useful, and database behavior with an appropriately isolated test database. Keep tests independent of production data. Frontend component and API-client tests can live beside their corresponding React source files or in a frontend test folder.

## Practical rules

- Controllers handle HTTP; services handle use cases and business rules; `Data` handles persistence.
- React renders the interactive UI; Razor `Views` are optional and serve a different rendering approach.
- Use DTOs at the API boundary and entities at the persistence/domain boundary.
- Register dependencies centrally in `Program.cs` and use constructor injection.
- Keep each file focused and group code by feature or responsibility as the application grows.