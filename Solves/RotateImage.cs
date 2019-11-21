namespace CodeChallenges.Solves
{
    internal class RotateImage
    {
        public int[][] rotateImage(int[][] a)
        {
            int[][] result = new int[a.Length][];
            for (int i = 0; i < result.Length; i++)
            {
                int height = a.Length;
                result[i] = new int[height];

                for (int j = height - 1; j >= 0; j--)
                {
                    result[i][height - j - 1] = a[j][i];
                }
            }

            return result;
        }
    }
}