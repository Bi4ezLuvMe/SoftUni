namespace _9._Sum_Evens_in_Background
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long sum = 0;

            Task task = Task.Run(() => 
            {
                for (int i = 0; i < 1000000000; i+=2)
                {
                    sum += i;
                }
            });
            while (true)
            {
                string command = Console.ReadLine();

                if(command is "end")
                {
                    return;
                }
                else if(command is "show")
                {
                    Console.WriteLine(sum);
                }
            }
        }
    }
}
