namespace CodeChallenges.Strings
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class DisWordCommonho
    {
        public string MostCommonWord(string paragraph, string[] banned)
        {
            StringBuilder b = new StringBuilder();
            foreach (string str in banned)
            {
                b.Append($"(?:{str})|");
            }

            string rString = $@"\W*\W*(\w{{1,}})\W*";
            Regex r = new Regex(rString, RegexOptions.IgnoreCase);
            MatchCollection matchCollection = r.Matches(paragraph);
            Dictionary<string, int> d = new Dictionary<string, int>();

            foreach (Match match in matchCollection)
            {
                string temp = match.Value.ToLower().Trim();

                Group matchGroup = match.Groups[match.Groups.Count - 1];
                string matchGroupValue = matchGroup.Value.ToLower().Trim();
                if (banned.Contains(matchGroupValue) || string.IsNullOrEmpty(matchGroupValue)) continue;


                if (!d.ContainsKey(matchGroupValue))
                {
                    d.Add(matchGroupValue, 0);
                }

                d[matchGroupValue]++;
            }

            KeyValuePair<string, int> keyValuePair = d.First(kv => kv.Value == d.Max(m => m.Value));
            return keyValuePair.Key.ToString();
        }
    }
}