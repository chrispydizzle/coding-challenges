namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;
    using System.Linq;

    public class RottenOs
    {
        public int OrangesRotting(int[][] grid)
        {
            HashSet<(int, int)> nonRotten = new HashSet<(int, int)>();
            // dfs again?
            int mins = 0;
            Queue<(int, int)> q = new Queue<(int, int)>();
            for (int i = 0; i < grid.Length; i++)
            {
                int[] ints = grid[i];
                for (int j = 0; j < ints.Length; j++)
                {
                    if (ints[j] == 2)
                    {
                        q.Enqueue((i, j));
                    }
                    else if (ints[j] == 1)
                    {
                        nonRotten.Add((i, j));
                    }
                }
            }

            if (nonRotten.Count == 0)
            {
                return 0;
            }

            Queue<(int, int)> tempQ = new Queue<(int, int)>();
            while (q.Any() && nonRotten.Any())
            {
                (int, int) coords = q.Dequeue();
                // can I infect left,right,up,down?

                (int, int) left = (coords.Item1, coords.Item2 - 1);
                (int, int) right = (coords.Item1, coords.Item2 + 1);
                (int, int) up = (coords.Item1 - 1, coords.Item2);
                (int, int) down = (coords.Item1 + 1, coords.Item2);


                if (nonRotten.Remove(left)) tempQ.Enqueue(left);
                if (nonRotten.Remove(right)) tempQ.Enqueue(right);
                if (nonRotten.Remove(up)) tempQ.Enqueue(up);
                if (nonRotten.Remove(down)) tempQ.Enqueue(down);

                if (!nonRotten.Any())
                {
                    mins++;
                    break;
                }


                if (!q.Any())
                {
                    mins++;
                    q = new Queue<(int, int)>(tempQ);
                    tempQ.Clear();
                }
            }

            if (nonRotten.Any()) return -1;

            return mins;
        }
    }
}