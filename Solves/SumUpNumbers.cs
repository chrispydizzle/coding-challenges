namespace Pdrome2
{
    using System.Text.RegularExpressions;

    internal class SumUpNumbers
    {
        public int sumUpNumbers(string inputString)
        {
            int start = 0;
            Regex r = new Regex("(?:([0-9]+)[^0-9]*)");
            MatchCollection matchCollection = r.Matches(inputString);
            foreach (Match match in matchCollection)
            {
                GroupCollection groupCollection = match.Groups;
                string groupCValue = groupCollection[1].Value;
                int i = int.Parse(groupCValue);
                start += i;
            }

            return start;
        }
    }
}