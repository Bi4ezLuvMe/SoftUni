using System;
using System.Linq;
using _03.MinHeap;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int minSweetness, int[] cookies)
        {
            int result = 0;
            MinHeap<int>minHeap = new MinHeap<int>();
            foreach (var cookie in cookies)
            {
                minHeap.Add(cookie);
            }
            while (minHeap.Peek() < minSweetness&&minHeap.Count>=2)
            {
                int currentFirst = minHeap.Peek();
                minHeap.ExtractMin();
                int secondMin = minHeap.Peek();
                minHeap.ExtractMin();
                minHeap.Add(currentFirst +(2*secondMin));
                result++;
            }
            if (minHeap.Peek() >= minSweetness)
            {
            return result;
            }
            return -1;
        }
    }
}
