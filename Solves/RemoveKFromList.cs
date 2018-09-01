namespace Pdrome2.Solves
{
    internal class RemoveKFromList
    {
        public ListNode<int> removeKFromList(ListNode<int> l, int k)
        {
            ListNode<int> nextValue = l;
            if (nextValue == null) return null;
            if (nextValue.next == null)
            {
                if (nextValue.value == k) return null;

                return nextValue;
            }

            if (l.value == k)
            {
                nextValue = this.removeKFromList(l.next, k);
            }
            else
            {
                nextValue.next = this.removeKFromList(l.next, k);
            }

            return nextValue;
        }

    }
}