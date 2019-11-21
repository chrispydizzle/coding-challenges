namespace CodeChallenges.Solves
{
    using System.Collections.Generic;

    public class AllLongestStrings
    {
        public static string[] test1 = {"aba", "aa", "ad", "vcd", "aba"};

        public string[] allLongestStrings(string[] inputArray)
        {
            int longestRunning = 0;
            List<string> longStrings = new List<string>();
            foreach (string s in inputArray)
            {
                if (s.Length > longestRunning)
                {
                    longStrings.Clear();
                    longestRunning = s.Length;
                }

                if (s.Length == longestRunning)
                {
                    longStrings.Add(s);
                }
            }

            return longStrings.ToArray();
        }
    }
}