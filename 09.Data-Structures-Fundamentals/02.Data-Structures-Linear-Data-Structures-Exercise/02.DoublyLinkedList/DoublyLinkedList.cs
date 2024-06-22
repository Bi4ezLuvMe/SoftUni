namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        class Node
        {
            public T Value { get; set; }
            public Node Prev { get; set; }
            public Node Next { get; set; }
            public Node(T value)
            {
                this.Value = value;
            }
        }
        Node head;
        Node tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node newNode = new Node(item);
            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
                this.Count++;
                return;
            }
            Node prevHead = this.head;
           prevHead.Prev = newNode;
            this.head = newNode;
            this.head.Next = prevHead;
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node newNode = new Node(item);
            if (this.Count == 0)
            {
                this.Count++;
                this.head = this.tail = newNode;
                return;
            }
            newNode.Prev = this.tail;
            tail.Next = newNode;
            this.tail = newNode;
            this.Count++;
        }

        public T GetFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return this.head.Value;
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return this.tail.Value;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T value = this.head.Value;
            this.head = this.head.Next;
            Count--;
            return value;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T value = this.tail.Value;
            this.tail = this.tail.Prev;
            if (this.tail != null)
            {
                this.tail.Next = null;
            }
            else
            {
                this.head = null;
            }
            this.Count--;
            return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
           Node headNode = this.head;
            while (headNode != null)
            {
                yield return headNode.Value;
                headNode = headNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}