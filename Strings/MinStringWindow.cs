namespace CodeChallenges.Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MinStringWindow
    {
        public string MinWindow(string s, string t)
        {
            // convert t to chararry

            if (s.Length < t.Length) return string.Empty;

            List<char> window = t.ToCharArray().ToList();

            Dictionary<string, List<int>> bestLocation = new Dictionary<string, List<int>>();

            // get all locations of each window character in the string
            int iterator = 0;

            foreach (char t1 in t)
            {
                List<int> positions = new List<int>();
                char seekChar = t1;
                int seek = -1;

                string key = t1.ToString();

                if (bestLocation.ContainsKey(key))
                {
                    iterator++;
                    bestLocation[seekChar.ToString() + iterator] = bestLocation[key];
                    continue;
                }

                do
                {
                    seek = s.IndexOf(seekChar, seek + 1);
                    if (seek > -1)
                    {
                        positions.Add(seek);
                    }
                } while (seek != -1);

                if (positions.Count == 0) return string.Empty;

                bestLocation[seekChar.ToString()] = positions;
            }

            Stack<List<int>> ordered = new Stack<List<int>>(bestLocation.Values.OrderByDescending(c => c.Count));

            HashSet<int> finalResult = this.FindSmallest(ordered, new HashSet<int>(), int.MaxValue);
            string result = s.Substring(finalResult.Min(), finalResult.Max() - finalResult.Min() + 1);

            return result;
        }

        private HashSet<int> FindSmallest(Stack<List<int>> ordered, HashSet<int> currentInts, int maxDist)
        {
            List<int> nextSet = ordered.Pop();
            Queue<int> topList = new Queue<int>(nextSet);
            HashSet<int> pretest = new HashSet<int>(currentInts);
            HashSet<int> result = new HashSet<int>();

            // some kinda perf iprovement

            if (pretest.Count > 0)
            {
                int currentMax = pretest.Max();
                int currentMin = pretest.Min();

                if (Math.Abs(currentMax - currentMin) > maxDist) return new HashSet<int>();
            }

            // dequeue the next number, and pass it down
            while (topList.Any())
            {
                int dequeue = topList.Dequeue();
                HashSet<int> newList = new HashSet<int>(currentInts);
                if (newList.Contains(dequeue)) continue;

                HashSet<int> tempResult = new HashSet<int>();

                newList.Add(dequeue);

                if (ordered.Count != 0)
                {
                    tempResult = this.FindSmallest(ordered, newList, maxDist);
                }
                else
                {
                    tempResult = newList;
                }

                if (!tempResult.Any()) continue;

                int max = tempResult.Max();
                int min = tempResult.Min();

                int smallestDistance = Math.Abs(max - min);

                if (smallestDistance < maxDist)
                {
                    maxDist = smallestDistance;
                    result = tempResult;
                }
            }

            ordered.Push(nextSet);
            return result;
        }
    }
}