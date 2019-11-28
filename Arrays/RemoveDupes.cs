namespace CodeChallenges.Strings
{
    internal class RemoveDupes
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            int placement = 0;
            int oldNumber = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                int currentNumber = nums[i];

                if (currentNumber != oldNumber)
                {
                    nums[placement] = oldNumber;
                    oldNumber = currentNumber;
                    placement++;
                }

                if (i == nums.Length - 1)
                {
                    nums[placement] = oldNumber;
                    oldNumber = currentNumber;
                }
            }

            return placement + 1;
        }
    }
}