namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public BinarySearchTree()
        {
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public bool Contains(T element)
        {
            Node current = this.FindElement(element);

            return current != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node current = this.FindElement(element);

            return new BinarySearchTree<T>(current);
        }

        public void Delete(T element)
        {
            if(this.root is null)
            {
                throw new InvalidOperationException();
            }
            this.root = this.Delete(this.root, element);
        }

        private Node Delete(Node node, T element)
        {
            if (node == null)
            {
                return null;
            }

            int compare = element.CompareTo(node.Value);
            if (compare < 0)
            {
                node.Left = this.Delete(node.Left, element);
            }
            else if (compare > 0)
            {
                node.Right = this.Delete(node.Right, element);
            }
            else
            {
                if (node.Left == null)
                {
                    return node.Right;
                }
                if (node.Right == null)
                {
                    return node.Left;
                }

                Node temp = node;
                node = this.Min(temp.Right);
                node.Right = this.DeleteMin(temp.Right);
                node.Left = temp.Left;
            }

            return node;
        }
        private Node Min(Node node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

            public void DeleteMax()
        {
            if (this.root is null)
            {
                throw new InvalidOperationException();
            }
            this.root = DeleteMax(this.root);
        }

        private Node DeleteMax(Node node)
        {
            if (node.Right is null)
            {
                return node.Left;
            }
            node.Right = DeleteMax(node.Right);
            return node;
        }

        public void DeleteMin()
        {
          if(this.root is null)
            {
                throw new InvalidOperationException();
            }
          this.root = DeleteMin(this.root);
        }

        private Node DeleteMin(Node node)
        {
           if(node.Left is null)
            {
                return node.Right;
            }
            node.Left = DeleteMin(node.Left);
            return node;
        }

        public int Count()
        {
           return GetCountOfItems(this.root);
        }

        private int GetCountOfItems(Node node)
        {
            if (node == null)
            {
                return 0;
            }
           int leftCount = GetCountOfItems(node.Left);
            int rightCount = GetCountOfItems(node.Right);

            return 1+leftCount+rightCount;
        }

        public int Rank(T element)
        {
            return GetRank(this.root, element);
        }

        private int GetRank(Node node, T element)
        {
            if (node == null)
            {
                return 0;
            }

            int compare = element.CompareTo(node.Value);
            if (compare < 0)
            {
                return this.GetRank(node.Left, element);
            }
            else if (compare > 0)
            {
                return 1 + this.GetCountOfItems(node.Left) + this.GetRank(node.Right, element);
            }
            else
            {
                return this.GetCountOfItems(node.Left);
            }
        }

        public T Select(int rank)
        {
          if(this.root is null)
            {
                throw new InvalidOperationException();
            }
            Node node = Select(this.root, rank);
          if(node is null)
            {
                throw new InvalidOperationException();
            }
            return node.Value;
        }

        private Node Select(Node node, int rank)
        {
           if(node is null)
            {
                return null;
            }
            int leftCount = this.GetCountOfItems(node.Left);
            if (leftCount == rank)
            {
                return node;
            }
            if (leftCount > rank)
            {
                return this.Select(node.Left, rank);
            }
            else
            {
                return this.Select(node.Right, rank - (leftCount + 1));
            }
        }

        public T Ceiling(T element)
        {
            return this.Select(this.Rank(element) + 1);
        }

        public T Floor(T element)
        {
            return this.Select(this.Rank(element) - 1);
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            List<T> inRangeItems = new List<T>();
            FindInRangeItems(this.root, startRange, endRange,inRangeItems);
            return inRangeItems.OrderBy(x=>x);
        }

        private void FindInRangeItems(Node node, T startRange, T endRange,List<T>inRangeItems)
        {
            if(node == null)
            {
                return;
            }

            if (node.Value.CompareTo(startRange) >= 0 && node.Value.CompareTo(endRange) <= 0)
            {
                inRangeItems.Add(node.Value);
                FindInRangeItems(node.Left, startRange, endRange, inRangeItems);
                FindInRangeItems(node.Right, startRange, endRange, inRangeItems);
            }
            if (node.Value.CompareTo(startRange) < 0)
            {
                FindInRangeItems(node.Right, startRange, endRange, inRangeItems);
            }
            if (node.Value.CompareTo(endRange) > 0)
            {
                FindInRangeItems(node.Left, startRange, endRange, inRangeItems);
            }
        }

        private Node FindElement(T element)
        {
            Node current = this.root;

            while (current != null)
            {
                if (current.Value.CompareTo(element) > 0)
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(element) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            return node;
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }
    }
}
