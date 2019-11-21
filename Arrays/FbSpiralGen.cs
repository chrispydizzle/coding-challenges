namespace CodeChallenges.Arrays
{
    using System;

    public class FbSpiralGen
    {
        public int[][] Spiral(int n)
        {
            // define our output array
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }

            int currentNumber = 1;
            int targetNumber = n * n;
            int boundary = 0; // how far away from the edge we should be before turning.
            int direction = 0;
            // 0 == right, 1 == down, 2 == left, 3 == up
            int row = 0;
            int column = -1;
            while (currentNumber <= targetNumber)
            {
                // move the cursor
                switch (direction)
                {
                    case 0:
                        column++;
                        // check for boundary collision
                        if (column == n - 1 - boundary)
                        {
                            direction++;
                        }

                        break;
                    case 1:
                        row++;
                        if (row == n - 1 - boundary)
                        {
                            direction++;
                        }

                        break;
                    case 2:
                        column--;
                        if (column == 0 + boundary)
                        {
                            direction++;
                            boundary++;
                        }

                        break;
                    case 3:
                        row--;
                        if (row == 0 + boundary)
                        {
                            direction = 0;
                        }

                        break;
                    default:
                        throw new InvalidOperationException();
                }

                // set value to current number
                result[row][column] = currentNumber;
                // this.Draw(result);
                currentNumber++;
            }

            return result;
        }

        public void Draw(int[][] spiral)
        {
            foreach (int[] t in spiral)
            {
                foreach (int t1 in t)
                {
                    Console.Write(" {0} ", t1);
                }

                Console.WriteLine();
            }
        }
    }
}