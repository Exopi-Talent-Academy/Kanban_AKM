import type { BoardDto } from "../types/board";

export const mockBoard: BoardDto = {
    id: "local-board",
    name: "Frontend Design Board",
    columns: [
        {
            id: "todo",
            title: "To do",
            position: 0,
            cards: [
                {
                    id: "todo-1",
                    title: "Create the board layout",
                    description: "Design a board UI that actually works",
                    priority: 0,
                },
                {
                    id: "todo-2",
                    title: "Do some cool styling stuff",
                    description: "Just add stuff! Try it!",
                    priority: 1,
                },
            ],
        },
        {
            id: "in-progress",
            title: "In progress",
            position: 1,
            cards: [
                {
                    id: "progress-1",
                    title: "Create a mock board",
                    description: "Creating this very mock board that we are currently looking at.",
                    priority: 0,
                },
            ],
        },
        {
            id: "done",
            title: "Done",
            position: 2,
            cards: [
                {
                    id: "done-1",
                    title: "Set up Vite",
                    description: "Don't lose hope, you did do this one thing.",
                    priority: 0,
                },
            ],
        },
    ],
};