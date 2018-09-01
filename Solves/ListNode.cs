namespace Pdrome2.Solves
{
    internal class ListNode<T>
    {
        public ListNode(T value)
        {
            this.value = value;
        }

        public ListNode(params T[] values)
        {
            ListNode<T> head = new ListNode<T>(values[0]);
            ListNode<T> nextNode = head;
            for (int i = 1; i < values.Length; i++)
            {
                ListNode<T> listNode = new ListNode<T>(values[i]);
                nextNode.next = listNode;
                nextNode = listNode;
            }

            this.value = head.value;
            this.next = head.next;
        }

        public T value { get; set; }
        public ListNode<T> next { get; set; }
    }
}