namespace CodeChallenges.Arrays
{
    using LinkedList;

    public class MergeTwoSortedLists
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode result = null;
            if (l1 == null && l2 == null) return result;
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val <= l2.val)
            {
                result = l1;
                l1 = l1.next;
            }
            else
            {
                result = l2;
                l2 = l2.next;
            }

            ListNode cNode = result;
            while (l1 != null || l2 != null)
            {
                if ((l2 != null && l1 == null) || (l1 != null && l2 != null && l2.val < l1.val))
                {
                    cNode.next = l2;
                    l2 = l2.next;
                }
                else
                {
                    cNode.next = l1;
                    l1 = l1.next;
                }

                cNode = cNode.next;
            }


            return result;
        }
    }
}