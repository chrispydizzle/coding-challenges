namespace CodeChallenges.DynamicProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaxSubarrayProduct
    {
        // TODO: Find simpler solution.
        public int MaxProduct(int[] nums)
        {
            List<int> alternates = new List<int>();
            if (nums.Length == 1) return nums.First();

            List<int> dedupe = new List<int>();
            int initCount = nums.Length + 1;
            while (nums.Length < initCount)
            {
                initCount = nums.Length;

                for (int i = 0; i < nums.Length - 1; i++)
                {
                    int val = nums[i];
                    int nextVal = nums[i + 1];
                    if ((val == 1 && nextVal == 1))
                    {
                        continue;
                    }

                    if (val == -1 && nextVal == -1)
                    {
                        dedupe.Add(1);
                        i++;
                        continue;
                    }

                    if (val == 1 && nextVal == -1)
                    {
                    }
                    else
                    {
                        dedupe.Add(nums[i]);
                    }
                }

                dedupe.Add(nums[nums.Length - 1]);
                nums = dedupe.ToArray();
                dedupe.Clear();
            }

            // holds the max product we've found.
            int maxProduct = nums[0];

            alternates.Add(nums[0]);

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    alternates.Add(0);
                }

                if (nums[i] == 0)
                {
                    alternates.Add(0);
                }

                for (int j = 0; j < alternates.Count; j++)
                {
                    alternates[j] *= nums[i];
                }

                // store a value if we would have dropped down to the current index
                if (nums[i] <= 0 || (alternates.Max() < 1 && nums[i] > 1))
                {
                    alternates.Add(nums[i]);
                }


                // if candidate wound up larger than currentProduct, set that up
                maxProduct = Math.Max(Math.Max(alternates.Any() ? alternates.Max() : int.MinValue, maxProduct), nums.Max());
            }

            return maxProduct;
        }
    }
}