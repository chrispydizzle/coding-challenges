namespace CodeChallenges.Strings
{
    using System.Collections.Generic;
    using System.Text;

    public class IsomorphicStrings
    {
        public bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> charSwaps = new Dictionary<char, char>();

            StringBuilder b = new StringBuilder();
            if (s.Length > 0 && s.Length == t.Length)
            {
                int pointer = 0;

                while (pointer < s.Length - 1 || b.Length < t.Length)
                {
                    char sC = s[pointer];
                    char sT = t[pointer];
                    char rC;

                    if (sC != sT)
                    {
                        // we wanna swap the chars if they're different, but we have to validate a few things:
                        // 1. do we already have a swap char for this char?
                        // 2. Have we swapped another character for this character, or used the character as the target in another swap?
                        if (!(charSwaps.ContainsKey(sC) || charSwaps.ContainsValue(sT)))
                        {
                            // if not, add the mapping.
                            charSwaps.Add(sC, sT);
                            rC = sT;
                        }
                        else
                        {
                            // otherwise, validate that we have the key, and that it maps to the same value, or that we don't have the value yet.
                            if (charSwaps.ContainsKey(sC) && charSwaps[sC] != sT || charSwaps.ContainsValue(sT) && !charSwaps.ContainsKey(sC)) return false;

                            rC = charSwaps[sC];
                            if (rC != sT) return false;
                        }
                    }
                    else
                    {
                        if (!charSwaps.ContainsKey(sC)) charSwaps.Add(sC, sT);

                        rC = charSwaps[sC];
                    }

                    b.Append(rC);
                    pointer++;
                }
            }

            return b.ToString() == t;
        }
    }
}