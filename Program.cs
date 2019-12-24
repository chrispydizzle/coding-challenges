namespace CodeChallenges
{
    using System;
    using System.Collections.Generic;
    using Graphs;

    public static class Program
    {
        public static void Main(string[] args)
        {
            WordLadder s = new WordLadder();
            W(s.LadderLength("hit", "cog", new List<string> {"hot", "dot", "dog", "lot", "log", "cog"}));

            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}