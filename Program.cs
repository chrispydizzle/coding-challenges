namespace CodeChallenges
{
    using System;
    using Strings;

    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new LongestPalindromeSubstring();

            W(s.LongestPalindrome("babad"));
            W(s.LongestPalindrome("cbbd"));
            W(s.LongestPalindrome("ccc"));
            W(s.LongestPalindrome("ababababa"));

            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}