namespace CodeChallenges.Arrays
{
    using System;

    public class ShortestStringArrayDifference
    {
        public int ShortestDistance(string[] words, string word1, string word2)
        {
            int i1, minDistance, i2;
            i1 = i2 = minDistance = int.MaxValue;
            for (int i = 0; i < words.Length; i++)
                if (words[i] == word1)
                {
                    i1 = i;
                    minDistance = Math.Min(minDistance, Math.Abs(i1 - i2));
                }
                else if (words[i] == word2)
                {
                    i2 = i;
                    minDistance = Math.Min(minDistance, Math.Abs(i1 - i2));
                }

            return minDistance;
        }
    }
}