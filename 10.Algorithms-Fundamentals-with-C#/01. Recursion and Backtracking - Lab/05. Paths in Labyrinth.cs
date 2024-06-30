using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            char[][] matrix = new char[row][];
            for (int i = 0; i < row; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }
            FindAllPaths(matrix,0,0, new List<string>(), string.Empty);
        }

        private static void FindAllPaths(char[][] matrix,int row,int col, List<string> directions, string direction)
        {
            if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix[0].Length)
            {
                return;
            }
            if (matrix[row][col] == '*' || matrix[row][col] =='v')
            {
                return;
            }
            directions.Add(direction);
            if (matrix[row][col] == 'e')
            {
                Console.WriteLine(string.Join("",directions));
                directions.RemoveAt(directions.Count-1);
                return;
            }
            matrix[row][col] = 'v';
            FindAllPaths(matrix, row + 1,col,directions,"D");
            FindAllPaths(matrix, row - 1, col, directions, "U");
            FindAllPaths(matrix, row, col+1, directions, "R");
            FindAllPaths(matrix, row , col-1, directions, "L");
            matrix[row][col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }
    }
}
