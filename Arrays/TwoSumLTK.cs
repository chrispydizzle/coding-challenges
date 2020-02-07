namespace CodeChallenges.Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TwoSumLTK
    {
        public int TwoSumLessThanK(int[] A, int K)
        {
            int bestCase = K - 1;
            int result = -1;
            // first do it naively, create a hashset, h
            SortedSet<int> h = new SortedSet<int>();
            foreach (int a in A)
            {
                // for n in A
                // set d = difference between K && n
                int d = K - a;

                if (d < 0) continue;

                // if d > 0


                // get potential matches
                SortedSet<int> potentials = h.GetViewBetween(0, d - 1);
                // if h contains bestcase - a[i] == bestCase return bestcase
                if (potentials.Any())
                {
                    result = Math.Max(potentials.Max() + a, result);
                    if (result == bestCase)
                    {
                        return bestCase;
                    }
                }

                bool added = h.Add(a);
            }

            return result;
        }
    }
}