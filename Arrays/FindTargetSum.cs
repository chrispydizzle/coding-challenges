namespace CodeChallenges.Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindTargetSum
    {
        // TODO: Recursive Approach
        public int FindTargetSumWays(int[] nums, int S)
        {
            List<int> available = new List<int>(nums);

            Stack<Tuple<int, List<int>>> processList = new Stack<Tuple<int, List<int>>>();

            int counter = 0;

            processList.Push(new Tuple<int, List<int>>(0, available));

            while (processList.Count > 0)
            {
                Tuple<int, List<int>> tuple = processList.Pop();
                int root = tuple.Item1;

                List<int> nextLevel = new List<int>(tuple.Item2);
                int s = nextLevel.First();
                nextLevel.Remove(s);

                int pSum = root + s;
                int sSum = root - s;

                if (nextLevel.Count == 0)
                {
                    if (pSum == S)
                    {
                        counter++;
                    }

                    if (sSum == S)
                    {
                        counter++;
                    }

                    continue;
                }

                processList.Push(new Tuple<int, List<int>>(pSum, new List<int>(nextLevel)));
                processList.Push(new Tuple<int, List<int>>(sSum, new List<int>(nextLevel)));
            }

            return counter;
        }
    }
}