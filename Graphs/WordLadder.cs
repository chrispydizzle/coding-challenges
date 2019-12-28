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

            result = FindLength(beginWord, endWord, words);
            return result;
        }

        private int FindLength(string currentWord, string endWord, HashSet<string> wordList)
        {
            Dictionary<string, HashSet<string>> connections = new Dictionary<string, HashSet<string>>();

            if (!wordList.Contains(endWord)) return 0;

            HashSet<string> visited = new HashSet<string>();

            int wordLength = endWord.Length;

            int distance = int.MaxValue;

            Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();

            queue.Enqueue(new Tuple<string, int>(currentWord, 1));

            while (queue.Any())
            {
                Tuple<string, int> placement = queue.Dequeue();

                int traveled = placement.Item2;
                if (traveled > distance) continue;

                // find the shortest path starting with each letter
                for (int i = 0; i < wordLength; i++)
                {
                    string changeTarget = placement.Item1.Remove(i, 1).Insert(i, "*");
                    if (visited.Contains(changeTarget)) continue;

                    visited.Add(changeTarget);
                    if (!connections.ContainsKey(changeTarget))
                    {
                        HashSet<string> steps = new HashSet<string>();
                        foreach (string s in wordList)
                        {
                            if (s == placement.Item1) continue;
                            string tempWord = s.Remove(i, 1).Insert(i, "*");
                            if (tempWord == changeTarget)
                            {
                                if (s == endWord)
                                {
                                    distance = Math.Min(distance, placement.Item2 + 1);
                                    Console.WriteLine($"Found a path: {distance}");
                                    break;
                                }

                                steps.Add(s);
                            }
                        }

                        connections.Add(changeTarget, steps);
                    }
                }

                // connections will now have every possible step from the given word to another word

                foreach (KeyValuePair<string, HashSet<string>> connection in connections)
                    if (connection.Value.Count > 0 && traveled + 1 < distance)
                        foreach (string s in connection.Value)
                            queue.Enqueue(new Tuple<string, int>(s, traveled + 1));
            }

            return distance == int.MaxValue ? 0 : distance;
        }
    }

/*
        private OldOne()
        {
            
            
            foreach (string word in wordList)


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
    }*/
}