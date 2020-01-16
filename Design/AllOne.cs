namespace CodeChallenges.Design
{
    using System.Collections.Generic;
    using System.Linq;

    public class AllOne
    {
        private readonly Dictionary<string, int> keyset;

        private Dictionary<int, HashSet<string>> keysetReverse;

        // going to set up variables to hold the min/max keyval && key
        private string maxKey = string.Empty;
        private string minKey = string.Empty;

        /**
         * Initialize your data structure here.
         */
        public AllOne()
        {
            // TODO: Not optimal, apparantely this can be done in O(1) time.
            keyset = new Dictionary<string, int>();
        }

        /**
         * Inserts a new key  with value 1. Or increments an existing key by 1.
         */
        public void Inc(string key)
        {
            if (!keyset.ContainsKey(key)) keyset.Add(key, 0);

            keyset[key]++;
        }

        /**
         * Decrements an existing key by 1. If Key's value is 1, remove it from the data structure.
         */
        public void Dec(string key)
        {
            if (keyset.ContainsKey(key))
            {
                if (keyset[key] == 1)
                    keyset.Remove(key);
                else
                    keyset[key]--;
            }
        }

        /**
         * Returns one of the keys with maximal value.
         */
        public string GetMaxKey()
        {
            return keyset.Where(d => d.Value == keyset.Values.Max()).Select(c => c.Key).FirstOrDefault() ?? string.Empty;
        }

        /**
         * Returns one of the keys with Minimal value.
         */
        public string GetMinKey()
        {
            return keyset.Where(d => d.Value == keyset.Values.Min()).Select(c => c.Key).FirstOrDefault() ?? string.Empty;
        }
    }
}