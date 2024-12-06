using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public delegate int[] CalculateKeyCell(Tetramino item);
    public abstract class Tetramino
    {
        private protected int _x;
        private protected int _y;

        public int[] KeyCellPosition { get; set; }
        public int X
        {
            get => _x - (KeyCellPosition[1] + 1); // KeyCellPosition offset
            set => _x = value;
        }
        public int Y
        {
            get => _y - (KeyCellPosition[0] + 1); // KeyCellPosition offset
            set => _y = value;
        }
        public int[,]? Matrix { get; set; }

        public CalculateKeyCell calculateKeyCellPosition;
        public Tetramino()
        {
            _x = 5;
            _y = 2;
        }
    }

    class SquareShape : Tetramino
    {
        public SquareShape() : base()
        {
            calculateKeyCellPosition += new TetraminoRotator().StaticKeyCell;

            KeyCellPosition = new int[] { 0, 0 };
            Matrix = new int[,] {
                { 1, 1 },
                { 1, 1 }
            };
        }
    }

    class LineShape : Tetramino
    {
        public LineShape() : base()
        {
            calculateKeyCellPosition += new TetraminoRotator().DinamycKeyCell;

            KeyCellPosition = new int[] { 1, 1 };
            Matrix = new int[,] {
                { 0, 0, 0, 0 },
                { 1, 1, 1, 1 },
                { 0, 0, 0, 0 }
            };
        }
    }

    class ZShape : Tetramino
    {
        public ZShape() : base()
        {
            calculateKeyCellPosition += new TetraminoRotator().DinamycKeyCell;

            KeyCellPosition = new int[] { 0, 1 };
            Matrix = new int[,] {
                { 1, 1, 0 },
                { 0, 1, 1 }
            };
        }
    }

    class RZShape : Tetramino
    {
        public RZShape() : base()
        {
            calculateKeyCellPosition += new TetraminoRotator().DinamycKeyCell;

            KeyCellPosition = new int[] { 0, 1 };
            Matrix = new int[,] {
                { 0, 1, 1 },
                { 1, 1, 0 }
            };
        }
    }

    class TShape : Tetramino
    {
        public TShape() : base()
        {
            calculateKeyCellPosition += new TetraminoRotator().StaticKeyCell;

            KeyCellPosition = new int[] { 1, 1 };
            Matrix = new int[,] {
                { 0, 0, 0 },
                { 1, 1, 1 },
                { 0, 1, 0 }
            };
        }
    }

    class LShape : Tetramino
    {
        public LShape() : base()
        {
            calculateKeyCellPosition += new TetraminoRotator().StaticKeyCell;

            KeyCellPosition = new int[] { 1, 1 };
            Matrix = new int[,] {
                { 0, 0, 0 },
                { 1, 1, 1 },
                { 1, 0, 0 }
            };
        }
    }

    class RLShape : Tetramino
    {

        public RLShape() : base()
        {
            calculateKeyCellPosition += new TetraminoRotator().StaticKeyCell;

            KeyCellPosition = new int[] { 1, 1 };
            Matrix = new int[,] {
                { 0, 0, 0 },
                { 1, 1, 1 },
                { 0, 0, 1 }
            };
        }
    }
}
