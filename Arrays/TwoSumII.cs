namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;

    public class TwoSumII
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            // not really different than twosum except that we need to focus on the indices.
            var differences = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];
                if (differences.ContainsKey(num))
                {
                    return new int[] {differences[num] + 1, i + 1};
                }

                int dkey = target - num;
                differences[dkey] = i;
            }

            return null;
        }
    }
}