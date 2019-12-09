namespace CodeChallenges.LinkedList
{
    public class Node
    {
        public Node next;
        public Node random;
        public int val;

        public Node()
        {
        }

        public Node(int _val, Node _next, Node _random)
        {
            this.val = _val;
            this.next = _next;
            this.random = _random;
        }
    }
}