using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameBoard
    {
        private const int _width = 10;
        private const int _heigth = 20;
        private string[] _boardLines;
        private readonly int _borderSize;
        private readonly char[] _cellType = new char[] { ' ', '#' };

        public string[] Lines
        {
            get { return _boardLines; }
            set { _boardLines = value; }
        }
        public int GetWidth { get { return _width; } }
        public int GetHeigth { get { return _heigth; } }
        public int GetBorderSize { get { return _borderSize; } }
        public char[] GetCells { get { return _cellType; } }

        public GameBoard(int borders)
        {
            _borderSize = borders;

            //Creating empty field 10x20
            _boardLines = Enumerable.Range(0, _heigth)
                .Select(_ => new String(' ', _width))
                .ToArray();
        }
    }
}
