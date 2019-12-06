namespace CodeChallenges.Strings
{
    using System.Collections.Generic;
    using System.Linq;

    public class LongestSubstringKDistinct
    {
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            int result = 0;

            List<char> chars = new List<char>();
            HashSet<char> uniqueChars = new HashSet<char>();

            int leftPointer = 0;
            int rightPointer = 0;

            while (rightPointer < s.Length)
            {
                char newChar = s[rightPointer];

                bool successWindow = false;

                chars.Add(newChar);
                if (uniqueChars.Add(newChar))
                {
                    if (uniqueChars.Count() <= k)
                    {
                        successWindow = true;
                    }
                }
                else
                {
                    successWindow = true;
                }

                if (successWindow)
                {
                    if (rightPointer - leftPointer + 1 > result)
                    {
                        result = rightPointer - leftPointer + 1;
                    }
                }

                while (leftPointer <= rightPointer && !successWindow)
                {
                    char oldChar = s[leftPointer];

                    chars.Remove(oldChar);

                    if (!chars.Contains(oldChar))
                    {
                        uniqueChars.Remove(oldChar);
                    }

                    successWindow = false;

                    if (uniqueChars.Count() <= k)
                    {
                        successWindow = true;
                    }

                    leftPointer++;
                }

                rightPointer++;
            }

            return result;
        }
    }
}