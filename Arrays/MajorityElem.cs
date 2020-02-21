namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;

    public class MajorityElem
    {
        public int MajorityElement(int[] nums)
        {
            int majnum = nums.Length / 2;
            if (nums.Length % 2 != 0) majnum++;
            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!d.ContainsKey(nums[i]))
                {
                    d.Add(nums[i], 0);
                }

                d[nums[i]]++;
                if (d[nums[i]] >= majnum) return nums[i];
            }

            return 0;
        }
    }
}