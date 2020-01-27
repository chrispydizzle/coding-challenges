namespace CodeChallenges.Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HouseRobber
    {
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            int result = this.RobFrom(nums, Enumerable.Repeat(0, nums.Length).ToArray(), 0, 0);
            for (int i = 1; i < jumpLists.Count; i++)
            {
                result = Math.Max(result, jumpLists[i].Max());
            }

            return result;
        }

        Dictionary<int, HashSet<int>> jumpLists = new Dictionary<int, HashSet<int>>();

        private int RobFrom(int[] n, int[] nb, int si, int val)
        {
            if (!jumpLists.ContainsKey(si)) jumpLists[si] = new HashSet<int>();

            int sum = nb[si] = n[si];
            jumpLists[si].Add(sum);
            if (!(si < n.Length - 1)) return sum;

            int i = si + 1;
            while (i < nb.Length)
            {
                int bVal = !jumpLists.ContainsKey(i) ? this.RobFrom(n, nb, i, 0) : jumpLists[i].Max();
                if (i > si + 1)
                {
                    jumpLists[si].Add(sum + bVal);
                }

                i++;
            }

            return jumpLists[si].Max();
        }
    }
}