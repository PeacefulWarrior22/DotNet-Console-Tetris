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
            int[] keyCell = item.calculateKeyCellPosition(item, side);

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

        /// <summary>
        /// Calculate Key Cell for square form matrix
        /// with fixed Centre (T and L shapes).
        /// </summary>
        /// <returns>New Key Cell Position</returns>
        public int[] SquareKeyCell(Tetramino item, bool side)
        {
            return GetSquareMatrixKeyCell(item, side);
        }
        private int[] GetSquareMatrixKeyCell(Tetramino item, bool side)
        {
            if (side) return GetClockWiseKeyCell(item);
            else return GetCounterClockWiseKeyCell(item);
        }
        private int[] GetClockWiseKeyCell(Tetramino item)
        {
            //all possible key cells for square matrix
            List<int[]> allKeyCells = GetAllKeyCells();
            int itemKeyCellIndex = allKeyCells.FindIndex(cell => item.KeyCellPosition.SequenceEqual(cell));
            bool isMatrixHorizontaly = item.Matrix.GetLength(0) < item.Matrix.GetLength(1);
            bool isLastKeyCell = itemKeyCellIndex == allKeyCells.Count - 1;

            if (isLastKeyCell)
            {
                /* Key Cell {1, 1} is repeating two times.
                 * Depending on orientation and turn side
                 * we need to save it or switch to next 
                 * key cell position.
                 */
                return isMatrixHorizontaly ?
                    allKeyCells[itemKeyCellIndex - 1]
                    :
                    allKeyCells[itemKeyCellIndex];
            }
            else
            {
                int nextIndex = (itemKeyCellIndex - 1) >= 0 ? (itemKeyCellIndex - 1) : allKeyCells.Count - 1;
                return allKeyCells[nextIndex];
            }
        }
        private int[] GetCounterClockWiseKeyCell(Tetramino item)
        {
            //all possible key cells for square matrix
            List<int[]> allKeyCells = GetAllKeyCells();
            int itemKeyCellIndex = allKeyCells.FindIndex(cell => item.KeyCellPosition.SequenceEqual(cell));
            bool isMatrixHorizontaly = item.Matrix.GetLength(0) < item.Matrix.GetLength(1);
            bool isLastKeyCell = itemKeyCellIndex == allKeyCells.Count - 1;

            if (isLastKeyCell)
            {
                /* Key Cell {1, 1} is repeating two times.
                 * Depending on orientation and turn side
                 * we need to save it or switch to next 
                 * key cell position.
                 */
                return isMatrixHorizontaly ?
                    allKeyCells[itemKeyCellIndex]
                    :
                    allKeyCells[0];
            }
            else
            {
                return allKeyCells[itemKeyCellIndex + 1];
            }
        }
        private List<int[]> GetAllKeyCells() => new List<int[]>() {
                new int[] { 0, 1 } ,
                new int[] { 1, 0 } ,
                new int[] { 1, 1 } //repeat two times
            };

        public int[] LineKeyCell(Tetramino item, bool side)
        {
            List<int[]> allKeyCells = new List<int[]>() { new int[] { 0, 1 }, new int[] { 2, 0 } };

            return (item.KeyCellPosition.SequenceEqual(allKeyCells[0])) ? allKeyCells[1] : allKeyCells[0];
        }

        public int[] ZShapeKeyCell(Tetramino item, bool side)
        {
            List<int[]> allKeyCells = new List<int[]>() { new int[] { 0, 1 }, new int[] { 1, 1 } };

            return (item.KeyCellPosition.SequenceEqual(allKeyCells[0])) ? allKeyCells[1] : allKeyCells[0];
        }
        public int[] StaticKeyCell(Tetramino item, bool side)
        {
            return item.KeyCellPosition;
        }
    }
}
