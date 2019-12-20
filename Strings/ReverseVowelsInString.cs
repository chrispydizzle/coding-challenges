namespace CodeChallenges.Strings
{
    using System.Collections.Generic;
    using System.Text;

    public class ReverseVowelsInString
    {
        public string ReverseVowels(string s)
        {
            StringBuilder b = new StringBuilder();
            List<char> invalids = new List<char> {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
            Stack<char> foundVowels = new Stack<char>();

            foreach (char c in s)
                if (invalids.Contains(c))
                    foundVowels.Push(c);

            foreach (char t in s) b.Append(invalids.Contains(t) ? foundVowels.Pop() : t);

            return b.ToString();
        }
    }
}