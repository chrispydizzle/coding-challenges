namespace CodeChallenges.LinkedList
{
    using System;
    using System.Linq;

    public class MergeMultipleLinkedLists
    {
        // TODO: Suboptimal, could have just done them two at a time
        public ListNode MergeKLists(ListNode[] lists)
        {
            // first things first, how do we solve this?
            if (lists == null || lists.Length == 0) return null;
            lists = lists.Where(l => l != null).ToArray();

            if (lists.Length == 0) return null;

            int[] valArray = lists.Select(l => l.val).ToArray();
            Array.Sort(valArray, lists);
            // I believe the solution will involve recursion, but what's our base case?
            // ANS: when all lists have been fully traversed
            ListNode root = lists.FirstOrDefault(r => r.val == lists.Min(l => l.val));
            if (root == null) return null;

            return this.MergeKLists(lists.Where(l => l != root).ToArray(), root);
        }

        public ListNode MergeKLists(ListNode[] lists, ListNode node)
        {
            // lists is the list of linked lists we want to append to it.
            // what happens when lists is empty?

            if (lists.Length == 0) return node;
            // node is our current root node

            if (node.next != null)
            {
                var l = lists.ToList();
                l.Add(node.next);
                lists = l.ToArray();
                node.next = null;

                int[] valArray = lists.Select(ln => ln.val).ToArray();
                Array.Sort(valArray, lists);
            }


            ListNode nextNode = lists[0];
            var nList = new ListNode[lists.Length - 1];
            Array.Copy(lists, 1, nList, 0, nList.Length);
            node.next = this.MergeKLists(nList, nextNode);
            return node;
        }
    }
}