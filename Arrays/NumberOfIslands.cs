using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.Arrays
{
    public class NumberOfIslands
    {
        public int NumIslands(char[][] grid)
        {
            int r = 0;

            var visited = new HashSet<Tuple<int, int>>();

            // seek through the colletion until you find a 1, then DFS it and add it to a visited list.
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        r++;
                        DoDFS(grid, i, j, visited);
                    }
                }
            }

            return r;
        }

        public void DoDFS(char[][] grid, int y, int x, HashSet<Tuple<int,int>> visited)
        {
            // check up, down, left, right

            var coordsStack = new Stack<Tuple<int, int>>();
            coordsStack.Push(new Tuple<int, int>(y, x));
            while (coordsStack.Any())
            {
                var location = coordsStack.Pop();
                int yS = location.Item1;
                int xS = location.Item2;
                grid[yS][xS] = 'X';

                if (yS > 0)
                {
                    if (grid[yS - 1][xS] == '1')
                    {
                        coordsStack.Push(new Tuple<int, int>(yS - 1, xS));
                    }
                }

                if (yS < grid.Length - 1)
                {
                    if (grid[yS + 1][xS] == '1')
                    {
                        coordsStack.Push(new Tuple<int, int>(yS + 1, xS));
                    }
                }

                if (xS > 0)
                {
                    if (grid[yS][xS - 1] == '1')
                    {
                        coordsStack.Push(new Tuple<int, int>(yS, xS - 1));
                    }
                }

                if (xS < grid[yS].Length - 1)
                {
                    if (grid[yS][xS + 1] == '1')
                    {
                        coordsStack.Push(new Tuple<int, int>(yS, xS + 1));
                    }
                }
            }
        }
    }
}