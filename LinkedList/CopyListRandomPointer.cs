namespace CodeChallenges.LinkedList
{
    using System.Collections.Generic;

    public class CopyListWithRandomPointer
    {
        public Node CopyRandomList(Node node)
        {
            Dictionary<Node, Node> set = new Dictionary<Node, Node>();

            Node root = this.CopyRandomList(node, set);
            return root;
        }

        public Node CopyRandomList(Node node, Dictionary<Node, Node> visited)
        {
            if(node == null) return null;
            Node newNode = new Node(node.val, null, null);
            if (visited.ContainsKey(node))
            {
                return visited[node];
            }

            

            visited[node] = newNode;

            newNode.next = this.CopyRandomList(node.next, visited);
            newNode.random = this.CopyRandomList(node.random, visited);
            return newNode;
        }
    }
}