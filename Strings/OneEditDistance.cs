namespace CodeChallenges.Strings
{
    public class OneEditDistance
    {
        public bool IsOneEditDistance(string s, string t)
        {
            if (s.Length == t.Length - 1)
            {
                // insert
                for (int i = 0; i < t.Length; i++)
                {
                    char theChar = t[i];
                    if (i == t.Length - 1 || t[i] != s[i])
                    {
                        s = s.Insert(i, theChar.ToString());
                        return s == t;
                    }
                }
            }
            else if (s.Length == t.Length + 1)
            {
                // delete
                for (int i = 0; i < s.Length; i++)
                {
                    if (i == s.Length - 1 || t[i] != s[i])
                    {
                        s = s.Remove(i, 1);
                        return s == t;
                    }
                }
            }
            else if (s.Length == t.Length)
            {
                // replace    
                for (int i = 0; i < s.Length; i++)
                {
                    if (t[i] != s[i])
                    {
                        s = s.Remove(i, 1);
                        s = s.Insert(i, t[i].ToString());
                        return s == t;
                    }
                }
            }

            return false;
        }
    }
}