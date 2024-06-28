namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
           Dictionary<int,(T nodeValue,int distance)>dict = new Dictionary<int, (T nodeValue, int distance)>();

            this.TopView(this, 0, 0, dict);

            return dict.Values.Select(x => x.nodeValue).ToList();
        }

        private void TopView(BinaryTree<T> tree, int distance, int level, Dictionary<int, (T nodeValue, int nodeLevel)> dict)
        {
           if(tree is null)
            {
                return;
            }
            if (!dict.ContainsKey(distance))
            {
                dict.Add(distance, (tree.Value, level));
            }
            TopView(tree.LeftChild, distance - 1, level + 1, dict);
            TopView(tree.RightChild, distance + 1, level + 1, dict);
        }
    }
}
