namespace CodeChallenges.DFS
{
    using System;
    using System.Collections.Generic;
    using Solves;

    public class DFSIslands
    {
        public void Main(string[] args)
        {
            StringsRearrangement s = new StringsRearrangement();
            Console.WriteLine(s.stringsRearrangement(new[] {"aba", "bbb", "bab"}));
            Console.WriteLine(s.stringsRearrangement(new[] {"ab", "bb", "aa"}));
            Console.WriteLine(s.stringsRearrangement(new[] {"abc", "abx", "axx", "abc"}));
            char[,] map =
            {
                {'1', '1', '1', '1', '0'},
                {'1', '1', '0', '1', '0'},
                {'1', '1', '0', '0', '0'},
                {'0', '0', '0', '0', '0'}
            };
            char[,] map2 =
            {
                {'1', '1', '0', '0', '0'},
                {'1', '1', '0', '0', '0'},
                {'0', '0', '1', '0', '0'},
                {'0', '0', '0', '1', '1'}
            };

            char[,] map3 =
            {
                {'1', '1', '1'}, {'0', '1', '0'}, {'1', '1', '1'}
            };
            DFSIslands di = new DFSIslands();
            di.NumIslands(map);
            di.NumIslands(map2);
            di.NumIslands(map3);
            Console.WriteLine(di.ToString());
        }

        public int NumIslands(char[,] grid)
        {
            int c = 0;
            int xLen = grid.GetLength(0);
            int yLen = grid.GetLength(1);
            HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
            for (int x = 0; x < xLen; x++)
            {
                for (int y = 0; y < yLen; y++)
                {
                    if (grid[x, y] == '1')
                    {
                        c++;
                        Stack<Tuple<int, int>> locations = new Stack<Tuple<int, int>>();
                        locations.Push(new Tuple<int, int>(x, y));
                        while (locations.Count > 0)
                        {
                            Tuple<int, int> dequeue = locations.Pop();
                            int tx = dequeue.Item1;
                            int ty = dequeue.Item2;

                            if (tx < 0 || tx >= xLen || ty < 0 || ty >= yLen || visited.Contains(dequeue))
                            {
                                continue;
                            }

                            visited.Add(dequeue);

                            char target = grid[tx, ty];

                            if (target == '1')
                            {
                                grid[dequeue.Item1, dequeue.Item2] = '#';
                                locations.Push(new Tuple<int, int>(tx - 1, ty));
                                locations.Push(new Tuple<int, int>(tx, ty - 1));
                                locations.Push(new Tuple<int, int>(tx + 1, ty)); // go right
                                locations.Push(new Tuple<int, int>(tx, ty + 1)); // go down
                            }
                        }
                    }
                }
            }

            return c;
        }
    }
}