namespace CodeChallenges.Arrays
{
    using System;
    using System.Collections.Generic;

    public class Search2DMatrix
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null) return false;

            // sorted = binary search.
            bool foundTarget = false;
            int height = matrix.GetLength(0);

            int width = matrix.GetLength(1);
            if (height == 0 || width == 0) return false;

            int offsetHeight = 0;
            int offsetWidth = 0;

            return false;
        }
    }
}