
namespace Async_Programing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 0;
            int end = 10;

            Thread evens  = new Thread(()=>PrintEvenNumbers(start,end));

            evens.Start();
            evens.Join();

            Console.WriteLine("Thread finished work!");
        }

        private static void PrintEvenNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
               if(i % 2 is 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
