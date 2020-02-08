namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;
    using System.Linq;

    public class ReorderLogs
    {
        /*
         *
         *  Input:  ["dig1 8 1 5 1","let1 art can","dig2 3 6","let2 own kit dig","let3 art zero"]
            Output: ["let1 art can","let3 art zero","let2 own kit dig","dig1 8 1 5 1","dig2 3 6"]
         */
        public string[] ReorderLogFiles(string[] logs)
        {
            // this looks kinda like a merge sort.
            List<string> dLogs = new List<string>();
            List<(string, string)> lLogs = new List<(string, string)>();
            foreach (string log in logs)
            {
                int separ = log.IndexOf(' ');
                string logged = log.Substring(separ + 1);
                if (char.IsDigit(logged[0]))
                {
                    dLogs.Add(log);
                    continue;
                }

                string id = log.Substring(0, separ + 1);

                lLogs.Add((logged, id));
            }

            List<string> final = new List<string>();
            final.AddRange(lLogs.OrderBy(l => l.Item1).ThenBy(l => l.Item2).Select(l => $"{l.Item2}{l.Item1}"));
            final.AddRange(dLogs);
            return final.ToArray();
        }
    }
}