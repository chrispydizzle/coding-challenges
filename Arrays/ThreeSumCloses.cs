namespace CodeChallenges.Arrays
{
    using System;

    public class ThreeSumCloses
    {
        // Two pointers - sort the list and work our way in, until we stop getting closer.
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            // [-1, 2, 1, -4] = [-4,-1,2,1]
            int closest = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                int l = i + 1;
                int r = nums.Length - 1;
                while (l < r)
                {
                    int currentSum = nums[i] + nums[l] + nums[r];
                    if (currentSum == target)
                    {
                        return currentSum;
                    }
                    else if (currentSum < target)
                    {
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                    // -4 + -1 + 1 = Abs(-4 - (1)) = 5

                    if (closest == int.MaxValue || Math.Abs(target - currentSum) < Math.Abs(target - closest))
                    {
                        closest = currentSum;
                    }
                }
            }

            return closest;
        }
    }
}