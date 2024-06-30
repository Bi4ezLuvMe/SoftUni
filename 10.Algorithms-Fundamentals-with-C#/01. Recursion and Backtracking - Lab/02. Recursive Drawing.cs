using System;
using System.Linq;
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RecursiveDrawing(int.Parse(Console.ReadLine()));
        }

        private static void RecursiveDrawing(int n)
        {
            if (n == 0)
            {
                return;
            }
            Console.WriteLine(new string('*',n));
            RecursiveDrawing(n - 1);
            Console.WriteLine(new string('#',n));
        }
    }
}
