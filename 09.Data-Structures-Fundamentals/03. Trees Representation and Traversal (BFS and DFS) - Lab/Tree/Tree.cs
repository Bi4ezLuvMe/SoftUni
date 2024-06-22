namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Security;

    public class Tree<T> : IAbstractTree<T>
    {
        List<Tree<T>> children;
        T value;
        Tree<T> parent;
        public Tree(T value)
        {
            this.value = value;
            children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> node = FindNodeByKeyWithBFS(parentKey);

            if(node is null)
            {
                throw new ArgumentNullException();
            }
            child.parent = node;
            node.children.Add(child);
        }
        Tree<T> FindNodeByKeyWithBFS(T key)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> current = queue.Dequeue();
                if (current.value.Equals(key))
                {
                    return current;
                }
                foreach (var child in current.children)
                {
                    queue.Enqueue(child);
                }
            }
            return null;
        }

        Tree<T> FindNodeByKeyWithDFS(T key)
        {
            Stack<Tree<T>> stack = new Stack<Tree<T>>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                Tree<T> current = stack.Pop();
                if(current.value.Equals(key))
                {
                    return current;
                }
                foreach (var child in current.children)
                {
                    stack.Push(child);
                }
            }
            return null;
        }
        public IEnumerable<T> OrderBfs()
        {
            List<T> result = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T>current = queue.Dequeue();
                result.Add(current.value);

                foreach (var child in current.children)
                {
                    queue.Enqueue(child);
                }
            }
            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            Stack<T> result = new Stack<T>();
            Stack<Tree<T>>stack  = new Stack<Tree<T>>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                Tree<T> current = stack.Pop();
                result.Push(current.value);
                foreach (var child in current.children)
                {
                    stack.Push(child);
                }
            }
            return result;
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> node = FindNodeByKeyWithDFS(nodeKey);

            if(node is null)
            {
                throw new ArgumentNullException();
            }else if(node.parent is null)
            {
                throw new ArgumentException();
            }

            node.parent.children.Remove(node);
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstNode = FindNodeByKeyWithBFS(firstKey);
            Tree<T> secondNode = FindNodeByKeyWithBFS(secondKey);

            if(firstNode is null || secondNode is null)
            {
                throw new ArgumentNullException();
            }

            Tree<T>firstParent = firstNode.parent;
            Tree<T>secondParent = secondNode.parent;   
            
            if (firstParent == null || secondParent == null)
            {
                throw new ArgumentException();
            }

            int indexOfFirstChild = firstParent.children.IndexOf(firstNode);
            int indexOfSecondChild = secondParent.children.IndexOf(secondNode);

            firstParent.children[indexOfFirstChild] = secondNode;
            secondNode.parent = firstParent;

            secondParent.children[indexOfSecondChild] = firstNode;
            firstNode.parent = secondParent;

        }
    }
}
