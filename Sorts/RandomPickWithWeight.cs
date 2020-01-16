namespace CodeChallenges.Sorts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RandomPickWithWeight2
    {
        private readonly Random _rnd = new Random();
        private readonly int[] _weightSum;

        public RandomPickWithWeight2(int[] w)
        {
            // in C#, Array.BinarySearch will return a bitwise opposite of the closest array value, if it cannot find
            // the one you searched. If you "~" (Bitwise OR) this value you'll get the closest index.
            _weightSum = new int[w.Length];
            int max = 0;
            for (int i = 0; i < w.Length; i++)
            {
                max += w[i];
                _weightSum[i] = max;
            }
        }

        public int PickIndex()
        {
            int idx = _rnd.Next(0, _weightSum.Last()) + 1;
            int res = Array.BinarySearch(_weightSum, idx);
            return res >= 0 ? res : ~res;
        }
    }

    public class RandomPickWithWeight
    {
        private readonly List<int> weighted = new List<int>();
        private Random r = new Random();
        public int seed;

        // Brute Method
        public RandomPickWithWeight(int[] w)
            : this(0, w)
        {
        }

        public RandomPickWithWeight(int r, int[] w)
        {
            this.r = new Random(r);
            for (int i = 0; i < w.Length; i++) weighted.AddRange(Enumerable.Repeat(i, w[i]));
        }

        public void IncSeed()
        {
            r = new Random(++seed);
        }

        public int PickIndex()
        {
            return weighted[r.Next(0, weighted.Count)];
        }
    }
}