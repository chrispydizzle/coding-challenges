namespace CodeChallenges
{
    using System;
    using Strings;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            ReverseVowelsInString s = new ReverseVowelsInString();
            W(s.ReverseVowels("hello"));
            W(s.ReverseVowels("leetcode"));

            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}