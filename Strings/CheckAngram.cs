namespace Pdrome2
{
    using System.Collections.Generic;
    using System.Linq;

    public class CheckAngram
    {
        public bool IsAnagram(string s, string t)
        {
            if (s == t) return true;
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)
                                        || s.Length != t.Length) return false;
            // build a dictionary with all of the characters in the first string 

            Dictionary<char, int> groupedS = s.GroupBy(c => c) // put each character into a "bucket"
                // then convert to dictionary where key = character, value = count
                .ToDictionary(grp => grp.Key, grp => grp.Count());

            // build a dictionary with all of the characters in the second string 
            Dictionary<char, int> groupedT = t.GroupBy(c => c) // put each character into a "bucket"
                // then convert to dictionary where key = character, value = count
                .ToDictionary(grp => grp.Key, grp => grp.Count());
            foreach (KeyValuePair<char, int> g in groupedS)
            {
                if (groupedT.ContainsKey(g.Key)
                    && groupedT[g.Key] == groupedS[g.Key])
                {
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}