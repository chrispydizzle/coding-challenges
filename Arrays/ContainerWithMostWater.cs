namespace CodeChallenges.Arrays
{
    using System;

    public class ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {
            // sliding window problem yah?

            int leftPointer = 0;
            int rightPointer = height.Length - 1;

            int result = 0;

            while (leftPointer < rightPointer)
            {
                // get hight of both walls
                int leftHeight = height[leftPointer];
                int rightHeight = height[rightPointer];

                // get width
                int difference = rightPointer - leftPointer;

                // get actual height
                int maxHeight = Math.Min(leftHeight, rightHeight);

                // determine area
                int area = difference * maxHeight;

                // set result to max of old max or current area
                result = Math.Max(area, result);

                if (leftHeight < rightHeight)
                    while (height[leftPointer] <= leftHeight && rightPointer > leftPointer)
                        leftPointer++;
                else
                    while (height[rightPointer] <= rightHeight && rightPointer > leftPointer)
                        rightPointer--;
            }

            return result;
        }
    }
}