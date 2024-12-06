using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class DrawingHandler
    {
        private GameBoard _gameBoard;
        private Tetramino _tetramino;

        public Tetramino Tetramino { set { _tetramino = value; } }

        public void ConsoleSetup()
        {
            int horizontalBorders = _gameBoard.GetBorderSize * 2 * 2;
            int verticalBorders = horizontalBorders / 2;
            int fieldFullWidth = _gameBoard.GetWidth + 2;
            int fieldFullHeight = _gameBoard.GetHeigth + 1 + 1;

            Console.SetWindowSize(horizontalBorders + fieldFullWidth, verticalBorders + fieldFullHeight);
            Console.SetBufferSize(horizontalBorders + fieldFullWidth, verticalBorders + fieldFullHeight);
        }
        public void RenderGameArea()
        {
            int tetraminoStartLineIndex = _tetramino.Y;
            int matrixLineIndex = 0;

            DrawBoardBorders();
            DrawOutBoardLines(ref tetraminoStartLineIndex, ref matrixLineIndex);
            DrawGameBoard(tetraminoStartLineIndex, matrixLineIndex);
            DrawBoardBorders();
        }
        private void DrawGameBoard(int tetraminoStartLineIndex, int matrixLineIndex)
        {
            int boardLineIndex = 0;
            while (boardLineIndex < _gameBoard.GetHeigth)
            {
                if (boardLineIndex == tetraminoStartLineIndex)
                {
                    int tetraminoMatrixHeigth = _tetramino.Matrix.GetLength(0);
                    while (matrixLineIndex < tetraminoMatrixHeigth)
                    {
                        DrawPaddingLine($"|{DrawTetraminoLine(boardLineIndex, matrixLineIndex)}|");

                        boardLineIndex++;
                        matrixLineIndex++;
                    }
                }

                DrawPaddingLine($"|{_gameBoard.Lines[boardLineIndex]}|");
                boardLineIndex++;
            }

            string bottom = new string('=', _gameBoard.GetWidth + 2);
            DrawPaddingLine($"{bottom}");
        }
        private void DrawBoardBorders()
        {
            for (int i = 0; i < _gameBoard.GetBorderSize; i++)
            {
                var paddingLine = new string(' ', Console.BufferWidth - 1);
                Console.WriteLine(paddingLine);
            }
        }
        private void DrawOutBoardLines(ref int tetraminoStartLineIndex, ref int matrixLineIndex)
        {
            if (tetraminoStartLineIndex < 0)
            {
                Console.SetCursorPosition(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top + tetraminoStartLineIndex);

                while (tetraminoStartLineIndex != 0)
                {
                    DrawPaddingLine($" {DrawTetraminoLine(matrixLineIndex++)} ");
                    tetraminoStartLineIndex++;
                }
            }
        }
        private string DrawTetraminoLine(int borderLineIndex, int tetraminoLineIndex)
        {
            var lineWithTetramino = new StringBuilder();
            string currentLine = _gameBoard.Lines[borderLineIndex];
            int tetraminoWidth = _tetramino.Matrix.GetLength(1);

            lineWithTetramino.Append(currentLine, 0, _tetramino.X);

            for (int i = 0; i < tetraminoWidth; i++)
            {
                int tetraminoMatrixCellStatus = _tetramino.Matrix[tetraminoLineIndex, i];
                lineWithTetramino.Append(_gameBoard.GetCells[tetraminoMatrixCellStatus]);
            }

            int remainingLength = currentLine.Length - lineWithTetramino.Length;
            lineWithTetramino.Append(currentLine, lineWithTetramino.Length, remainingLength);

            return lineWithTetramino.ToString();
        }
        private string DrawTetraminoLine(int tetraminoLineIndex)
        {
            var lineWithTetramino = new StringBuilder();
            string emptyLine = new string(' ', _gameBoard.GetWidth);
            int tetraminoWidth = _tetramino.Matrix.GetLength(1);

            lineWithTetramino.Append(emptyLine, 0, _tetramino.X);

            for (int i = 0; i < tetraminoWidth; i++)
            {
                int tetraminoMatrixCellStatus = _tetramino.Matrix[tetraminoLineIndex, i];
                lineWithTetramino.Append(_gameBoard.GetCells[tetraminoMatrixCellStatus]);
            }

            int remainingLength = emptyLine.Length - lineWithTetramino.Length;
            lineWithTetramino.Append(emptyLine, lineWithTetramino.Length, remainingLength);

            return lineWithTetramino.ToString();
        }
        private void DrawPaddingLine(string line)
        {
            var leftPadding = new string(' ', _gameBoard.GetBorderSize * 2);
            var rightPadding = new string(' ', _gameBoard.GetBorderSize * 2);

            Console.WriteLine($"{leftPadding}{line}{rightPadding}");
        }
        public DrawingHandler(GameBoard field, Tetramino tetramino)
        {
            _gameBoard = field;
            _tetramino = tetramino;
        }
    }
}
