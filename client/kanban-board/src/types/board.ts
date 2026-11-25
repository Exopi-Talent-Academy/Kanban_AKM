// MHM: These are the JSON responses expected from the API.
export type CardDto = {
    id: string;
    title: string;
    description: string | null;
    position: number;
};

export type ColumnDto = {
    id: string;
    name: string;
    position: number;
    cards: CardDto[];
};

export type BoardDto = {
    id: string;
    name: string;
    columns: ColumnDto[];
};