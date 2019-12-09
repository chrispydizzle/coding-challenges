namespace CodeChallenges.LinkedList
{
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
    }
}