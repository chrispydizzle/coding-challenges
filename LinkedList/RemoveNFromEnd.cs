namespace CodeChallenges
{
    using LinkedList;

    public class RemoveNFromEnd
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            // create an artifical start node to handle single item linked list.
            ListNode start = new ListNode(0);

            ListNode preNode = start, postNode = start;
            preNode.next = head;

            // Move postNode n places ahead
            for (int i = 0; i <= n; i++)
            {
                postNode = postNode.next;
            }

            // go to end
            while (postNode != null)
            {
                preNode = preNode.next;
                postNode = postNode.next;
            }

            // replace prenode with next next
            preNode.next = preNode.next.next;
            return start.next;
        }
    }
}