// MHM: These are the JSON responses expected from the API.
export type TaskDto = {
    id: string;
    title: string;
    description: string | null;
    priority: number;
};

export type ColumnDto = {
    id: string;
    title: string;
    position: number;
    cards: TaskDto[];
};

export type BoardDto = {
    id: string;
    name: string;
    columns: ColumnDto[];
};