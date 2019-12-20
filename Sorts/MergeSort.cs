namespace CodeChallenges.Sorts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSort
    {
        public IList<int> SortArray(int[] nums)
        {
            List<int> result = new List<int>();
            var resultArray = DoMergeSort(nums);
            return resultArray.ToList();
        }

        private int[] DoMergeSort(int[] input)
        {
            // our recursion stop-point: have one item.

            if (input.Length <= 1) return input;

            int midPoint = input.Length / 2;

            int[] leftHalf = new int[midPoint];
            int[] rightHalf = new int[input.Length - midPoint];

            // split the input in half
            Array.Copy(input, 0, leftHalf, 0, midPoint);
            Array.Copy(input, midPoint, rightHalf, 0, input.Length - midPoint);

            leftHalf = DoMergeSort(leftHalf);
            rightHalf = DoMergeSort(rightHalf);

            return DoMergeSort(leftHalf, rightHalf);
        }

        private int[] DoMergeSort(int[] leftHalf, int[] rightHalf)
        {
            // create a new list that is the size of left and right
            int[] sortedList = new int[leftHalf.Length + rightHalf.Length];

            int leftPointer = 0, rightPointer = 0, targetPointer = 0;

            // cycle through the lists, slotting the results into our sorted list when appropriate 
            while (leftPointer < leftHalf.Length && rightPointer < rightHalf.Length)
            {
                if (leftHalf[leftPointer] < rightHalf[rightPointer])
                {
                    // left side pointer is lower than current right side- insert left side value into sorted list.
                    sortedList[targetPointer] = leftHalf[leftPointer];

                    // move target pointer and left pointer
                    targetPointer++;
                    leftPointer++;
                }
                else
                {
                    // left side is greater or equal to right side - insert right side value into sorted list
                    sortedList[targetPointer] = rightHalf[rightPointer];

                    // move target pointer and right pointer
                    targetPointer++;
                    rightPointer++;
                }
            }

            // we've reached the end of one of the lists-  so let's append the value of the remianing list to the end of our result
            while (leftPointer < leftHalf.Length)
            {
                sortedList[targetPointer] = leftHalf[leftPointer];
                targetPointer++;
                leftPointer++;
            }

            while (rightPointer < rightHalf.Length)
            {
                sortedList[targetPointer] = rightHalf[rightPointer];
                targetPointer++;
                rightPointer++;
            }

            return sortedList;
        }
    }
}