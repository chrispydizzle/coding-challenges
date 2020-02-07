namespace CodeChallenges.Arrays
{
    using LinkedList;

    public class LLSum
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode root = new ListNode(0);
            ListNode cN = new ListNode(0);
            cN.next = root;

            int carry = 0;
            while (l1 != null || l2 != null)
            {
                cN = cN.next;
                int lVal = 0;
                if (l1 != null)
                {
                    lVal = l1.val;
                    l1 = l1.next;
                }

                int rVal = 0;
                if (l2 != null)
                {
                    rVal = l2.val;
                    l2 = l2.next;
                }

                int result = lVal + rVal + carry;
                carry = 0;

                if (result > 9)
                {
                    carry = result / 10;
                    result = result % 10;
                }

                cN.val = result;
                cN.next = new ListNode(0);
            }

            if (carry > 0) cN.next.val = carry;
            else cN.next = null;
            return root;
        }
    }

    public class ProdNotMe
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            // without considering space complexity for a minute, can do this fairly easy.
            // just for the loop once, and at each step you fan out and multiply to the other end as in:
            int[] leftways = new int[nums.Length + 1];
            int[] rightways = new int[nums.Length + 1];
            //for 1 of [1,2,3,4]{
            //
            leftways[nums.Length] = 1;
            rightways[0] = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                leftways[nums.Length - i - 1] = nums[nums.Length - i - 1] * leftways[nums.Length];
                rightways[i + 1] = nums[i] * rightways[i];
            }

            return null;
        }
    }
}