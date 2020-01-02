namespace CodeChallenges.Strings
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class WildListFix
    {
        private readonly string path;

        public WildListFix(string path)
        {
            this.path = path;
        }

        public void Process(string pathOut)
        {
            string[] readAllText = File.ReadAllLines(path);
            foreach (string s in readAllText)
            {
            }
        }
    }

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