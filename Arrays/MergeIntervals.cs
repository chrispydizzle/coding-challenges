namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;
    using System.Linq;

    public class MergeIntervals
    {
        // TODO: Optimize
        public int[][] Merge(int[][] intervals)
        {
            // take note of the various boundries we encounter as we move through the collection.
            // if we find that a set has a number that falls within any of those boundr9ies, we merge them together by replacing one side of the set.
            // lets try making them ranges first, and optimiaze from there.
            List<HashSet<int>> l = new List<HashSet<int>>();
            if (intervals.Length == 0) return new int[][] { };

            int[] interval = intervals[0];
            l.Add(new HashSet<int>(Enumerable.Range(interval[0], intervals[0][1] - intervals[0][0] + 1)));

            for (int i = 1; i < intervals.Length; i++)
            {
                HashSet<int> currentRange = new HashSet<int>(Enumerable.Range(intervals[i][0], intervals[i][1] - intervals[i][0] + 1));
                for (int j = 0; j < l.Count; j++)
                {
                    HashSet<int> existingRange = l[j];
                    if (currentRange.Overlaps(existingRange))
                    {
                        currentRange.UnionWith(existingRange);
                        l.Remove(existingRange);
                        j--;
                    }
                }

                l.Add(currentRange);
            }

            HashSet<int[]> compress = new HashSet<int[]>();
            foreach (HashSet<int> hashSet in l) compress.Add(new[] {hashSet.Min(), hashSet.Max()});

            return compress.ToArray();
        }
    }
}