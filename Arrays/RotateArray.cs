namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;

    /// <summary>
    ///     Rotates a single dimension array's values by a specified amount
    /// </summary>
    public class RotateArray
    {
        // TODO: InPlace
        public void Rotate(int[] nums, int k)
        {
            List<int> newList = new List<int>(nums);

            for (int i = 0; i < newList.Count; i++)
            {
                int position = i + k;
                if (position >= nums.Length)
                {
                    position = position % nums.Length;
                }

                nums[position] = newList[i];
            }
        }
    }
}