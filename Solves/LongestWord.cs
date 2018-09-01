namespace Pdrome2
{
    using System.Text.RegularExpressions;

    internal class LongestWord
    {
        public string longestWord(string text)
        {
            string lead = string.Empty;
            Regex r = new Regex("(?:([A-Za-z]+)[^A-z]*)");
            MatchCollection matchCollection = r.Matches(text);
            foreach (Match match in matchCollection)
            {
                GroupCollection groupCollection = match.Groups;
                string groupCValue = groupCollection[1].Value;
                if (groupCValue.Length > lead.Length)
                {
                    lead = groupCValue;
                }
            }

            return lead;
        }
    }
}