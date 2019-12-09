namespace CodeChallenges.Graphs
{
    using System.Collections.Generic;
    using UndirectedGrahNode = Node;
    public class UndirectedCloneGraph
    {
        public Node CloneGraph(Node node)
        {
            Dictionary<Node, Node> foundAlready = new Dictionary<Node, Node>();
            return CloneGraph(node, foundAlready);
        }

        public Node CloneGraph(Node n, Dictionary<Node, Node> foundAlready)
        {
            if (foundAlready.ContainsKey(n)) return foundAlready[n];

            Node newNode = new Node(n.val, null);
            foundAlready[n] = newNode;
            List<Node> nn = new List<Node>();
            foreach (Node partner in n.neighbors)
            {
                if (foundAlready.ContainsKey(partner))
                {
                    nn.Add(foundAlready[partner]);
                }
                else
                {
                    nn.Add(CloneGraph(partner, foundAlready));
                }
            }

            newNode.neighbors = nn;
            return newNode;
        }
    }
}