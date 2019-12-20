namespace CodeChallenges
{
    using System;
    using DynamicProgramming;
    using Strings;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var s = new EditDistance();
            W(s.MinDistance("horse", "ros"));
            W(s.MinDistance("intention", "execution"));

            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}