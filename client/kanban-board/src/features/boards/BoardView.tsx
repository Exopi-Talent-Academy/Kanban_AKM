import type { BoardDto } from "../../types/board";

type BoardViewProps = {
    board: BoardDto;
};

export function BoardView({ board }: BoardViewProps) {
    return (
        <main>
            <h1>{board.name}</h1>

            <section className="board" aria-label={`${board.name} columns`}>
                {board.columns.sort((first, second) => first.position - second.position).map((column) => (
                    <article className="column" key={column.id}>
                        <header className="column-header">
                            <h2>{column.name}</h2>
                            <span>{column.cards.length}</span>
                        </header>

                        <div className="cards">
                            {column.cards.sort((first, second) => first.position - second.position).map((card) => (
                                <article className="card" key={card.id}>
                                    <h3>{card.title}</h3>

                                    {card.description && <p>{card.description}</p>}
                                </article>
                            ))}
                        </div>
                    </article>
                ))}
            </section>
        </main>
    )
}