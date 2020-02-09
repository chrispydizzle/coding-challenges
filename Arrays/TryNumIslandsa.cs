namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;
    using System.Linq;

    public class TryNumIslandsa
    {
        private HashSet<(int, int)> visited = new HashSet<(int, int)>();

        public int NumIslands(char[][] grid)
        {
            int islands = 0;
            // BFS
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        if (visited.Contains((i, j))) continue;
                        // visited.Add((i, j));
                        islands++;
                        this.AccountFor(i, j, ref grid);
                    }
                }
            }

            return islands;
        }

        public void AccountFor(int y, int x, ref char[][] grid)
        {
            var q = new Queue<(int, int)>();
            q.Enqueue((y, x));
            while (q.Any())
            {
                var dQ = q.Dequeue();
                int i = dQ.Item1;
                int j = dQ.Item2;
                if (visited.Contains((i, j))) continue;

                visited.Add((i, j));
                grid[i][j] = 'X';
                if (j > 0 && grid[i][j - 1] == '1') // left
                {
                    q.Enqueue((i, j - 1));
                }

                if (i > 0 && grid[i - 1][j] == '1') // up
                {
                    q.Enqueue((i - 1, j));
                }

                if (i < grid.Length - 1 && grid[i + 1][j] == '1') // down
                {
                    q.Enqueue((i + 1, j));
                }

                if (j < grid[i].Length - 1 && grid[i][j + 1] == '1') // right
                {
                    q.Enqueue((i, j + 1));
                }
            }
        }
    }
}