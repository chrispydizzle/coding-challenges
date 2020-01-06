namespace CodeChallenges.Design
{
    using System;
    using System.Collections.Generic;

    public class WordDistance
    {
        private readonly Dictionary<string, SortedSet<int>> wordPlace = new Dictionary<string, SortedSet<int>>();

        public WordDistance(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (!wordPlace.ContainsKey(words[i])) wordPlace.Add(words[i], new SortedSet<int>());

                wordPlace[words[i]].Add(i);
            }
        }

        public int Shortest(string word1, string word2)
        {
            // sliding window? yes
            int leftCounter = 0;
            int rightCounter = 1;

            SortedSet<int> w1List = wordPlace[word1];
            SortedSet<int> w2List = wordPlace[word2];

            int result = int.MaxValue;
            foreach (int i in w1List)
            foreach (int j in w2List)
                result = Math.Min(Math.Abs(i - j), result);

            // semi-brute would have me go through each list, let's try that first
            return result;
        }
    }
}