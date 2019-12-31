namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;

    public class TwoSumSolve
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numHash = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int difference = target - nums[i];
                if (numHash.ContainsKey(difference)) return new[] {i, numHash[difference]};

                if (!numHash.ContainsKey(nums[i])) numHash.Add(nums[i], i);
            }

            return new int[] { };
        }
    }
}