namespace Pdrome2
{
    using System.Collections.Generic;

    internal class DifferentSquares
    {
        public int differentSquares(int[][] matrix)
        {
            int height = matrix.Length;
            int width = matrix[0].Length;
            HashSet<int[][]> matrices = new HashSet<int[][]>();

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    int rightSide = c + 2;
                    int bottom = r + 2;
                    if (bottom <= matrix.Length && rightSide <= matrix[r].Length)
                    {
                        int[][] cMatrix = new[]
                        {
                            new[] {matrix[r][c], matrix[r][c + 1]},
                            new[] {matrix[r + 1][c], matrix[r + 1][c + 1]}
                        };

                        bool unique = true;
                        foreach (int[][] intse in matrices)
                        {
                            int dupeCounter = 0;
                            for (int i = 0; i < intse.Length; i++)
                            {
                                int[] ints = intse[i];
                                for (int j = 0; j < ints.Length; j++)
                                {
                                    if (cMatrix[i][j] == intse[i][j])
                                    {
                                        dupeCounter++;
                                    }
                                }
                            }

                            if (dupeCounter == 4)
                            {
                                unique = false;
                            }
                        }

                        if (unique)
                        {
                            matrices.Add(cMatrix);
                        }
                    }
                }
            }

            return matrices.Count;
            
        }
    }
}