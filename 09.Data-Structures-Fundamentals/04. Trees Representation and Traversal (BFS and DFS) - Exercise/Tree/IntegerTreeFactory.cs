namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public IntegerTreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (var inputLine in input)
            {
                int[] pnc = inputLine.Split(' ').Select(int.Parse).ToArray();
                int parent = pnc[0];
                int child = pnc[1]; 

                AddEdge(parent, child);
            }
            return GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            if (!nodesByKey.ContainsKey(key))
            {
                nodesByKey.Add(key, new IntegerTree(key));
            }
            return nodesByKey[key];
        }

        public void AddEdge(int parent, int child)
        {
           IntegerTree parentNode =CreateNodeByKey(parent);
            IntegerTree childNode = CreateNodeByKey(child);

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);
        }

        public IntegerTree GetRoot()
        {
            foreach (var kvp in nodesByKey)
            {
                if(kvp.Value.Parent is null)
                {
                    return kvp.Value;
                }
            }
            return null;
        }
    }
}
