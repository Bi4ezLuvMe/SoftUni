namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            var pathsWithGivenSum = new List<List<int>>();
            var currentPath = new List<int>();
            DFSfindAllPathsWithGivenSum(this, sum, 0, currentPath, pathsWithGivenSum);
            return pathsWithGivenSum;
        }

        private void DFSfindAllPathsWithGivenSum(IntegerTree tree, int sum, int currentSum, List<int> currentPath, List<List<int>> pathsWithGivenSum)
        {
            currentPath.Add(tree.Key);
            currentSum += tree.Key;
            
            if (tree.Children.Count == 0)
            {
                
                if (currentSum == sum)
                {
                    pathsWithGivenSum.Add(new List<int>(currentPath));
                }
            }
            else
            {
                foreach (var child in tree.Children)
                {
                    DFSfindAllPathsWithGivenSum((IntegerTree)child, sum, currentSum, currentPath, pathsWithGivenSum);
                }
            }

            currentPath.RemoveAt(currentPath.Count - 1);
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            List<Tree<int>>subtreesWithGivenSum = new List<Tree<int>>();
            BFSfindSubtreesWithGivenSum(subtreesWithGivenSum, this, sum);
            return subtreesWithGivenSum;
        }

        private void BFSfindSubtreesWithGivenSum(List<Tree<int>> subtreesWithGivenSum, IntegerTree tree, int sum)
        {
           Queue<Tree<int>>queue = new Queue<Tree<int>>();
            queue.Enqueue(tree);

            while(queue.Count > 0) 
            {
                Tree<int>current = queue.Dequeue();
                if (GetSubtreeSum(current) == sum)
                {
                    subtreesWithGivenSum.Add(current);
                }
                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        private int GetSubtreeSum(Tree<int> current)
        {
            int sum = current.Key;
            foreach (var child in current.Children)
            {
                sum += GetSubtreeSum(child);
            }
            return sum;
        }
    }
}
