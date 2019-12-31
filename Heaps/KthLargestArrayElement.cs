namespace CodeChallenges.Heaps
{
    using System;

    public class KthLargestArrayElement
    {
        public int FindKthLargest(int[] nums, int k)
        {
            Array.Sort(nums);

            return nums[nums.Length - k];
        }
    }
}