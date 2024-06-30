using System;
using System.Collections.Generic;
namespace ConsoleApp2
{
    internal class Program
    {
        public static HashSet<int> attackedRows = new HashSet<int>();
        public static HashSet<int> attackedCols = new HashSet<int>();
        public static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        public static HashSet<int> attackedRightDiagonals = new HashSet<int>();
        static void Main(string[] args)
        {
            char[][] matrix = new char[8][];
            for (int i = 0; i < 8; i++)
            {
                matrix[i] = new char[8];
                for (int j = 0; j < 8; j++)
                {
                    matrix[i][j] = '-';
                }
            }
            QueensPuzzle(matrix, 0);
        }

        private static void QueensPuzzle(char[][] matrix, int row)
        {
            if (row >= 8)
            {
                PrintBoard(matrix);
                return;
            }
            for (int col = 0; col < 8; col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    matrix[row][col] = '*';

                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attackedLeftDiagonals.Add(row - col);
                    attackedRightDiagonals.Add(row + col);

                    QueensPuzzle(matrix, row + 1);

                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attackedLeftDiagonals.Remove(row - col);
                    attackedRightDiagonals.Remove(row + col);

                    matrix[row][col] = '-';
                }
            }
        }

        private static void PrintBoard(char[][] matrix)
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(String.Join(" ", matrix[i])+" ");
            }
            Console.WriteLine();
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            return !attackedRows.Contains(row) && !attackedCols.Contains(col) && !attackedLeftDiagonals.Contains(row - col) && !attackedRightDiagonals.Contains(row + col);
        }
    }
}
