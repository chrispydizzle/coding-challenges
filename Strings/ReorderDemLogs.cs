namespace CodeChallenges.Strings
{
    using System.Collections.Generic;
    using System.Linq;

    public class ReorderDemLogs
    {
        public string[] ReorderLogFiles(string[] logs)
        {
            // loop through logs,
            // use string.split on ' ' to pull out digit logs based on string[1]char[0]. Addem to a list.

            List<string> digitLogs = new List<string>();
            SortedDictionary<string, List<string>> aLogs = new SortedDictionary<string, List<string>>();
            foreach (string t in logs)
            {
                int firstSpace = t.IndexOf(' ');
                string id = t.Substring(0, firstSpace);
                string value = t.Substring(firstSpace + 1);

                if (char.IsDigit(value[0]))
                {
                    digitLogs.Add(t);
                    continue;
                }

                if (!aLogs.ContainsKey(value))
                {
                    aLogs.Add(value, new List<string>());
                }

                aLogs[value].Add(id);
            }

            List<string> result = new List<string>();
            foreach (string s in aLogs.Keys)
            {
                if (aLogs[s].Count == 1)
                {
                    result.Add($"{aLogs[s][0]} {s}");
                    continue;
                }

                var oList = aLogs[s].OrderBy(st => st);
                foreach (string l in oList)
                {
                    result.Add($"{l} {s}");
                }
            }

            result.AddRange(digitLogs);
            return result.ToArray();
        }
    }
}