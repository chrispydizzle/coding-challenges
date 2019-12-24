namespace CodeChallenges.Graphs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WordLadder
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            int result = int.MinValue;
            // Okay, BFS

            HashSet<string> words = new HashSet<string>(wordList);

            Dictionary<string, HashSet<string>> jumpList = new Dictionary<string, HashSet<string>>();

            int smallest = int.MaxValue;
            result = FindLength(beginWord, endWord, words);
            return result;
        }

        public int FindLength(string currentWord, string endWord, HashSet<string> wordList)
        {
            Dictionary<string, HashSet<string>> connections = new Dictionary<string, HashSet<string>>();

            int wordLength = endWord.Length;

            foreach (string word in wordList)
                for (int i = 0; i < wordLength; i++)
                {
                    string changeTarget = word.Remove(i, 1).Insert(i, "*"); // word.Substring(0, i) + '*' + word.Substring(i + 1, wordLength);
                }


            HashSet<> 

            for (int i = 0; i < currentWord.Length; i++)
            {
                List<string> candidates = new List<string>();

                candidates.AddRange(wordList.Where(w =>
                {
                    if (currentWord == w) return false;

                    bool keep = false;
                    if (i > 0)
                        if (w.Substring(0, i) == currentWord.Substring(0, i))
                            keep = true;

                    if (i < endWord.Length - 1) keep = w.Substring(i + 1) == currentWord.Substring(i + 1);


                    return keep;
                }));


                // now candidates has all possible next steps. If the endword is there, return the depth of our stack plus one.

                if (candidates.Contains(endWord))
                    result = distance + 1;
                else
                    // otherwise try it again with all of those words and increase the depth
                    foreach (string candidate in candidates)
                    {
                        HashSet<string> newSet = new HashSet<string>(wordList);
                        newSet.Remove(candidate);
                        if (!newSet.Any()) return 0;
                        result = Math.Min(result, this.FindLength(candidate, endWord, newSet, distance + 1, ref smallestDistance));
                    }
            }

            result = smallestDistance = Math.Min(smallestDistance, result);

            // during dequeue, add all words in wordlist that are one change away from that one
            return result;
        }
    }
}