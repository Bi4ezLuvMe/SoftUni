using System;
using System.Linq;
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            GenerateVectors(arr, 0);
        }

        private static void GenerateVectors(int[] arr, int index)
        {
            if(index == arr.Length)
            {
                Console.WriteLine(string.Join("",arr));
                return;
            }
            for (int i = 0; i <= 1; i++)
            {
                arr[index] = i;
                GenerateVectors(arr, index + 1);
            }
        }
    }
}
