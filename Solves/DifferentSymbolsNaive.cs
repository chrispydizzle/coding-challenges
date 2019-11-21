namespace CodeChallenges.Solves
{
    using System.Collections.Generic;
    using System.Linq;

    internal class DifferentSymbolsNaive
    {
        public int differentSymbolsNaive(string s)
        {
            HashSet<char> chars = new HashSet<char>();
            foreach (char c in s)
            {
                if (!chars.Contains(c))
                {
                    chars.Add(c);
                }
            }

            return chars.Count();
        }
    }
}