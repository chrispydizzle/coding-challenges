namespace Pdrome2
{
    using System.Collections.Generic;

    public class FindFirstUniqCharacter
    {
        public int FirstUniqChar(string s)
        {
            if (string.IsNullOrEmpty(s)) return -1;

            HashSet<char> duped = new HashSet<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (duped.Contains(s[i]))
                {
                    continue;
                }

                string subStringCheck = s.Substring(i + 1);
                
                if (!subStringCheck.Contains(s[i].ToString())) return i;

                duped.Add(s[i]);
            }

            return -1;
        }
    }
}