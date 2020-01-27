namespace CodeChallenges.Design
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaxLinePoints
    {
        Point[] points;
        int n;
        Dictionary<double, int> lines = new Dictionary<double, int>();
        int horisontal_lines;

        public int MaxPoints(int[][] points)
        {
            var v = new List<Point>();
            foreach (List<Point> list in points.Select((s, index) =>
            {
                foreach (int t in s)
                {
                    int x = index;
                    foreach (int y in s) v.Add(new Point() {X = x, Y = y});
                }

                return v;
            }))

                this.points = v.ToArray();

            // If the number of points is less than 3
            // they are all on the same line.
            n = points.Length;
            if (n < 3)
                return n;

            int max_count = 1;
            // Compute in a loop a max number of points
            // on a line containing point i.
            for (int i = 0; i < n - 1; i++)
                max_count = Math.Max(max_points_on_a_line_containing_point_i(i), max_count);
            return max_count;
        }

        public Tuple<int, int> add_line(int i, int j, int count, int duplicates)
        {
            /*
            Add a line passing through i and j points.
            Update max number of points on a line containing point i.
            Update a number of duplicates of i point.
            */
            // rewrite points as coordinates
            int x1 = points[i].X;
            int y1 = points[i].Y;
            int x2 = points[j].X;
            int y2 = points[j].Y;
            // add a duplicate point
            if ((x1 == x2) && (y1 == y2))
                duplicates++;
            // add a horisontal line : y = const
            else if (y1 == y2)
            {
                horisontal_lines += 1;
                count = Math.Max(horisontal_lines, count);
            }
            // add a line : x = slope * y + c
            // only slope is needed for a hash-map
            // since we always start from the same point
            else
            {
                double slope = 1.0 * (x1 - x2) / (y1 - y2) + 0.0;
                int outc = 1;
                lines.TryGetValue(slope, out outc);
                lines[slope] = outc + 1;
                count = Math.Max(lines[slope], count);
            }

            return new Tuple<int, int>(count, duplicates);
        }

        public int max_points_on_a_line_containing_point_i(int i)
        {
            /*
            Compute the max number of points
            for a line containing point i.
            */
            // init lines passing through point i
            lines.Clear();
            horisontal_lines = 1;
            // One starts with just one point on a line : point i.
            int count = 1;
            // There is no duplicates of a point i so far.
            int duplicates = 0;

            // Compute lines passing through point i (fixed)
            // and point j (interation).
            // Update in a loop the number of points on a line
            // and the number of duplicates of point i.
            for (int j = i + 1; j < n; j++)
            {
                Tuple<int, int> p = add_line(i, j, count, duplicates);
                count = p.Item1;
                duplicates = p.Item2;
            }

            return count + duplicates;
        }
    }
}