namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        T[] queue;
        int startIndex;
        int endindex;
        public CircularQueue(int capacity=4)
        {
            this.queue = new T[capacity];
        }
        public int Count { get; private set; }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            this.Count--;
            return this.queue[startIndex++];
        }

        public void Enqueue(T item)
        {
            if (this.Count>=this.queue.Length)
            {
                Grow();
            }
            queue[this.endindex++] = item;
            endindex %= queue.Length;
            this.Count++;
        }


        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
           return this.queue[this.startIndex];
        }

        public T[] ToArray()
        {
            T[] arrToReturn = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                arrToReturn[i] = queue[(startIndex + i) % this.queue.Length];
            }
            return arrToReturn;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return queue[(startIndex + i) % queue.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        private void Grow()
        {
            T[]newQueue = new T[this.queue.Length*2];
            for (int i = 0; i < this.Count; i++)
            {
                newQueue[i] = queue[(startIndex+i)%this.queue.Length];
            }
            startIndex = 0;
            endindex = this.Count;
            queue = newQueue;
        }
    }

}
