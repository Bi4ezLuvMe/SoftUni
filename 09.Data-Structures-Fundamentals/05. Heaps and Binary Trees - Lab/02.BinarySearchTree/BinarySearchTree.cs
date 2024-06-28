namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Xml;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree() 
        {
        }
        BinarySearchTree<T> root;
        T Value;
        BinarySearchTree<T> Left { get; set; }
        BinarySearchTree<T> Right { get; set; }
        public bool Contains(T element)
        {
            return this.Contains(this.root,element);
        }

        private bool Contains(BinarySearchTree<T> tree,T element)
        {
            if (tree == null)
            {
                return false;
            }

            if (element.CompareTo(tree.Value) > 0)
            {
                return Contains(tree.Right, element);
            }else if (element.CompareTo(tree.Value) < 0)
            {
                return Contains(tree.Left, element);
            }
            else
            {
                return true;
            }
        }

        public void EachInOrder(Action<T> action)
        {
          this.EachInOrder(action,this.root);
        }

        private void EachInOrder(Action<T> action, BinarySearchTree<T> tree)
        {
            if (tree == null)
            {
                return;
            }
            this.EachInOrder(action, tree.Left);

            action.Invoke(tree.Value);

            this.EachInOrder(action, tree.Right);
        }

        public void Insert(T element)
        {
            this.root = this.Insert(this.root,element);
        }

        private BinarySearchTree<T> Insert(BinarySearchTree<T> tree,T element)
        {
            if (tree == null)
            {
                tree = new BinarySearchTree<T>();
                tree.Value = element;
                return tree;
            }
            if (element.CompareTo(tree.Value) > 0)
            {
                tree.Right = this.Insert(tree.Right, element);
            }else if(element.CompareTo(tree.Value) < 0)
            {
                tree.Left = this.Insert(tree.Left, element);
            }
            return tree;    
        }

        public IBinarySearchTree<T> Search(T element)
        {
           return Search(this.root, element);
        }

        private BinarySearchTree<T> Search(BinarySearchTree<T> tree, T element)
        {
            if (tree==null)
            {
                return null;
            }
            if (element.CompareTo(tree.Value) > 0)
            {
                return Search(tree.Right, element);
            }else if (element.CompareTo(tree.Value) < 0)
            {
                return Search(tree.Left, element);
            }
            else
            {
                tree.root = tree;
                return tree;
            }
        }
    }
}
