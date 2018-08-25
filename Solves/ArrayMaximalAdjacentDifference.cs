namespace Pdrome2
{
    using System;

    internal class ArrayMaximalAdjacentDifference
    {
        public int arrayMaximalAdjacentDifference(int[] inputArray)
        {
            int max = 0;
            for (int index = 0; index < inputArray.Length - 1; index++)
            {
                int i = inputArray[index];
                int j = inputArray[index + 1];
                int curResult = Math.Abs(i - j);
                if (curResult > max)
                {
                    max = curResult;
                }
            }

            return max;
        }
 
    }
}