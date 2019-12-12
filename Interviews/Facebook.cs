using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace CodeChallenges.Interviews
{
    public class Facebook
    {
        public int[][] KClosest(int[][] points, int K)
        {
            List<int[]> sets = new List<int[]>();
            HashSet<int> distances = new HashSet<int>();

            var calculations = new ConcurrentDictionary<int, List<int[]>>();

            int farthestDistance = int.MinValue;

            for (int i = 0; i < points.Length; i++)
            {
                int distance = (points[i][0] * points[i][0]) + (points[i][1] * points[i][1]);

                if (sets.Count < K)
                {
                    sets.Add(points[i]);
                    distances.Add(distance);
                    calculations.AddOrUpdate(distance, new List<int[]>() {points[i]},
                        (dist, existingList) =>
                        {
                            existingList.Add(points[i]);
                            return existingList;
                        });
                    farthestDistance = Math.Max(farthestDistance, distance);
                }
                else if (sets.Count == K)
                {
                }
                else if (distance < farthestDistance)
                {
                    calculations.AddOrUpdate(distance, new List<int[]>() {points[i]},
                        (dist, existingList) =>
                        {
                            existingList.Add(points[i]);
                            return existingList;
                        });
                    List<int[]> items;
                    distances.Remove(farthestDistance);
                    calculations.TryGetValue(farthestDistance, out items);
                    sets.Remove(items.First());
                    sets.Add(points[i]);
                    distances.Add(distance);
                    farthestDistance = distances.Max();
                }
            }

            int[][] result = sets.ToArray();
            return result;
        }

        public string MinRemoveToMakeValid(string input)
        {
            int opened = 0;
            StringBuilder b = new StringBuilder();

            Stack<int> openers = new Stack<int>();
            HashSet<int> itemsToSkip = new HashSet<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (currentChar == '(')
                {
                    openers.Push(i);
                }

                if (currentChar == ')')
                {
                    if (openers.Any())
                    {
                        openers.Pop();
                    }
                    else
                    {
                        {
                            itemsToSkip.Add(i);
                        }
                    }
                }
            }

            while (openers.Any())
            {
                itemsToSkip.Add(openers.Pop());
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!itemsToSkip.Contains(i))
                {
                    b.Append(input[i]);
                }
            }

            return b.ToString();
        }
    }
}