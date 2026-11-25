import { useEffect, useState } from "react";
import { getBoard } from "../api/boards";
import { mockBoard } from "../api/mockBoard";
import type { BoardDto } from "../types/board";

// MHM: Whether we use the mockboard is defined in the .env.development.
const useMockBoard = import.meta.env.VITE_USE_MOCK_BOARD === "true";
export function useBoard(boardId: string) {
    const [board, setBoard] = useState<BoardDto | null>(null);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        let isCurrent = true;

        setIsLoading(true);
        setError(null);

        if (useMockBoard) {
            setBoard(mockBoard);
            setIsLoading(false);

            return () => {
                isCurrent = false;
            };
        }

        getBoard(boardId).then((result) => {
            if (isCurrent) {
                setBoard(result);
            }
        })
            .catch((reason: unknown) => {
                if (isCurrent) {
                    setError(reason instanceof Error ? reason.message : "Unable to load the board. Abort!",
                    );
                }
            })
            .finally(() => {
                if (isCurrent) {
                    setIsLoading(false);
                }
            });
        return () => {
            isCurrent = false;
        };
    }, [boardId]);

    return {
        board, isLoading, error,
    };
}