namespace Pdrome2.Solves
{
    using System.Collections.Generic;

    internal class MineSweeper
    {
        public int[][] minesweeper(bool[][] matrix)
        {
            List<int[]> rows = new List<int[]>();
            for (int i = 0; i < matrix.Length; i++)
            {
                bool[] row = matrix[i];
                List<int> rowCount =  new List<int>();
                
                for (int j = 0; j < row.Length; j++)
                {
                    int boolSum = 0;
                    if (j > 0)
                    {
                        if (i > 0)
                        {
                            if (matrix[i - 1][j - 1])
                            {
                                boolSum += 1;
                            }
                        }

                        if (matrix[i][j - 1])
                        {
                            boolSum += 1;
                        }

                        if (i < matrix.Length - 1)
                        {
                            if (matrix[i + 1][j - 1])
                            {
                                boolSum += 1;
                            }                            
                        }
                    }

                    if (i > 0)
                    {
                        if (matrix[i - 1][j])
                        {
                            boolSum += 1;
                        }
                    }

                    if (i < matrix.Length - 1)
                    {
                        if (matrix[i + 1][j])
                        {
                            boolSum += 1;
                        }                            
                    }
                    
                    if (j < matrix[i].Length-1)
                    {
                        if (i > 0)
                        {
                            if (matrix[i - 1][j + 1])
                            {
                                boolSum += 1;
                            }
                        }

                        if (matrix[i][j + 1])
                        {
                            boolSum += 1;
                        }

                        if (i < matrix.Length - 1)
                        {
                            if (matrix[i + 1][j + 1])
                            {
                                boolSum += 1;
                            }                            
                        }
                    }
                    
                    rowCount.Add(boolSum);
                }
                
                rows.Add(rowCount.ToArray());
            }

            return rows.ToArray();
        }
    }
}