using System;
using System.Linq;
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RecursiveFactorial(int.Parse(Console.ReadLine())));
        }

        private static int RecursiveFactorial(int current)
        {
            if (current == 0)
            {
                return 1;
            }
            return current*RecursiveFactorial(current-1);
        }
    }
}
