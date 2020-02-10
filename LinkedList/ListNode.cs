namespace CodeChallenges.LinkedList
{
    using System.Text;

    // Definition for singly-linked list.
    public class ListNode
    {
        public ListNode next;
        public int val;


        public ListNode(int x)
        {
            this.val = x;
        }

        public static ListNode Make(params int[] args)
        {
            ListNode root = new ListNode(args[0]);
            ListNode next = root;
            for (int i = 1; i < args.Length; i++)
            {
                ListNode newNode = new ListNode(args[i]);
                next.next = newNode;
                next = next.next;
            }

            return root;
        }

        public static ListNode[] MakeRange(params int[][] args)
        {
            ListNode[] ln = new ListNode[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                int[] ints = args[i];
                ln[i] = ListNode.Make(ints);
            }

            return ln;
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.Append($"{this.val} => ");
            ListNode next = this.next;
            while (next != null)
            {
                b.Append($"{next.val} => ");
                next = next.next;
            }

            b.Append($"# ");
            return b.ToString();
        }
    }
}