namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        List<Tree<T>> children;
        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.children.Add(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
           this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string AsString()
        {
            StringBuilder sb = new StringBuilder();

            DFStoString(sb, this, 0);

            return sb.ToString().Trim();
        }

        private void DFStoString(StringBuilder sb, Tree<T> tree, int indent)
        {
            sb.Append(' ', indent).AppendLine(tree.Key.ToString());

            foreach (var child in tree.children)
            {
                DFStoString(sb, child, indent + 2);
            }
        }

        public IEnumerable<T> GetInternalKeys()
        {
           List<T>internalKeys = new List<T>();

            DFSfindInternalKeys(internalKeys, this);

            return internalKeys;
        }

        private void DFSfindInternalKeys(List<T> internalKeys, Tree<T> tree)
        {
            if(tree.Parent != null && tree.children.Count > 0)
            {
                internalKeys.Add(tree.Key);
            }
            foreach (var child in tree.children)
            {
                DFSfindInternalKeys(internalKeys, child);
            }
        }

        public IEnumerable<T> GetLeafKeys()
        {
            List<T>leafKeys = new List<T>();

            DFSfindLeafKeys(leafKeys, this);
            
            return leafKeys;
        }

        private void DFSfindLeafKeys(List<T> leafKeys, Tree<T> tree)
        {
            if (tree.children.Count == 0)
            {
                leafKeys.Add(tree.Key);
            }
            foreach (var child in tree.children)
            {
                DFSfindLeafKeys(leafKeys, child);
            }
        }

        public T GetDeepestKey() => findDeepestNode().Key;

        private Tree<T> findDeepestNode()
        {
            List<Tree<T>> leafs =new List<Tree<T>>();
            GetLeafs(this, leafs);

            Tree<T> deepestNode = default;
            int maxDepth = 0;

            foreach (var leaf in leafs)
            {
                int depth = GetDepth(leaf);

                if (depth > maxDepth)
                {
                    maxDepth = depth;
                    deepestNode = leaf;
                }
            }
            return deepestNode;
        }

        private int GetDepth(Tree<T> leaf)
        {
            int depth = 0;
            while (leaf.Parent != null)
            {
                depth++;
                leaf = leaf.Parent;
            }
            return depth;
        }

        private void GetLeafs(Tree<T>tree,List<Tree<T>>leafs)
        {
            if (tree.children.Count == 0)
            {
                leafs.Add(tree);
            }
            foreach (var child in tree.children)
            {
                GetLeafs(child,leafs);
            }
        }

        public IEnumerable<T> GetLongestPath()
        {
            Stack<T> longestPath = new Stack<T>();

            Tree<T> deepestNode = findDeepestNode();

            while (deepestNode != null)
            {
                longestPath.Push(deepestNode.Key);
                deepestNode = deepestNode.Parent;
            }

            return longestPath;
        }
    }
}
