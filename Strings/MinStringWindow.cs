namespace CodeChallenges.Strings
{
    using System.Collections.Generic;

    public class MinStringWindow
    {
        public string MinWindow(string s, string t)
        {
            string result = string.Empty;
            List<char> toFind = new List<char>(t.ToCharArray());

            Dictionary<char, int> charCounts = new Dictionary<char, int>();
            Dictionary<char, int> foundCounts = new Dictionary<char, int>();
            foreach (char c in toFind)
            {
                if (!charCounts.TryGetValue(c, out int count))
                {
                    count = 0;
                    foundCounts[c] = 0;
                }

                charCounts[c] = count + 1;
            }

            int leftPointer = 0;
            int rightPointer = 0;

            while (rightPointer < s.Length)
            {
                char newChar = s[rightPointer];
                bool successWindow = false;

                if (charCounts.ContainsKey(newChar))
                {
                    successWindow = true;
                    foundCounts[newChar]++;

                    foreach (KeyValuePair<char, int> requriedCount in charCounts)
                    {
                        if (foundCounts[requriedCount.Key] < requriedCount.Value)
                        {
                            successWindow = false;
                            break;
                        }
                    }
                }

                while (leftPointer <= rightPointer && successWindow)
                {
                    if (result == string.Empty || rightPointer - leftPointer + 1 < result.Length)
                    {
                        result = s.Substring(leftPointer, rightPointer - leftPointer + 1);
                    }

                    char oldChar = s[leftPointer];
                    if (charCounts.ContainsKey(oldChar))
                    {
                        foundCounts[oldChar]--;

                        foreach (KeyValuePair<char, int> requriedCount in charCounts)
                        {
                            if (foundCounts[requriedCount.Key] < requriedCount.Value)
                            {
                                successWindow = false;
                                break;
                            }
                        }
                    }

                    leftPointer++;
                }

                rightPointer++;
            }

            return result;
        }
    }
}