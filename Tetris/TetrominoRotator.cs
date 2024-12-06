using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TetraminoRotator
    {
        public (int[,], int[]) RotateWithKey(Tetramino item, bool side)
        {
            int matrixWidth = item.Matrix.GetLength(1);
            int matrixHeigth = item.Matrix.GetLength(0);

            int[,] tempMatrix = new int[matrixWidth, matrixHeigth];
            int[] keyCell = item.calculateKeyCellPosition(item);

            if (side)
            {
                for (int i = 0; i < matrixHeigth; i++)
                {
                    for (int j = 0; j < matrixWidth; j++)
                    {
                        tempMatrix[j, (matrixHeigth - 1) - i] = item.Matrix[i, j];
                    }
                }
            }
            else
            {
                for (int i = 0; i < matrixHeigth; i++)
                {
                    for (int j = 0; j < matrixWidth; j++)
                    {
                        tempMatrix[j, i] = item.Matrix[i, (matrixWidth - 1) - j];
                    }
                }
            }

            return (tempMatrix, keyCell);
        }

        public int[] DinamycKeyCell(Tetramino item)
        {
            if (item.Matrix.GetLength(0) < item.Matrix.GetLength(1))
            {
                return new int[] { item.Matrix.GetLength(1) - (item.KeyCellPosition[1] + 1), item.KeyCellPosition[1] };
            }
            else
            {
                return new int[] { item.KeyCellPosition[0] - (item.Matrix.GetLength(0) - item.Matrix.GetLength(1)), item.KeyCellPosition[1] };
            }
        }
        public int[] StaticKeyCell(Tetramino item)
        {
            return item.KeyCellPosition;
        }
    }
}
