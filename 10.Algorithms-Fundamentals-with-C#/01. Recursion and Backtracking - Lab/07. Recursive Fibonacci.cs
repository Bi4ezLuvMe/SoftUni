using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(RecursiveFibonacii(n));
        }

        private static long RecursiveFibonacii(int current)
        {
            if (current <= 1)
            {
                return 1;
            }
            return RecursiveFibonacii(current - 1) + RecursiveFibonacii(current - 2);
        }

    }
}
