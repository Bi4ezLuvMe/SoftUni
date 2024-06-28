namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            if (leftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (rightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            BinaryTree<T> firstNode = this.BFSfindNodeByValue(first, this);
            BinaryTree<T> secondNode = this.BFSfindNodeByValue(second, this);

            if (firstNode is null || secondNode is null)
            {
                throw new InvalidOperationException();
            }

            List<T> firstNodeAncestors = this.FindNodeAncestors(firstNode);
            List<T> secondNodeAncestors = this.FindNodeAncestors(secondNode);

            return firstNodeAncestors.Intersect(secondNodeAncestors).First();
        }

        private List<T> FindNodeAncestors(BinaryTree<T> tree)
        {
            List<T> ancestors = new List<T>();
            while (!(tree is null))
            {
                ancestors.Add(tree.Value);
                tree = tree.Parent;
            }
            return ancestors;
        }

        private BinaryTree<T> BFSfindNodeByValue(T element, BinaryTree<T> tree)
        {
            Queue<BinaryTree<T>> queue = new Queue<BinaryTree<T>>();
            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                BinaryTree<T> current = queue.Dequeue();

                if (current.Value.Equals(element))
                {
                    return current;
                }

                if (!(current.LeftChild is null))
                {
                    queue.Enqueue(current.LeftChild);
                }

                if (!(current.RightChild is null))
                {
                    queue.Enqueue(current.RightChild);
                }
            }

            return null;
        }
    }
}
