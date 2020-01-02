namespace CodeChallenges.Strings
{
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


            List<char> requiredChars = t.ToCharArray().ToList();
            List<char> immutableSet = new List<char>(requiredChars);
            List<char> foundChars = new List<char>();

            string result = s;
            while (leftPointer <= rightPointer)
            {
                leftPointer++;

                if (leftPointer > 0)
                {
                    char prevChar = s[leftPointer - 1];

                    if (immutableSet.Contains(prevChar))
                    {
                        foundChars.Remove(prevChar);
                        int foundCount = foundChars.Count(c => c == prevChar);
                        int requiredCount = immutableSet.Count(c => c == prevChar);
                        if (foundCount < requiredCount) requiredChars.Add(prevChar);
                    }
                }

                // while I don't have all the letters, go right until we hit the end of string.;
                while (requiredChars.Any() && rightPointer < s.Length - 1)
                {
                    rightPointer++;
                    char rightChar = s[rightPointer];
                    if (immutableSet.Contains(rightChar))
                    {
                        foundChars.Add(rightChar);
                        requiredChars.Remove(rightChar);
                    }

                    if (requiredChars.Count == 0) break;
                }

                if (!requiredChars.Any())
                {
                    string potential = s.Substring(leftPointer, rightPointer - leftPointer + 1);
                    result = result.Length < potential.Length ? result : potential;
                }
            }

            return result == s + s ? string.Empty : result;
        }
    }
}