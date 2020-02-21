namespace CodeChallenges.Interviews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BetterActual
    {
        public string solution(string S)
        {
            string[] lines = S.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder b = new StringBuilder();
            Dictionary<string, List<ValueTuple<int, DateTime>>> cityCount = new Dictionary<string, List<ValueTuple<int, DateTime>>>();

            // <<photoname>>.<<extension>>, <<city_name>>, yyyy-mm-dd hh:mm:ss
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                // split line by ','
                string[] sections = line.Split(',');
                if (sections.Length != 3)
                {
                    // something's wrong in this case.
                    return S;
                }

                string cityName = sections[1].Trim();
                if (!cityCount.ContainsKey(cityName))
                {
                    cityCount[cityName] = new List<ValueTuple<int, DateTime>>();
                }

                DateTime date = DateTime.Parse(sections[2].Trim());
                cityCount[cityName].Add(new ValueTuple<int, DateTime>(i, date));
                // * every photo in each group(by city) should have same len.
                // this is all the information we need.
                // run through sections
            }

            // citycount has city list and list of index and date;

            Dictionary<int, int> listnum = new Dictionary<int, int>();
            Dictionary<string, int> max = new Dictionary<string, int>();

            foreach (string cityCountKey in cityCount.Keys)
            {
                var orderedEnumerable = cityCount[cityCountKey].OrderBy(tuple => tuple.Item2).ToList();
                // this gives me all items in the city ordered by date.

                foreach ((int, DateTime) valueTuple in orderedEnumerable)
                {
                    if (!max.ContainsKey(cityCountKey))
                    {
                        max.Add(cityCountKey, 0);
                    }

                    max[cityCountKey]++;
                    listnum.Add(valueTuple.Item1, max[cityCountKey]);
                }
            }

            Dictionary<string, Dictionary<int, string>> d = new Dictionary<string, Dictionary<int, string>>();


            // perf not an issue can re-run or optimize later
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                // split line by ','
                string[] sections = line.Split(',');
                string cityName = sections[1].Trim();
                var current = listnum[i];
                int maxLen = max[cityName].ToString().Length;


                string numAsStr = current.ToString();
                int extensionStarts = sections[0].IndexOf('.');
                string extension = sections[0].Substring(extensionStarts);
                string padLeft = numAsStr.PadLeft(maxLen, '0');
                b.AppendLine($"{cityName}{padLeft}{extension}");

                // * every photo in each group(by city) should have same len.
                // this is all the information we need.
                // run through sections
            }

            return b.ToString();
        }

        public int Solution(int[] a)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            return 0;
        }

        public string SolutionAbc(string s)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            // it says return *any* string that can result from a sequence of transformations,
            // not necessarily the shortest or longest path
            // here we want to probably apply dp or a b/dfs.
            // also, string can be up to 50000 chars so more likely dp
            // neeed to validate (string can be len 0)
            if (string.IsNullOrEmpty(s.Trim()) || s.Length == 1) return s;

            // doesn't matter which actual letter it is, running into two dupes means
            // I can remove the pair
            // to do this in O(n), can for through the string, backchecking as I go, looking for duplicate combinations ie:
            // for char in s from index1
            for (int i = 1; i < s.Length; i++)
            {
                //is prev letter equal to me?
                char current = s[i];
                char prev = s[i - 1];
                // if so remove it and me, and i=i-2
                if (current == prev)
                {
                    s = s.Remove(i - 1, 2);
                    i = Math.Max(i - 2, 0);
                }


                // so, CABBAC => CAAC and index is still at 2 in the next loop. it will catch the AA and strip it out too,
                // yeilding CC and index will be at one, completing
            }

            return s;
        }

        /*
        With 100,000 possible items this should be performant but o(n) should be fine. may revisit
        valid if
         if 0 ≤ P &lt; Q &lt; N and A[P] = A[Q].
        */
    }

    public class BetterPractice
    {
        public int solution(int[] A)
        {
            // first let's valide inputs
            if (A == null || A.Length == 0) return 1;

            // given the size assumption max 100,000, we don't want to make too many passes.
            // Don't want to waste time with unnecesary duplicates.
            // Let's try this first with some linq

            // distinctitfy, sort, and remove values lt zero as they don't matter.
            List<int> l = A.ToList().Distinct().Where(n => n > 0).OrderBy(n => n).ToList();
            // check for the existance of the obvious value

            if (!l.Any() || l[0] != 1) return 1;

            if (l.Count <= 3)
            {
                // don't need to binary search if we have three or less items.
                // we already know it's not one, so check which one is missing (2 or 3) or return 4
                if (l.Count == 1) return 2;

                if (l.Count == 2)
                {
                    if (l[1] != 2) return 2;

                    return 3;
                }


                if (l[2] != 3) return 3;

                return 4;
            }

            // now we're left with a unique set of sorted ints >0, a solution is possible a-la-binary search
            // we'll go to the "middle" and see which side is missing a value.
            int middle = l.Count / 2;

            return this.BinarySearch(l.Take(middle).ToList(), l.Skip(middle).ToList());
        }

        private int BinarySearch(List<int> left, List<int> right)
        {
            // check if the missing number is in the left side
            if (left.Count() == 2 && left[1] - left[0] > 1)
            {
                return left[0] + 1;
            }

            // check if the missing number is in the right side
            if (right.Count() == 2 && right[1] - right[0] > 1)
            {
                return right[0] + 1;
            }

            // check if the missing number is between left and right
            if (left.Count <= 2 && right.Count <= 2 || left.Count <= 2 && right.Count <= 2)
            {
                List<int> newList = new List<int>(left);
                newList.AddRange(right);
                for (int i = 1; i < newList.Count; i++)
                {
                    if (newList[i] - newList[i - 1] > 1)
                    {
                        return newList[i - 1] + 1;
                    }
                }
            }

            if (left.Any() && left.Count > 2 && left.Count != left.Last() - left.First() + 1 &&
                left.Count != left.Last() - left.First() - 1)
            {
                return this.BinarySearch(left.Take(left.Count / 2).ToList(), left.Skip(left.Count / 2).ToList());
            }

            if (right.Any() && right.Count > 2 && right.Count != right.Last() - right.First() - 1)
            {
                return this.BinarySearch(right.Take(right.Count / 2).ToList(), right.Skip(right.Count / 2).ToList());
            }

            return right.Last() + 1;
        }
    }

    public class Better
    {
    }
}