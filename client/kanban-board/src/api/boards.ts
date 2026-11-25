import { apiRequest } from "./httpClient";
import type { BoardDto } from "../types/board";

export function getBoard(boardId: string): Promise<BoardDto> {
    return apiRequest<BoardDto>(`/boards/${boardId}`);
}