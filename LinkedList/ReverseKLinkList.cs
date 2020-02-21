namespace CodeChallenges.LinkedList
{
    public class ReverseKLinkList
    {
        // can we solve this recursively? That might be int
        // eresting.
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            return head;
        }

        /*public ListNode OneReverseKGroup(ListNode head, int k)
        {
            // 1->2->3->4->5
            // 2->1->4->3->5 (2)
            // 3->2->1->4->5 (3)
            // Constant extra memory.

            // so how? we hold a pointer to the 0th of k-1 nodes and the previous node (a throwawy node for our root) ie:
            ListNode newRoot = head;
            ListNode c = head;
            // int moved = 0;


            // let's use a stack, ya?
            Stack<ListNode> st = new Stack<ListNode>();
            ListNode tempNewRoot = head;
            while (c != null)
            {
                if (st.Count() == k && globalFirst || st.Count == k + 1)
                {
                    //      if moved == k
                    //      1->2->3->4->5 -> Stack (3->4,2->3,1->2) & c(4->5)

                    // empty the stack,
                    ListNode ln = st.Pop();

                    if (first)
                    {
                        first = false;
                        tempNewRoot = ln;
                    }

                    if (globalFirst)
                    {
                        globalFirst = false;
                        newRoot = tempNewRoot;
                    }

                    while (st.Any())
                    {
                        // set s.next to the node that comes out of the stack
                        ln.next = st.Pop();

                        ln = ln.next;
                    }

                    // stack is empty, point the last s to c
                    ln.next = c;
                    st.Push(c);

                    // reset moved
                }
                else
                {
                    // stack c, set c to c.next
                    st.Push(c);
                    c = c.next;
                }
            }

            // don't need to do anything. The stack has leftover junk that the GC will clear
            return newRoot;
        }*/
    }
}