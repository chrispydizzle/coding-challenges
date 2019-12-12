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
            List<int> distances = new List<int>();

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

        /*
         * 
// q2:

// Given a string with alpha-numeric characters and parentheses, return a string with balanced parentheses by removing the fewest characters possible. You cannot add anything to the string.

// Examples:
// balance("()") -> "()"
// balance("a(b)c)") -> "a(b)c"
// balance(")(") -> ""
// balance("(((((") -> ""
// balance("(()()(") -> "()()"
// balance(")(())(") -> "(())"
// balance(")())(()()(") -> "()()()"

        public string Balance(string input)
        {
            int opened = 0;
            StringBuilder b = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (currentChar == '(')
                {
                    opened++;

                }

                if (currentChar == ')')
                {
                    if (opened == 0)
                    {
                        continue;
                    }
                    else
                    {
                        opened--;
                    }
                }

                b.Append(currentChar);
            }

            if (opened == 0) return b.ToString(); // // balance("()(()()(") -> "()()()"

            opened = 0;

            string tempString = b.ToString();
            b.Clear()

            for (int i = tempString.Length - 1; i > 0; i--)
            {
                char currentChar = tempString[i];
                if (currentChar == ')') opened++;
                if (currentChar == '(')
                {
                    if (opened == 0)
                    {
                        continue;
                    }
                    else
                    {
                        opened--;
                    }
                }

                b.Insert(0, tempString[i]);
            }

            return b.ToString();
            ;


        }
    }
}
         */
    }
}