namespace CodeChallenges.Design
{
    using System;
    using System.Collections.Generic;

    public class MaxLinePoints
    {
        public int MaxPoints(int[][] pointsInt)
        {
            Point[] points = new Point[pointsInt.Length];
            int i = 0;
            foreach (int[] val in pointsInt)
            {
                points[i++] = new Point(val[0], val[1]);
            }

            if (points.Length < 2) return points.Length;
            int max = 2;
            foreach (Point p1 in points)
            {
                Dictionary<int, int> slopes = new Dictionary<int, int>(points.Length);
                int localMax = 0;
                foreach (Point p2 in points)
                {
                    int num = p2.Y - p1.Y;
                    int den = p2.X - p1.X;

                    // pairing functions only work with non-negative integers
                    // we store the sign in a separate variable
                    int sign = 1;
                    if ((num > 0 && den < 0) || (num < 0 && den > 0)) sign = -1;
                    num = Math.Abs(num);
                    den = Math.Abs(den);

                    // pairing functions represent a pair of any two integers uniquely;
                    // they can be used as hash functions for any sequence of integers;
                    // therefore, a pairing function from 1/2 doesn't equal to that from 3/6
                    // even though the slope 1/2 and 3/6 is the same.
                    // => we need to convert each fraction to its simplest form, i.e. 3/6 => 1/2
                    int gcd = GCD(num, den);
                    num = gcd == 0 ? num : num / gcd;
                    den = gcd == 0 ? den : den / gcd;

                    // We can use Cantor pairing function pi(k1, k2) = 1/2(k1 + k2)(k1 + k2 + 1) + k2
                    // and include the sign
                    int m = sign * (num + den) * (num + den + 1) / 2 + den;
                    if (slopes.ContainsKey(m)) slopes[m] = slopes[m] + 1;
                    else slopes.Add(m, 1);
                    if (m == 0) continue;

                    localMax = Math.Max(slopes[m], localMax);
                }

                max = Math.Max(max, localMax + slopes[0]);
            }

            return max;
        }

        public int GCD(int a, int b)
        {
            if (b == 0) return a;
            return GCD(b, a % b);
        }
    }
}