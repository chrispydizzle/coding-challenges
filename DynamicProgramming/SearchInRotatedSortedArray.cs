namespace CodeChallenges.DynamicProgramming
{
    using System;

    public class SearchInRotatedSortedArray
    {
        public int Search(int[] nums, int target)
        {
            // find pivot, then do binary
            int pivotIndex = FindPivot(nums, 0, nums.Length - 1, 0);

            if (target <= nums[nums.Length - 1]) return DoBinaryWithPivot(nums, pivotIndex, nums.Length - 1, target);

            return DoBinaryWithPivot(nums, 0, pivotIndex - 1, target);
        }

        private int DoBinaryWithPivot(int[] array, int startIndex, int endIndex, int target)
        {
            // check if current number is target, or if there are two check them
            if (array[startIndex] == target) return startIndex;

            if (startIndex == endIndex || Math.Abs(startIndex - endIndex) == 1)
            {
                if (target == array[startIndex]) return startIndex;
                if (endIndex != -1 && target == array[endIndex]) return endIndex;

                return -1;
            }

            // otherwise, find midpoint and seek it
            int middleIndex = startIndex + (endIndex - startIndex) / 2;

            int middle = array[middleIndex];

            if (target == middle) return middleIndex;
            return target < middle
                ? DoBinaryWithPivot(array, startIndex, middleIndex, target)
                : DoBinaryWithPivot(array, middleIndex, endIndex, target);

            // otherwise go to the middle and binary both sides until you hit the target
        }

        private int FindPivot(int[] array, int startSeek, int stopSeek, int smallest)
        {
            if (startSeek == stopSeek || Math.Abs(startSeek - stopSeek) == 1)
            {
                if (array[startSeek] < array[stopSeek])
                {
                    // we're down to two values, let's get the smallest one
                    if (array[startSeek] < array[smallest]) return startSeek;
                }
                else
                {
                    if (array[stopSeek] < array[smallest]) return stopSeek;
                }

                return smallest;
            }

            int start = array[startSeek];
            int end = array[stopSeek];

            int smallNumber = array[smallest];
            if (start < end)
            {
                // we are not in a pivoted section, return startIndex
                if (start < smallNumber) return startSeek;

                return smallest;
            }

            int midPoint = startSeek + (stopSeek - startSeek) / 2;
            int val = FindPivot(array, startSeek, midPoint, smallest);
            if (array[val] < smallNumber)
            {
                smallest = val;
                smallNumber = array[val];
            }

            int val2 = FindPivot(array, midPoint, stopSeek, smallest);
            if (array[val2] < smallNumber) return val2;

            return smallest;
        }
    }
}