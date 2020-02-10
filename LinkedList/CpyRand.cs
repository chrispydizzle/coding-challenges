namespace CodeChallenges.LinkedList.Smh
{
    using System.Collections.Generic;
    using Node = LinkedList.RandomNode;

    public class CpyRand
    {
        private readonly Dictionary<Node, Node> d = new Dictionary<Node, Node>();

        public Node CopyRandomList(Node head)
        {
            var root = new Node(-1);
            var n = head;
            var nn = root;

            // traverse once grabbing all the nexts
            while (n != null)
            {
                Node r = null;
                if (n.random != null)
                {
                    if (!d.ContainsKey(n.random))
                    {
                        r = new Node(n.random.val);
                        d[n.random] = r;
                    }
                    else
                    {
                        r = d[n.random];
                    }
                }


                if (!d.ContainsKey(n))
                {
                    d.Add(n, new Node(n.val));
                }

                Node xN = d[n];
                xN.random = r;

                nn.next = xN;
                nn = nn.next;

                n = n.next;
            }

            return root.next;
        }
    }
}