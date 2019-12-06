namespace CodeChallenges.LinkedList
{
    public class AddLinkedListNumbers
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int value = l1.val + l2.val;
            int carryOver = 0;

            if (value >= 10)
            {
                value = value % 10;
                carryOver = 1;
            }

            ListNode rootNode = new ListNode(value);

            ListNode newL1 = l1;
            ListNode newL2 = l2;

            ListNode currentNode = rootNode;

            while (newL1.next != null || newL2.next != null)
            {
                newL1 = newL1.next ?? new ListNode(0);
                newL2 = newL2.next ?? new ListNode(0);

                int result = newL1.val + newL2.val + carryOver;

                carryOver = 0;

                if (result >= 10)
                {
                    result = result % 10;
                    carryOver = 1;
                }

                currentNode.next = new ListNode(result);
                currentNode = currentNode.next;
            }

            if (carryOver > 0)
            {
                currentNode.next = new ListNode(carryOver);
            }

            return rootNode;
        }
    }
}