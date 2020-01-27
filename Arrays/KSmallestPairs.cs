namespace CodeChallenges.Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KSmallestPair
    {
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            // init return result set
            var r = new List<IList<int>>();

            var index = new int[nums1.Length];
            int minIndex = 0;

            int max = nums1.Length * nums2.Length;
            if (max < k) k = max;

            while (k > 0)
            {
                int min = int.MaxValue;

                for (int i = 0; i < nums1.Length; i++)
                {
                    if (index[i] >= nums2.Length) continue;

                    if (nums1[i] + nums2[index[i]] <= min)
                    {
                        min = nums1[i] + nums2[index[i]];
                        minIndex = i;
                    }
                }

                r.Add(new List<int>(new[] {nums1[minIndex], nums2[index[minIndex]]}));
                index[minIndex]++;
                k--;
            }

            return r;
        }
    }
}
/*
                while (n2.Count != 0 && n1.Count != 0 && d1[i1].Contains(i2) && d2[i2].Contains(i1))
                {
                    int r1 = n1.ElementAt(i1);
                    int r2 = n2.ElementAt(i2);

                    int p1 = r1;
                    int p2 = r2;

                    if ((r2 <= r1 || n2.Count == 1) && i1 < n1.Count - 1)
                    {
                        p1 = n1.ElementAt(i1 + 1);
                        p2 = n2.ElementAt(i2);
                    }
                    else if ((i2 < n2.Count - 1) && (n1.Count == 1 || r2 >= r1))
                    {
                        p2 = n2.ElementAt(i2 + 1);
                        p1 = n1.ElementAt(i1);
                    }

                    if ((p1 <= p2 && i1 + 1 < n1.Count) || n2.Count == 1)
                    {
                        i1++;
                        if (!d1.ContainsKey(i1)) d1[i1] = new List<int>();
                        if (!d1[i1].Contains(0))
                        {
                            i2 = 0;
                        }

                        while (i2 < n2.Count - 1 && (d2[i2].Contains(i1) && d1[i1].Contains(i2)))
                        {
                            i2++;
                            if (!d2.ContainsKey(i2)) d2[i2] = new List<int>();
                        }
                    }
                    else if (p2 <= p1 && i2 + 1 < n2.Count || n1.Count == 1)
                    {
                        i2++;
                        if (!d2.ContainsKey(i2)) d2[i2] = new List<int>();
                        if (!d2[i2].Contains(0))
                        {
                            i1 = 0;
                        }

                        while (i1 < n1.Count - 1 && (d1[i1].Contains(i2) && d2[i2].Contains(i1)))
                        {
                            i1++;
                            if (!d1.ContainsKey(i1)) d1[i1] = new List<int>();
                        }
                    }
                    else
                    {
                        i1 = 0;
                        i2 = 0;
                    }

                    if (!d2.ContainsKey(i2)) d2.Add(i2, new List<int>());
                    if (!d1.ContainsKey(i1)) d1.Add(i1, new List<int>());
                }

                Console.WriteLine($"i: {i1} {i2}");
                if (n1.Count == 0 || n2.Count == 0) break;
*/