namespace CodeChallenges.Arrays
{
    public class MoveZero
    {
        public void MoveZeroes(int[] nums)
        {
            if (nums == null || nums.Length <= 1) return;

            int zeroFinder = 0;
            int nonZeroFinder = zeroFinder + 1;

            while (zeroFinder < nums.Length - 1)
            {
                while (zeroFinder < nums.Length - 1 && nums[zeroFinder] != 0)
                {
                    zeroFinder++;
                }

                if (nums[zeroFinder] == 0)
                {
                    nonZeroFinder = zeroFinder;
                }

                while (nonZeroFinder < nums.Length - 1 && nums[nonZeroFinder] == 0)
                {
                    nonZeroFinder++;
                }

                if (nums[nonZeroFinder] == 0)
                {
                    break;
                }

                if (nums[zeroFinder] == 0)
                {
                    nums[zeroFinder] = nums[nonZeroFinder];

                    nums[nonZeroFinder] = 0;
                }
            }
        }
    }
}