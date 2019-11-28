namespace CodeChallenges.Strings
{
    using System.Collections.Generic;

    internal class LongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {
            // iterate through the string for starting points
            // set your current longest length
            int longest = 0;
            for (int i = 0; i < s.Length; i++)
            {
                // create a hashset to track characters you've found
                HashSet<char> set = new HashSet<char>();

                // track current substring length
                int substringLength = 0;
                // loop through characters from i until end
                for (int j = i; j < s.Length; j++)
                {
                    // check if set contains current character
                    char currentChar = s[j];
                    if (set.Contains(currentChar))
                    {
                        // break if so
                        break;
                    }

                    // if no, add current character to set
                    set.Add(currentChar);
                    // increase substring length
                    substringLength++;
                }

                // check if current length > longest and set to longest if so
                if (substringLength > longest) longest = substringLength;
            }

            return longest;
        }
    }
}