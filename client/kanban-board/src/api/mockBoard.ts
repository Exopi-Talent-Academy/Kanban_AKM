import type { BoardDto } from "../types/board";

export const mockBoard: BoardDto = {
    id: "local-board",
    name: "Frontend Design Board",
    columns: [
        {
            id: "todo",
            name: "To do",
            position: 0,
            cards: [
                {
                    id: "todo-1",
                    title: "Create the board layout",
                    description: "Design a board UI that actually works",
                    position: 0,
                },
                {
                    id: "todo-2",
                    title: "Do some cool styling stuff",
                    description: "Just add stuff! Try it!",
                    position: 1,
                },
            ],
        },
        {
            id: "in-progress",
            name: "In progress",
            position: 1,
            cards: [
                {
                    id: "progress-1",
                    title: "Create a mock board",
                    description: "Creating this very mock board that we are currently looking at.",
                    position: 0,
                },
            ],
        },
        {
            id: "done",
            name: "Done",
            position: 2,
            cards: [
                {
                    id: "done-1",
                    title: "Set up Vite",
                    description: "Don't lose hope, you did do this one thing.",
                    position: 0,
                },
            ],
        },
    ],
};