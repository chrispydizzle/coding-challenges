namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;

    public class SubarraySumK
    {
        public int SubarraySumSlow(int[] nums, int k)
        {
            // this naive approach is accepted but I can tell there's a better way
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int target = k;
                for (int j = i; j < nums.Length; j++)
                {
                    target -= nums[j];
                    if (target == 0)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        public int SubarraySum(int[] nums, int k)
        {
            // as with the naive approach, we set some variables to track our successes.
            int result = 0;
            int sum = 0;

            // this dictionary is the key to avoiding more than one pass.
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                // add the current number i to our running total
                sum += nums[i];

                if (sum == k)
                {
                    // found the number we sought, make a note.
                    result++;
                }

                // have we seen a subarray sum that would match what we need?
                if (dict.ContainsKey(sum - k))
                {
                    result += dict[sum - k];
                }

                // the magic is here.
                // by recording as we go, the current sum value and how many times we've already seen it, the next
                // time we loop, and find an number that has a difference of sum we can be sure that it would have been a match, just as if we'd
                // gone through the array a second time.
                dict[sum] = dict.ContainsKey(sum) ? dict[sum] + 1 : 1;
                // also, I didn't know you could just create dictionary keys like this.
            }


            return result;
        }
    }
}