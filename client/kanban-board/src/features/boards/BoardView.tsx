import React, { useEffect, useState } from "react";
import type { BoardDto } from "../../types/board";

type BoardViewProps = {
    board: BoardDto;
};

export function BoardView({ board }: BoardViewProps) {
    const [currentBoard, setCurrentBoard] = useState(board);
    const [draggedCardId, setDraggedCardId] = useState<string | null>(null);
    const [dragOverColumnId, setDragOverColumnId] = useState<string | null>(null);

    useEffect(() => {
        setCurrentBoard(board);
    }, [board]);

    function handleDragStart(
        event: React.DragEvent<HTMLElement>,
        cardId: string,
    ) {
        setDraggedCardId(cardId);

        event.dataTransfer.setData("text/plain", cardId);
        event.dataTransfer.effectAllowed = "move";
    }

    function handleDragEnd() {
        setDraggedCardId(null);
        setDragOverColumnId(null);
    }

    function handleDragOver(
        event: React.DragEvent<HTMLElement>,
        columnId: string,
    ) {
        event.preventDefault();

        event.dataTransfer.dropEffect = "move";
        setDragOverColumnId(columnId);
    }

    function handleDrop(
        event: React.DragEvent<HTMLElement>,
        targetColumnId: string,
    ) {
        event.preventDefault();

        const cardId = event.dataTransfer.getData("text/plain") || draggedCardId;
        if (!cardId) {
            return;
        }
        moveCard(cardId, targetColumnId);
        handleDragEnd();
    }

    function moveCard(cardId: string, targetColumnId: string) {
        setCurrentBoard((previousBoard) => {
            let cardToMove = null;
            let sourceColumnId: string | null = null;

            for (const column of previousBoard.columns) {
                const card = column.cards.find((item) => item.id === cardId);

                if (card) {
                    cardToMove = card;
                    sourceColumnId = column.id;
                    break;
                }
            }
            if (!cardToMove || !sourceColumnId) {
                return previousBoard;
            }
            if (sourceColumnId === targetColumnId) {
                return previousBoard;
            }

            const updatedColumns = previousBoard.columns.map((column) => {
                if (column.id === sourceColumnId) {
                    return {
                        ...column,
                        cards: column.cards.filter((card) => card.id !== cardId).map((card, index) => ({
                            ...card, position: index,
                        })),
                    };
                }

                if (column.id === targetColumnId) {
                    return {
                        ...column,
                        cards: [...column.cards, {
                            ...cardToMove,
                            position: column.cards.length,
                        },
                        ],
                    };
                }
                return column;
            });

            return {
                ...previousBoard,
                columns: updatedColumns,
            };
        });
    }

    return (
        <main>
            <h1>{currentBoard.name}</h1>
            <section
                className="board"
                aria-label={`${currentBoard.name} columns`}>
                {[...currentBoard.columns].sort((first, second) => first.position - second.position).map((column) => (
                    <article
                        className={`column ${dragOverColumnId === column.id ? "drag-over" : ""}`}
                        key={column.id}
                        onDragOver={(event) => handleDragOver(event, column.id)}
                        onDragEnter={() => setDragOverColumnId(column.id)}
                        onDragLeave={() => setDragOverColumnId(null)}
                        onDrop={(event) => handleDrop(event, column.id)}
                    >
                        <header className="column-header">
                            <h2>{column.name}</h2>
                            <span>{column.cards.length}</span>
                        </header>

                        <div className="cards">
                            {[...column.cards].sort((first, second) => first.position - second.position).map((card) => (
                                <article
                                    className={`card ${draggedCardId === card.id ? "dragging" : ""}`}
                                    key={column.id}
                                    draggable
                                    onDragStart={(event) => handleDragStart(event, card.id)}
                                    onDragEnd={handleDragEnd}
                                >
                                    <h3>{card.title}</h3>
                                    {card.description && <p>{card.description}</p>}
                                </article>
                            ))}
                        </div>

                        {column.cards.length === 0 && (<p className="empty-column">Drop a card here</p>
                        )}
                    </article>
                ))}
            </section>
        </main>
    );
}
