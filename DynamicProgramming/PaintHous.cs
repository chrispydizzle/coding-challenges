namespace CodeChallenges.DynamicProgramming
{
    using System;

    public class PaintHous
    {
        public int MinCost(int[][] costs)
        {
            if (costs.Length == 0) return 0;
            // so, if this is dp, how do we solve for it?

            // the solution consists of finding the next minimum step for each color to get to the next house, as you only
            // have three options this is fairly simple. Not looking forward to house2
            // naive approach would have to calculate all paths. Let's not do that.
            // we can condense the left and middle matrices by
            int[][] calcCosts = new int[costs.Length][];

            for (int i = 0; i < costs.Length; i++)
            {
                calcCosts[i] = new int[costs[i].Length];
                costs[i].CopyTo(calcCosts[i], 0);
            }

            for (int h = 0; h < costs.Length - 1; h++)
            {
                calcCosts[h + 1] = new int[3];

                // find each minimum next step and apply it to the next row of the calcs table.
                calcCosts[h + 1][0] = costs[h + 1][0] + Math.Min(calcCosts[h][1], calcCosts[h][2]);
                calcCosts[h + 1][1] = costs[h + 1][1] + Math.Min(calcCosts[h][2], calcCosts[h][0]);
                calcCosts[h + 1][2] = costs[h + 1][2] + Math.Min(calcCosts[h][0], calcCosts[h][1]);
            }

            return Math.Min(calcCosts[costs.Length - 1][0], Math.Min(calcCosts[costs.Length - 1][1], calcCosts[costs.Length - 1][2]));
        }
    }
}