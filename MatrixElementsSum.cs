namespace Pdrome2
{
    public class MatrixElementsSum
    {
        public static int[][] matrix1 = new int[][]{
            new[] {0, 1, 1, 2},
            new[] {0, 5, 0, 0},
            new[] {2, 0, 3, 3}
        };
        
        public int matrixElementsSum(int[][] matrix)
        {
            bool[] scaryj = new bool[matrix[0].Length];
            int runningtotal = 0;
            
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        scaryj[j] = true;
                    }
                    
                    if (scaryj[j] == true)
                    {
                        continue;
                    }

                    runningtotal += matrix[i][j];
                }
            }

            return runningtotal;
        }
    }
}