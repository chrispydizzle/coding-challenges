namespace CodeChallenges.Solves
{
    internal class IsListPalindrome
    {
        public bool isListPalindrome(ListNode<int> l)
        {
            // if we get an empty or single-item list, it is true.
            if (l?.next == null) return true;

            // otherwise, send the start point, and the two next items into a recursive function
            ListNode<int> head = l;
            ListNode<int> currentPointer = head.next;

            return this.Verify(head, currentPointer, currentPointer.next);
        }

        private bool Verify(ListNode<int> head, ListNode<int> previousPointer, ListNode<int> currentPointer)
        {
            // if there is a next pointer
            if (currentPointer.next != null)
            {
                return this.Verify(head, currentPointer, currentPointer.next);
            }

            //if not, start rolling back
            if (head.value == currentPointer.value)
            {
                if (head.next == null) return true;
                previousPointer.next = null;
                return this.Verify(head.next, previousPointer, previousPointer);
            }

            return false;
            // return this.Verify(head);
        }
    }
}