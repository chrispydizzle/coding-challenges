namespace Pdrome2.Solves
{
    using System;

    internal class ArrayChange
    {
        public int arrayChange(int[] inputArray)
        {
            int moves = 0;
            for (int index = 0; index < inputArray.Length - 1; index++)
            {
                int item = inputArray[index];
                int nextItem = inputArray[index + 1];
                if (nextItem <= item)
                {
                    int target = item + 1;
                    moves += Math.Abs(nextItem - target);
                    inputArray[index           + 1] = target;
                }
            }

            return moves;
        }
    }
}