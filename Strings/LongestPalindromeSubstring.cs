namespace CodeChallenges.Strings
{
    using System;

    public class LongestPalindromeSubstring
    {
        // TODO: Do the DP version.
        // TODO: Understand this solution
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            string result = string.Empty;

            int start = 0, end = 0;

            for (int i = 0; i <= (s.Length - (result.Length / 2)); i++)
            {
                int length = 0;
                length = expand(s, i, i);
                if (i + 1 < s.Length)
                {
                    length = Math.Max(length, expand(s, i, i + 1));
                }

                if (length > end - start)
                {
                    start = i - (length - 1) / 2;
                    end = i + length / 2;
                    result = s.Substring(start, length);
                }
            }

            return result;
        }

        private int expand(string s, int left, int right)
        {
            int L = left;
            int R = right;
            while (L >= 0 && R < s.Length && s[L] == s[R])
            {
                L--;
                R++;
            }

            return R - L - 1;
        }
    }
}