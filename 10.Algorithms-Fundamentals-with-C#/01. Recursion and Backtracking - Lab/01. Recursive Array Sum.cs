using System;
using System.Linq;
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RecursiveSum(Console.ReadLine().Split().Select(int.Parse).ToArray(), 0));
        }

        private static int RecursiveSum(int[] arr, int index)
        {
            if (index == arr.Length - 1)
            {
                return arr[index];
            }
            return arr[index] + RecursiveSum(arr, index + 1);
        }
    }
}
