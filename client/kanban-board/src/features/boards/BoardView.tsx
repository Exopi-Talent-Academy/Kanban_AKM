import React, { useEffect, useState } from "react";
import type { BoardDto, TaskDto } from "../../types/board";

type BoardViewProps = {
    board: BoardDto;
};

export function BoardView({ board }: BoardViewProps) {
    const [currentBoard, setCurrentBoard] = useState(board);
    const [draggedCardId, setDraggedCardId] = useState<string | null>(null);
    const [dragOverColumnId, setDragOverColumnId] = useState<string | null>(null);

    // MHM: Editing card states
    const [cardBeingEdited, setCardBeingEdited] = useState<TaskDto | null>(null);
    const [editTitle, setEditTitle] = useState("");
    const [editDescription, setEditDescription] = useState("");

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

    // MHM: Functions for editing added here:
    function openEditor(card: TaskDto) {
        setCardBeingEdited(card);
        setEditTitle(card.title);
        setEditDescription(card.description ?? "");
    }
    function closeEditor() {
        setCardBeingEdited(null);
        setEditTitle("");
        setEditDescription("");
    }
    function saveCard(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();
        if (!cardBeingEdited || !editTitle.trim()) {
            return;
        }
        setCurrentBoard((previousBoard) => ({
            ...previousBoard,
            columns: previousBoard.columns.map((column) => ({
                ...column,
                cards: column.cards.map((card) =>
                    card.id === cardBeingEdited.id
                        ? {
                            ...card,
                            title: editTitle.trim(),
                            description: editDescription.trim() || null,
                        }
                        : card,
                ),
            })),
        }));

        closeEditor();
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
                            <h2>{column.title}</h2>
                            <span>{column.cards.length}</span>
                        </header>

                        <div className="cards">
                            {[...column.cards].sort((first, second) => first.priority - second.priority).map((card) => (
                                <article
                                    className={`card ${draggedCardId === card.id ? "dragging" : ""}`}
                                    key={column.id}
                                    draggable
                                    onDragStart={(event) => handleDragStart(event, card.id)}
                                    onDragEnd={handleDragEnd}
                                    onClick={() => openEditor(card)}
                                    title="Click to edit this note"
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

            {cardBeingEdited && (
                <div className="modal-backdrop">
                    <section
                        className="edit-dialog"
                        role="dialog"
                        aria-modal="true"
                        aria-labelledby="edit-card-title"
                    >
                        <h2 id="edit-card-title">Edit note</h2>

                        <form onSubmit={saveCard}>
                            <label htmlFor="card-title">Title</label>
                            <input
                                id="card-title"
                                value={editTitle}
                                onChange={(event) => setEditTitle(event.target.value)}
                                required
                                autoFocus
                            />
                            <label htmlFor="card-description">Description</label>
                            <textarea
                                id="card-description"
                                value={editDescription}
                                onChange={(event) => setEditDescription(event.target.value)
                                }
                                rows={6}
                            />
                            <div className="dialog-actions">
                                <button type="button" onClick={closeEditor}>
                                    Cancel
                                </button>
                                <button type="submit">Save changes</button>
                            </div>
                        </form>
                    </section>
                </div>
            )}
        </main>
    );
}
