namespace CodeChallenges.BFS
{
    using System;
    using System.Collections.Generic;

    public class NumIslandsT
    {
        public int NumIslands(char[,] grid)
        {
            int c = 0;
            int xLen = grid.GetLength(0);
            int yLen = grid.GetLength(1);
            for (int x = 0; x < xLen; x++)
            {
                for (int y = 0; y < yLen; y++)
                {
                    if (grid[x, y] == '1')
                    {
                        c++;

                        Queue<Tuple<int, int>> locations = new Queue<Tuple<int, int>>();
                        locations.Enqueue(new Tuple<int, int>(x, y));
                        while (locations.Count > 0)
                        {
                            Tuple<int, int> dequeue = locations.Dequeue();
                            int tx = dequeue.Item1;
                            int ty = dequeue.Item2;

                            if (tx < 0 || tx >= xLen || ty < 0 || ty >= yLen)
                            {
                                continue;
                            }

                            char target = grid[tx, ty];

                            if (target == '1')
                            {
                                grid[dequeue.Item1, dequeue.Item2] = '#';
                                locations.Enqueue(new Tuple<int, int>(tx - 1, ty));
                                locations.Enqueue(new Tuple<int, int>(tx, ty - 1));
                                locations.Enqueue(new Tuple<int, int>(tx + 1, ty));
                                locations.Enqueue(new Tuple<int, int>(tx, ty + 1));
                            }
                        }
                    }
                }
            }

            return c;
        }
    }
}