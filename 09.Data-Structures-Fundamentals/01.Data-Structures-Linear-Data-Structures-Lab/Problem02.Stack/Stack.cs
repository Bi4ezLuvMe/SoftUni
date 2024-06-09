namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T value)
            {
                this.Value = value;
            }
            public Node(T value,Node next):this(value)
            {
                this.Next = next;
            }

        }

        private Node top;

        public int Count { get;private set; }
        public void Push(T item)
        {
            Node node = new Node(item);
            node.Next = this.top;
            this.top = node;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            Node oldTop = this.top;
            top = oldTop.Next;
            Count--;
            return oldTop.Value;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return this.top.Value;
        }

        public bool Contains(T item)
        {
            Node node = this.top;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = this.top;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}