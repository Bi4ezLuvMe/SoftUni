namespace _6.Calculate_Sequence_with_a_Queue
{
    public class Program
    {
        public static void CalculateSequence(int number)
        {
            Queue<int>queue = new Queue<int>() ;
            queue.Enqueue(number) ;
            List<int> result = new() { number};

            while(result.Count < 50)
            {
                int current = queue.Dequeue();
                result.Add(current);
                queue.Enqueue(current + 1);
                queue.Enqueue(2*current+1);
                queue.Enqueue(current + 2);
            }

            Console.WriteLine(String.Join(", ",result));
        }
        static void Main(string[] args)
        {
            CalculateSequence(int.Parse(Console.ReadLine()));
        }
    }
}
