namespace CodeChallenges.Strings
{
    using System.Collections.Generic;
    using System.Text;

    public class RemoveVowelsFromString
    {
        public string RemoveVowels(string S)
        {
            StringBuilder b = new StringBuilder();
            List<char> invalids = new List<char> {'a', 'e', 'i', 'o', 'u'};
            foreach (char c in S)
            {
                if (invalids.Contains(c)) continue;
                b.Append(c);
            }

            return b.ToString();
        }
    }
}