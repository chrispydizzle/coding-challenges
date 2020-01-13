namespace CodeChallenges.Sorts
{
    using System;

    public class FindFirstLastinSortedArray
    {
        public int[] SearchRange(int[] nums, int target)
        {
            // sorted array, let's do a binary search!

            if (nums == null || nums.Length == 0) return new[] {-1, -1};

            int[] result = {-1, -1};

            int middle = nums.Length / 2;
            bool stop = false;
            int topHalfMod = 0;
            while (result[0] == -1 && result[1] == -1 && !stop)
            {
                int current = nums[middle];
                // three possibilities:

                // 1- we hit the number
                if (current == target)
                {
                    result[0] = middle;
                    result[1] = middle;

                    // first left
                    int pointer = middle - 1;
                    while (pointer >= 0 && nums[pointer] == target)
                    {
                        result[0] = pointer;
                        pointer--;
                    }

                    // now right
                    pointer = middle + 1;
                    while (pointer < nums.Length && nums[pointer] == target)
                    {
                        result[1] = pointer;
                        pointer++;
                    }

                    result[0] += topHalfMod;
                    result[1] += topHalfMod;

                    // then ret the val
                    return result;
                }

                if (middle == 0) return result;
                // create an array that will fit the half of the array we're going to seek next
                int[] tempArray = new int[middle];

                // 2 - we're above the number
                if (current > target)
                {
                    // take the bottom half of the array
                    Array.Copy(nums, 0, tempArray, 0, tempArray.Length);
                    nums = tempArray;
                }
                // 3 - we're below the number
                else if (current < target)
                {
                    topHalfMod += middle + nums.Length % 2;
                    if (middle + 1 >= nums.Length) return result;
                    // take the top half of the array
                    Array.Copy(nums, middle + nums.Length % 2, tempArray, 0, tempArray.Length);
                    nums = tempArray;
                }

                middle = nums.Length / 2;
                if (middle == 1 && nums[middle] != target && nums.Length <= 1) stop = true;
            }

            return result;
        }
    }
}