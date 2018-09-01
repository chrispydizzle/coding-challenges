namespace Pdrome2.Solves
{
    using System.Collections.Generic;

    internal class FirstNonRepeatingCharacter
    {
        public char firstNotRepeatingCharacter(string s)
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();
            List<char> unique = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (chars.ContainsKey(c))
                {
                    chars[c]++;
                    unique.Remove(c);
                }
                else
                {
                    chars.Add(c, 1);
                    unique.Add(c);
                }
            }

            if (unique.Count > 0) return unique[0];

            return '_';
        }
    }
}