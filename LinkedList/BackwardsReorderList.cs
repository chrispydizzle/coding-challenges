namespace CodeChallenges.LinkedList
{
    using System.Collections.Generic;

    public class BackwardsReorderList
    {
        public void ReorderList(ListNode head)
        {
            if (head == null) return;
            // go through the ll and find the end.
            bool pass = true;
            ListNode currentNode = head;
            ListNode newParent = null;
            Stack<ListNode> nodes = new Stack<ListNode>();

            ListNode traverseNode = head;
            while (traverseNode != null)
            {
                nodes.Push(traverseNode);
                traverseNode = traverseNode.next;
            }

            int counter = 0;
            int max = nodes.Count / 2;

            HashSet<ListNode> added = new HashSet<ListNode>();

            while (currentNode != null && counter < max)
            {
                ListNode newChild = nodes.Pop();
                counter++;
                newParent = currentNode;
                added.Add(newParent);
                added.Add(newChild);
                currentNode = currentNode.next;
                newParent.next = newChild;
                newChild.next = currentNode;
                if (!added.Contains(nodes.Peek()))
                {
                    ListNode oldParent = nodes.Pop();
                    oldParent.next = null;
                    nodes.Push(oldParent);
                }
            }

            currentNode.next = null;
        }
    }
}