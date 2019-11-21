namespace CodeChallenges
{
    using System.Collections.Generic;
    using System.Linq;

    public class AngramGrouper
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> result = new List<IList<string>>();
            Queue<string> q = new Queue<string>(strs);
            while (q.Any())
            {
                string s = q.Dequeue();
                List<string> r = new List<string>();
                r.Add(s);
                Dictionary<char, int> dictionary = s.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
                this.GroupAnagrams(dictionary, q, r, result);
            }

            return result;
        }

        private void GroupAnagrams(Dictionary<char, int> dictionary, Queue<string> queue, List<string> list, List<IList<string>> result)
        {
            while (queue.Any())
            {
                string s = queue.Dequeue();
                Dictionary<char, int> cDictionary = s.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
                bool found = true;
                foreach (KeyValuePair<char, int> keyValuePair in dictionary)
                {
                    if (!cDictionary.ContainsKey(keyValuePair.Key) || cDictionary[keyValuePair.Key] != keyValuePair.Value)
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    list.Add(s);
                }
                else
                {
                    List<string> sL = new List<string>();
                    sL.Add(s);
                    this.GroupAnagrams(cDictionary, queue, sL, result);
                }
            }

            result.Add(list);
        }
    }
}