namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
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

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if (this.Count == 0)
            {
                this.head = new Node(item);
                this.Count++;
                return;
            }
            Node nodeToBeAdded = new Node(item);
            Node node = this.head;
            while (node.Next != null)
            {
                node = node.Next;
            }
           node.Next= nodeToBeAdded;
            this.Count++;
        }

        public T Dequeue()
        {
           OperationsOnEmptyQueue();
            Node oldHead = this.head;
            this.head = head.Next;
            this.Count--;
            return oldHead.Value;
        }

        public T Peek()
        {
            OperationsOnEmptyQueue();
            return this.head.Value;
        }

        public bool Contains(T item)
        {
            Node node = this.head;
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
            Node node = this.head;
            while (node != null)
            {
                yield return node.Value;    
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        private void OperationsOnEmptyQueue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}