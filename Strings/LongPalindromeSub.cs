namespace CodeChallenges.Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;

    /// <summary>
    /// There's a much better solution:
    /// attached
    /// </summary>
    public class LongPalindromeSub
    {
        public string LongestPalindromeBad(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            var hs = new HashSet<(int, int)>();

            // try a new approach- go through the string first looking for all possible anchor points
            // then expand out each one until there is a clear winner, and keep growing him until he's maxed
            for (int i = 1; i < s.Length; i++)
            {
                // backcheck
                char c1 = s[i - 1];
                char c2 = s[i];
                if (c2 == c1) hs.Add((i - 1, 2));

                if (i < s.Length - 1)
                {
                    char c3 = s[i + 1];
                    if (c1 == c3) hs.Add((i - 1, 3));
                }
            }

            // gone through the entire string now, start expanding anchor points
            var hList = new Queue<(int, int)>(hs);
            if (!hList.Any()) return s[0].ToString();
            HashSet<string> candidates = new HashSet<string>();
            HashSet<string> visited = new HashSet<string>();
            while (hList.Any())
            {
                (int, int) center = hList.Dequeue();
                hs.Remove(center);
                int left = center.Item1;
                int distance = center.Item2;
                int right = left + distance - 1;

                string currentSub = s.Substring(left, distance);
                // if (visited.Contains(currentSub)) continue;

                // can grow?
                if (left > 0 && right < s.Length - 1)
                {
                    // try to grow
                    char nL = s[left - 1];
                    char nR = s[right + 1];

                    if (nL == nR)
                    {
                        // success here means he gets re-queued for further work
                        hList.Enqueue((left - 1, distance + 2));
                    }
                    else
                    {
                        // otherwise we pull him off the queue and add him to candidates
                        candidates.Add(currentSub);
                    }
                }
                else
                {
                    // keep as candidate but don't re-add to queue
                    candidates.Add(currentSub);
                }
            }

            return candidates.FirstOrDefault(c => c.Length == candidates.Max(m => m.Length));
        }

        private int startIndex;
        private int length;

        public string LongestPalindrome(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                //For odd length.
                this.ExtendPallindrome(s, i, i);

                //For even length.
                this.ExtendPallindrome(s, i, i + 1);
            }

            return s.Substring(this.startIndex, this.length);
        }

        private void ExtendPallindrome(string s, int start, int end)
        {
            while (start >= 0 && end < s.Length && s[start] == s[end])
            {
                start--;
                end++;
            }

            //When calculating newLength;
            //we will have to compensate for one reduction in start and one increment in end;
            //because of the while loop above.
            // ~ end - start -1
            int newLength = ((end - 1) - (start + 1)) + 1;

            if (this.length < newLength)
            {
                //When calculating startIndex; we will have to compensate for the reduction in start.
                this.startIndex = start + 1;
                this.length = newLength;
            }
        }
    }
}