namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;
    using System.Linq;

    public class DemOranges
    {
        public int OrangesRotting(int[][] grid)
        {
            // alright how do we approach this?
            // we can do it sort of like how the islands problem works,
            // but one step at a time and using a counter.
            // so BFS, but over and over again. Hmm.  It's probably not the most time efficient but we'll start there and work backwards.
            int minutes = 0;

            HashSet<(int, int)> h = new HashSet<(int, int)>();
            Queue<(int, int)> q = new Queue<(int, int)>();

            // first lets find all the rotten oranges, and drop them in a queue. Store the fresh oranges too, in a hash set.
            for (int i = 0; i < grid.Length; i++)
            {
                int[] row = grid[i];

                for (int j = 0; j < row.Length; j++)
                {
                    if (grid[i][j] == 1) h.Add((i, j));
                    if (grid[i][j] == 2) q.Enqueue((i, j));
                }
            }

            // first off, do we have any fresh oranges to start with? If not return zero
            if (!h.Any()) return 0;
            // similar check for rotting oranges.
            if (h.Any() && !q.Any()) return -1;

            // queue to hold the next "minute's" rotten oranges
            Queue<(int, int)> minuteQ = new Queue<(int, int)>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            // now that we've done our validation, start on the queue and enter the first minute
            while (q.Any())
            {
                var dq = q.Dequeue();

                h.Remove(dq);

                // check the hashset for left, right, up and down of new victims.
                (int, int) left = (dq.Item1, dq.Item2 - 1);
                (int, int) right = (dq.Item1, dq.Item2 + 1);
                (int, int) up = (dq.Item1 - 1, dq.Item2);
                (int, int) down = (dq.Item1 + 1, dq.Item2);

                if (h.Contains(left))
                {
                    minuteQ.Enqueue(left);
                }

                if (h.Contains(right))
                {
                    minuteQ.Enqueue(right);
                }

                if (h.Contains(up))
                {
                    minuteQ.Enqueue(up);
                }

                if (h.Contains(down))
                {
                    minuteQ.Enqueue(down);
                }

                if (!q.Any())
                {
                    while (minuteQ.Any())
                    {
                        (int, int) mdQ = minuteQ.Dequeue();
                        if (h.Contains(mdQ))
                        {
                            q.Enqueue(mdQ);
                        }
                    }

                    if (q.Any())
                    {
                        minutes++;
                    }
                }
            }

            // minutes++;
            // if we've run out of options but there are still fresh oranges, return -1
            if (h.Any()) return -1;
            // otherwise, we've managed to rot them all, so return how many iteratoins it's taken.
            return minutes;
        }
    }
}