namespace CodeChallenges.Sorts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KClosestPoints
    {
        //dist = ( p1 - q1)^2 + (p2 - q2)^2 +
        public int[][] KClosest(int[][] points, int K)
        {
            /*
             * Input: points = [[1,3],[-2,2]], K = 1
                        Output: [[-2,2]]

                Input: points = [[3,3],[5,-1],[-2,4]], K = 2
                        Output: [[3,3],[-2,4]]
             */

            // unless I actually have 0,0 in the set and K == 1, need to do this calc at least once for each point p in points o(N)
            Dictionary<double, List<int[]>> d = new Dictionary<double, List<int[]>>();
            SortedSet<double> result = new SortedSet<double>();

            foreach (int[] point in points)
            {
                double mathOne = Math.Pow(point[0], 2) + Math.Pow(point[1], 2);
                double res = Math.Sqrt(mathOne);
                if (!d.ContainsKey(res))
                {
                    d.Add(res, new List<int[]>());
                }

                result.Add(res);
                d[res].Add(point);
            }

            List<double> enumerable = result.Take(K).ToList();
            int[][] final = new int[K][];
            for (int i = 0; i < enumerable.Count; i++)
            {
                int resi = i;
                for (int index = 0; i + index < K && index < d[enumerable[i]].Count; index++)
                {
                    final[i + index] = d[enumerable[i]][index];
                }

                i += d[enumerable[i]].Count - 1;
            }

            return final;
        }
    }
}