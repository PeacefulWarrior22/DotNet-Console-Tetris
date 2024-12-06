using Tetris;

internal class Game
{
    private static void Main(string[] args)
    {
        Tetramino[] tetramino = {
            new SquareShape(),
            new LineShape(),
            new ZShape(),
            new RZShape(),
            new TShape(),
            new LShape(),
            new RLShape()
        };
        int ti = 4;
        var field = new GameBoard(6);
        var gameRender = new DrawingHandler(field, tetramino[ti]);

        gameRender.ConsoleSetup();
        while (true)
        {
            gameRender.RenderGameArea();
            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
            (tetramino[ti].Matrix, tetramino[ti].KeyCellPosition) = new TetraminoRotator().RotateWithKey(tetramino[ti], false);
        }
    }
}