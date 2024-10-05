
namespace _8._Sum_Evens_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();
                if(command is "show")
                {
                    long result = SumAsync();
                    Console.WriteLine(result);
                }
            }
        }

        private static long SumAsync()
        {
            return Task.Run(() => 
            {
                long sum = 0;
                for (int i = 0; i < 10000; i += 2)
                {
                    sum += i;
                }
                return sum;
            }).Result;
        }
    }
}
