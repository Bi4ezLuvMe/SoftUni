namespace _7._Sequence_N_to_M
{
    internal class Program
    {
        public static void ShortestPath(int start,int end)
        {
            Queue<int> queue = new();
            List<int> result = new();
            queue.Enqueue(start);
            while(queue.Count() is not 0)
            {
                int current = queue.Dequeue();
                result.Add(current);
                if (current < end)
                {
                    queue.Enqueue(current+1);
                    queue.Enqueue(current + 2);
                    queue.Enqueue(current*2);
                }
                if (current == end)
                {
                    Console.WriteLine(String.Join(" -> ",result));
                    return;
                }
            }
        }
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            ShortestPath(input[0], input[1]);
        }
    }
}
