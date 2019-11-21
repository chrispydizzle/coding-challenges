namespace CodeChallenges
{
    using LinkedList;

    public class DeleteLinkedListNode
    {
        public void DeleteNode(ListNode node)
        {
            this.ReplaceNode(node, node.next);
        }

        private void ReplaceNode(ListNode node, ListNode nodeNext)
        {
            node.val = nodeNext.val;

            if (nodeNext.next == null)
            {
                node.next = null;
                return;
            }

            this.ReplaceNode(nodeNext, nodeNext.next);
        }
    }
}