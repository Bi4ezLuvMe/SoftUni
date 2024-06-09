namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T value)
            {
                this.Value = value;
            }

            public Node(T value, Node next) : this(value)
            {
                this.Next = next;
            }
        }

        private Node head;
        public int Count{ get; private set; }

        public void AddFirst(T item)
        {
           Node newNode =  new Node(item,this.head);
            this.head = newNode;
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node newNode = new Node(item);
            if (this.Count == 0)
            {
                this.head = newNode;
                this.Count++;
                return;
            }
            Node node = this.head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            node.Next = newNode;
            this.Count++;
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

        public T GetFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return head.Value;
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
           Node node = this.head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            return node.Value;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            Node oldHeadNode = this.head;
            this.head = this.head.Next;
            this.Count--;
            return oldHeadNode.Value;
        }

        public T RemoveLast()
        {
            if (this.Count == 1)
            {
                T val = head.Value;
                head = null;
                Count--;
                return val;
            }
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            Node node = this.head;
            while (node.Next.Next != null)
            {
                node = node.Next;
            }
            T value = node.Next.Value;
            node.Next = null;
            this.Count--;
            return value;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}