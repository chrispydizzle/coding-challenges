namespace CodeChallenges.DynamicProgramming
{
    using System.Collections.Generic;
    using System.Linq;

    public class WordSearch
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            // No validation required because:
            // "Given a non-empty string s and a dictionary wordDict containing a list of non-empty words"


            // Because this is a DP problem, the hint is in the worddict.
            // To apply DP, first let's start trying combinations of different words with each other.

            // We can set up a 2D table for this, where each word corresponds to another word. their
            // intersections will be the result of substracting both from the string s
            // like given applepenapple
            // apple    pen
            // pen      ""        appleapple
            //        apple      pen

            // first key is left side of table, second key is bottom of table, value is result.
            // this will take a bit more. The dictionary needs to be somewhat flexible.

            // we are going to have to make at least two? passes at the string.
            // Hmm. A better way might be to make a list of strings the value, and let the key = every word that fits inside.
            // then we avoid duplicating efforts by only keeping useful words, and if the answer exists it will be in one of our sets.

            // this example: Input: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
            // pass one results in a dict of
            // cats -> <andog, [dog, and]>,
            // dog -> <catsan, [cats,dog,and,cat]>
            // sand -> <catog, [cat]>
            // and -> <catsog, [cats,cat]>
            // cat -> <sandog, [dog, sand, and]>
            // pass two results in
            // [andog, [dog,and]] -> [],
            // [catsan, [cats,dog,and,cat] -> [],
            // [catog, [cat] -> []
            // [catsog, [cats,cat]] -> []
            // [sandog, [dog, sand, and]] -> []

            // think this approach will work
            // Dictionary<string, List<string>> table = new Dictionary<string, List<string>>();

            Queue<(string, HashSet<string>)> q = new Queue<(string, HashSet<string>)>();

            HashSet<string> hs = new HashSet<string>(wordDict.Where(s.Contains));

            foreach (string s1 in hs)
            {
                // queue the new reslult, and any words that still fit inside
                string candidate = s.Replace(s1, " ");
                if (string.IsNullOrWhiteSpace(candidate))
                {
                    return true;
                }

                HashSet<string> newSet = new HashSet<string>(hs.Where(candidate.Contains));
                q.Enqueue((candidate, newSet));
            }

            while (q.Any())
            {
                (string, HashSet<string>) dQ = q.Dequeue();
                string c = dQ.Item1;
                HashSet<string> ns = dQ.Item2;
                foreach (string s1 in ns)
                {
                    // queue the new reslult, and any words that still fit inside
                    string candidate = c.Replace(s1, " ");
                    if (string.IsNullOrWhiteSpace(candidate))
                    {
                        return true;
                    }

                    HashSet<string> newSet = new HashSet<string>(ns.Where(candidate.Contains));
                    q.Enqueue((candidate, newSet));
                }
            }


            // We can quit if the string will no longer change and we have exhausted the possiblitiies or
            // the string is empty.
            return false;
        }
    }
}