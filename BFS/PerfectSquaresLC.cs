namespace Pdrome2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class PerfectSquaresLC
    {
        public int NumSquares(int n)
        {
            Queue<int> queue = new Queue<int>();
            HashSet<int> set = new HashSet<int>();
            int step = 0;
            queue.Enqueue(n);
            while (queue.Any())
            {
                int size = queue.Count;
                step++;
                for (int i = 0; i < size; i++)
                {
                    int curr = queue.Dequeue();
                    if (!set.Add(curr)) continue;

                    for (int j = 1; j <= Math.Sqrt(curr); j++)
                    {
                        int next = curr - j * j;
                        if (next == 0) return step;

                        queue.Enqueue(next);
                    }
                }
            }

            return 0;
        }
    }
}