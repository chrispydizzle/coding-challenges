namespace Pdrome2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Clones a graph  from a root node.
    /// TODO: Looks like I could have probably used recursion here to make this infinitely easier to read
    /// </summary>
    public class UndirectedGraphNode
    {
        public void Main(string[] args)
        {
            UndirectedGraphNode zero = new UndirectedGraphNode(0);
            UndirectedGraphNode one = new UndirectedGraphNode(1);
            UndirectedGraphNode two = new UndirectedGraphNode(2);
            zero.neighbors.Add(one);
            zero.neighbors.Add(two);

            one.neighbors.Add(two);

            two.neighbors.Add(two);

            UndirectedGraphNode clone = UndirectedGraphNode.CloneGraph(zero);
            Console.WriteLine(clone);
        }

        public int label { get; set; }
        public IList<UndirectedGraphNode> neighbors { get; set; }

        public UndirectedGraphNode(int x)
        {
            this.label = x;
            this.neighbors = new List<UndirectedGraphNode>();
        }

        public static UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
        {
            if (node == null) return null;

            Stack<Tuple<UndirectedGraphNode, IList<UndirectedGraphNode>>> gnStack = new Stack<Tuple<UndirectedGraphNode, IList<UndirectedGraphNode>>>();
            Dictionary<int, UndirectedGraphNode> visited = new Dictionary<int, UndirectedGraphNode>();

            UndirectedGraphNode rootNode = new UndirectedGraphNode(node.label);
            gnStack.Push(new Tuple<UndirectedGraphNode, IList<UndirectedGraphNode>>(rootNode, node.neighbors));
            visited.Add(rootNode.label, rootNode);

            while (gnStack.Count > 0)
            {
                Tuple<UndirectedGraphNode, IList<UndirectedGraphNode>> tuple = gnStack.Pop();
                if (tuple.Item2 == null) continue;

                foreach (UndirectedGraphNode undirectedGraphNode in tuple.Item2)
                {
                    if (!visited.ContainsKey(undirectedGraphNode.label))
                    {
                        UndirectedGraphNode nNode = new UndirectedGraphNode(undirectedGraphNode.label);
                        tuple.Item1.neighbors.Add(nNode);
                        visited.Add(undirectedGraphNode.label, nNode);
                        gnStack.Push(new Tuple<UndirectedGraphNode, IList<UndirectedGraphNode>>(nNode, undirectedGraphNode.neighbors));
                    }
                    else
                    {
                        tuple.Item1.neighbors.Add(visited[undirectedGraphNode.label]);
                    }
                }
            }

            return rootNode;
        }
    }
}