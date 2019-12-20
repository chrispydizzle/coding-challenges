namespace CodeChallenges.DynamicProgramming
{
    using System;

    public class MaximumSubArray
    {
        public int MaxSubArray(int[] nums)
        {
            int n = nums.Length, maxSum = nums[0];

            for (int i = 1; i < n; ++i)
            {
                // so, since adding negative numbers can't be helpful, we only attempt to add current value to a prior sum if the number is > 0 
                int prevNum = nums[i - 1];
                if (prevNum > 0)
                {
                    // store the current value in the array, so we can keep adding to it as we go forward.
                    nums[i] += prevNum;
                }

                // define the max sum, which is the current value of nums[i] (previous + current number) or the max that we've already seen
                maxSum = Math.Max(nums[i], maxSum);
            }

            return maxSum;
        }
    }
}