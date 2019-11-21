namespace CodeChallenges.BFS
{
    using System;
    using System.Collections.Generic;

    internal class PerfectSquare
    {
        private int steps;

        public int NumSquares(int n)
        {
            this.steps = 0;

            int root = n;

            Queue<int> nodes = new Queue<int>();
            nodes.Enqueue(root);

            while (nodes.Count > 0)
            {
                this.steps++;
                int currentSize = nodes.Count;
                for (int i = 0; i < currentSize; i++)
                {
                    int dequeue = nodes.Dequeue();
                    for (int j = 1; j <= Math.Sqrt(dequeue); j++)
                    {
                        int square = j * j;
                        int nextNode = dequeue - square;
                        if (nextNode == 0) return this.steps;

                        nodes.Enqueue(nextNode);
                    }
                }
            }

            return this.steps;
        }
    }
}