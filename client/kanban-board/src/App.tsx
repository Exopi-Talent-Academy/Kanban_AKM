import { BoardView } from "./features/boards/BoardView";
import { useBoard } from "./hooks/useBoard";
import "./App.css";

const sampleBoardId = "11111111-1111-1111-1111-111111111111";

function App() {
    const { board, isLoading, error } = useBoard(sampleBoardId);

    if (isLoading) {
        return <p>Loading board...</p>;
    }

    if (error) {
        return (
            <main>
                <p role="alert">{error}</p>
                <p>
                    Confirm that the HTTPS API is running and that its URL is configured correctly.
                    The configuring URL can be found in the <code>.env.development</code> file.
                </p>
            </main>
        );
    }

    if (!board) {
        return <p>We have no board! Or it hasn't been found. Either way, we can't run it, chief.</p>;
    }

    return <BoardView board={board} />;
}

export default App
