namespace CodeChallenges.DynamicProgramming
{
    using System;

    public class PaintHouse
    {
        public int MinCost(int[][] costs)
        {
            if (costs == null || costs.Length == 0) return 0;

            for (int i = 1; i < costs.Length; i++)
            {
                costs[i][0] += Math.Min(costs[i - 1][1], costs[i - 1][2]);
                costs[i][1] += Math.Min(costs[i - 1][0], costs[i - 1][2]);
                costs[i][2] += Math.Min(costs[i - 1][1], costs[i - 1][0]);
            }

            int n = costs.Length - 1;
            return Math.Min(Math.Min(costs[n][0], costs[n][1]), costs[n][2]);
        }
    }
}