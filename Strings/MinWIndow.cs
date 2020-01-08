namespace CodeChallenges.Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GetMinWindow
    {
        public string MinWindow(string s, string t)
        {
            if (s == t) return s;
            if (t == string.Empty || s == string.Empty) return string.Empty;
            int leftPointer = -1;
            int rightPointer = -1;


            Dictionary<char, int> requiredChars = new Dictionary<char, int>();
            Dictionary<char, int> foundChars = new Dictionary<char, int>();
            IEnumerable<KeyValuePair<char, int>> keyValuePairs = t.GroupBy(c => c).Select(g => new KeyValuePair<char, int>(g.Key, g.Count()));
            foreach (KeyValuePair<char, int> keyValuePair in keyValuePairs)
            {
                requiredChars.Add(keyValuePair.Key, keyValuePair.Value);
                foundChars.Add(keyValuePair.Key, 0);
            }

            Dictionary<char, int> immutableSet = new Dictionary<char, int>(requiredChars);

            string result = s + s;
            // bool foundFlag = false;
            while (leftPointer <= rightPointer)
            {
                leftPointer++;

                if (leftPointer > 0)
                {
                    char prevChar = s[leftPointer - 1];

                    if (immutableSet.ContainsKey(prevChar))
                    {
                        foundChars[prevChar]--;
                        int foundCount = foundChars[prevChar];
                        int requiredCount = immutableSet[prevChar];
                        if (foundCount < requiredCount) requiredChars[prevChar]++;
                    }
                }

                // while I don't have all the letters, go right until we hit the end of string.;
                int remainingRequiredChars = requiredChars.Sum(c => c.Value);


                while (remainingRequiredChars > 0 && rightPointer < s.Length - 1)
                {
                    rightPointer++;
                    char rightChar = s[rightPointer];
                    if (immutableSet.ContainsKey(rightChar))
                    {
                        foundChars[rightChar]++;
                        requiredChars[rightChar] = Math.Max(0, requiredChars[rightChar] - 1);
                    }

                    remainingRequiredChars = requiredChars.Sum(c => c.Value);
                    if (remainingRequiredChars == 0) break;
                }

                if (remainingRequiredChars == 0)
                {
                    int length = rightPointer - leftPointer + 1;
                    if (length < result.Length) result = s.Substring(leftPointer, length);
                }
            }

            return result == s + s ? string.Empty : result;
        }
    }
}