namespace CodeChallenges.BinaryTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindReconstructItin
    {
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            List<string> result = new List<string>();
            // interesting, a two part problem.
            // first we need to find the JFKs, where the dude leaves from. (really bad airport. btw)
            // in fact, why don't we transform the whole set into a dictionary?
            Dictionary<string, IList<string>> ticketDict = new Dictionary<string, IList<string>>();
            foreach (IList<string> ticket in tickets)
            {
                if (!ticketDict.ContainsKey(ticket[0]))
                {
                    ticketDict.Add(ticket[0], new List<string>());
                }

                ticketDict[ticket[0]].Add(ticket[1]);
                if (ticketDict[ticket[0]].Count > 1)
                {
                    ticketDict[ticket[0]] = ticketDict[ticket[0]].OrderBy(s => s).ToList();
                }
            }

            return this.FindItinerary(ticketDict, "JFK");
        }

        int[][] meanGroups(int[][] a)
        {
            Dictionary<int, List<int>> dictonary = new Dictionary<int, List<int>>();

            for (int i = 0; i < a.Length; i++)
            {
                int groupSum = 0;

                for (int j = 0; j < a[i].Length; i++)
                {
                    groupSum += a[i][j];
                }

                int mean = groupSum / a[i].Length;

                if (!dictonary.ContainsKey(mean))
                {
                    dictonary.Add(mean, new List<int>());
                }

                dictonary[mean].Add(i);
            }

            int[][] result = new int[dictonary.Count][];
            int counter = 0;
            Array.Sort(dictonary.Values.ToArray());
            // Array.Reverse();
            // IEnumerable<List<int>> enumerable = dictonary.Values.Where(v => v == dictonary.Values.Min(l => l.Min()));
            foreach (KeyValuePair<int, List<int>> kvp in dictonary)
            {
                /// kvp.
            }

            return result;
        }

        private IList<string> FindItinerary(Dictionary<string, IList<string>> ticketDict, string airport)
        {
            int[] c = new int[5];
            List<string> result = new List<string>();
            result.Add(airport);
            string wasAt = airport;
            string nowAt = string.Empty;
            Stack<KeyValuePair<string, string>> decisions = new Stack<KeyValuePair<string, string>>();
            Stack<KeyValuePair<string, string>> tempDecisions = new Stack<KeyValuePair<string, string>>();
            Dictionary<string, List<string>> failedAttempts = new Dictionary<string, List<string>>();
            while (ticketDict.Any())
            {
                IList<string> list = ticketDict[wasAt];
                for (int i = 0; i < list.Count; i++)
                {
                    if (ticketDict.ContainsKey(list[i]) || ticketDict.Count == 1)
                    {
                        nowAt = list[i];
                        decisions.Push(new KeyValuePair<string, string>(wasAt, nowAt));
                        result.Add(nowAt);
                        list.RemoveAt(i);
                        break;
                    }
                    else
                    {
                        tempDecisions.Push(decisions.Pop());
                    }
                }

                if (list.Count == 0) ticketDict.Remove(wasAt);
                wasAt = nowAt;
            }

            return result;
        }
    }
}