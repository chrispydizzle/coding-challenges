namespace CodeChallenges.Solves
{
    using System;
    using System.Collections.Generic;

    internal class BoxBlur
    {
        public int[][] boxBlur(int[][] image)
        {
            List<int[]> rows = new List<int[]>();
            for (int i = 1; i < image.Length - 1; i++)
            {
                int[] currentLine = image[i];
                List<int> row = new List<int>();
                for (int j = 1; j < currentLine.Length - 1; j++)
                {
                    decimal boxSum = 0;
                    boxSum += image[i - 1][j - 1];
                    boxSum += image[i][j - 1];
                    boxSum += image[i + 1][j - 1];
                    boxSum += image[i - 1][j];
                    boxSum += image[i][j];
                    boxSum += image[i + 1][j];
                    boxSum += image[i - 1][j + 1];
                    boxSum += image[i][j + 1];
                    boxSum += image[i + 1][j + 1];

                    decimal boxAvg = boxSum / 9;

                    int floorBoxAvg = (int) Math.Floor(boxAvg);
                    row.Add(floorBoxAvg);
                }

                rows.Add(row.ToArray());
            }

            return rows.ToArray();
        }
    }
}