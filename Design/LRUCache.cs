namespace CodeChallenges.Design
{
    using System.Collections.Generic;

    //Follow up:
    // Could you do both operations in O(1) time complexity?

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
    public class LRUCache
    {
        HashSet<int> hs = new HashSet<int>();
        Dictionary<int, int> lru = new Dictionary<int, int>();
        private int max = 0;
        List<int> q = new List<int>();

        public LRUCache(int capacity)
        {
            max = capacity;
        }

        public int Get(int key)
        {
            int result = -1;
            if (lru.ContainsKey(key))
            {
                result = lru[key];
                q.Remove(key);
                q.Insert(0, key);
            }

            return result;
        }

        public void Put(int key, int value)
        {
            if (this.lru.ContainsKey(key))
            {
                q.Remove(key);
                this.lru.Remove(key);
            }

            if (q.Count == max)
            {
                int killKey = q[q.Count - 1];
                q.RemoveAt(q.Count - 1);
                this.lru.Remove(killKey);
            }

            q.Insert(0, key);
            this.lru[key] = value;
        }
    }
}