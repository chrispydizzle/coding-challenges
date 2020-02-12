namespace CodeChallenges.Arrays
{
    public class Search2DMatrix
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null) return false;

            // sorted = binary search.
            int height = matrix.GetLength(0);

            int width = matrix.GetLength(1);
            if (height == 0 || width == 0) return false;

            int offsetHeight = 0;
            int offsetWidth = 0;

            return false;
        }
    }
}