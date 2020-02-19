namespace CodeChallenges.Arrays
{
    public class FindMissingNum
    {
        public class Solution
        {
            public int MissingNumber(int[] nums)
            {
                int iResult = 0;
                int result = 0;
                // [0,1,2,3,4]  = 10 if numbers add up then the answer is zero.
                // [0,2,3,4] = 9
                for (int i = 0; i < nums.Length; i++)
                {
                    iResult += i;
                    result += nums[i];
                }

                iResult += nums.Length;
                return iResult - result;
            }
        }
    }
}