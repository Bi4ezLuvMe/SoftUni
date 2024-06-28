namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            this.Value = element;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            StringBuilder sb = new StringBuilder();

            DFSindentPreOrder(this, sb, indent);

            return sb.ToString().Trim();
        }

        private void DFSindentPreOrder(IAbstractBinaryTree<T> binaryTree, StringBuilder sb, int indent)
        {
            sb.Append(' ', indent).AppendLine(binaryTree.Value.ToString());

            if(binaryTree.LeftChild != null)
            {
                DFSindentPreOrder(binaryTree.LeftChild, sb, indent + 2);
            }
            if(binaryTree.RightChild != null)
            {
                DFSindentPreOrder(binaryTree.RightChild, sb, indent + 2);
            }
        }

        public void ForEachInOrder(Action<T> action)
        {
            List<IAbstractBinaryTree<T>> inOrder = (List<IAbstractBinaryTree<T>>)InOrder();
            foreach (var tree in inOrder)
            {
                action.Invoke(tree.Value);
            }
        }

        private void DFSInOrder(BinaryTree<T> binaryTree, StringBuilder sb, Action<T> action)
        {
            List<IAbstractBinaryTree<T>> inOrder = (List<IAbstractBinaryTree<T>>)InOrder();
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> inOrder = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                inOrder.AddRange(this.LeftChild.InOrder());
            }

            inOrder.Add(this);

            if (this.RightChild != null)
            {
                inOrder.AddRange(this.RightChild.InOrder());
            }

            return inOrder;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> postOrder = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                postOrder.AddRange(this.LeftChild.PostOrder());
            }

            if (this.RightChild != null)
            {
                postOrder.AddRange(this.RightChild.PostOrder());
            }

            postOrder.Add(this);

            return postOrder;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            List<IAbstractBinaryTree<T>> preOrder = new List<IAbstractBinaryTree<T>>();

            preOrder.Add(this);

            if(this.LeftChild != null)
            {
                preOrder.AddRange(this.LeftChild.PreOrder());
            }

            if(this.RightChild != null)
            {
                preOrder.AddRange(this.RightChild.PreOrder());
            }

            return preOrder;
        }
    }
}
