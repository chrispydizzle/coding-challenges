namespace CodeChallenges.Solves
{
    using System.Collections.Generic;

    internal class Sudoku
    {
        public bool sudoku(int[][] grid)
        {
            List<int>[] colUniq = new List<int>[grid.Length];
            List<int>[][] boxUniq = new List<int>[3][];
            for (int i = 0; i < grid.Length; i++)
            {
                if (i % 3 == 0)
                {
                    boxUniq[i / 3] = new List<int>[3];
                }

                List<int> rowUniq = new List<int>();

                for (int j = 0; j < grid[i].Length; j++)
                {
                    int c = grid[i][j];

                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        boxUniq[i / 3][j / 3] = new List<int>();
                    }

                    if (i == 0)
                    {
                        colUniq[j] = new List<int>();
                    }

                    if (c == '.')
                    {
                        continue;
                    }

                    if (rowUniq.Contains(c))
                    {
                        return false;
                    }

                    if (colUniq[j].Contains(c))
                    {
                        return false;
                    }

                    if (boxUniq[i / 3][j / 3].Contains(c))
                    {
                        return false;
                    }

                    rowUniq.Add(c);
                    colUniq[j].Add(c);
                    boxUniq[i / 3][j / 3].Add(c);
                }
            }

            return true;
        }
    }
}