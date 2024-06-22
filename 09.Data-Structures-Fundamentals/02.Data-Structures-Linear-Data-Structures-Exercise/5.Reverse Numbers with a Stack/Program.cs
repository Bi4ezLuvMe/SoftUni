namespace _5.Reverse_Numbers_with_a_Stack
{
    public class Program
    {
        public static void ReverseNumbersWithStack(int[]numbers)
        {
            Stack<int>stack = new Stack<int>(numbers);
            Console.WriteLine(String.Join(" ",stack));
        }
        static void Main(string[] args)
        {
            ReverseNumbersWithStack(Console.ReadLine().Split().Select(int.Parse).ToArray());
        }
    }
}
