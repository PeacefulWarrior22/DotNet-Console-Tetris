using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class CollisionHandler
    {
        private Tetramino _tetramino;
        private GameBoard _gameBoard;
        public Tetramino Tetramino
        {
            set
            {
                _tetramino = value;
            }
        }
        //public GameBoard GameBoard { get; }

        public bool IsInsideGameBoard(int newTetraminoX)
        {
            int tetraminoWidth = _tetramino.Matrix.GetLength(1);
            int tetraminoHeigth = _tetramino.Matrix.GetLength(0);

            if (newTetraminoX >= 0 && newTetraminoX <= _gameBoard.GetWidth - tetraminoWidth)
            {
                return true;
            }
            else return false;
        }
        public CollisionHandler(Tetramino tetramino, GameBoard gameBoard)
        {
            _tetramino = tetramino;
            _gameBoard = gameBoard;
        }
    }
}
