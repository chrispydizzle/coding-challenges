namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;

    internal class ContainsDuplicates
    {
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> hs = new HashSet<int>();
            if (nums == null) return false;
            foreach (int num in nums)
            {
                if (hs.Contains(num)) return true;

                hs.Add(num);
            }

            return false;
        }
    }
}