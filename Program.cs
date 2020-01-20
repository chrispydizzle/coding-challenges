namespace CodeChallenges
{
    using System;
    using System.Collections;
    using DynamicProgramming;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var s = new EditDistance();
            W(s.MinDistance("zoologicoarchaeologist", "zoogeologist"));
            W(s.MinDistance("hor", "ro"));
            W(s.MinDistance("horse", "ros"));
            W(s.MinDistance("intention", "execution"));
            W(s.MinDistance("chris", "nisha"));
        }

        private static void W(object o)
        {
            if (o is IEnumerable enumerable && !(o is string s))
            {
                foreach (object v in enumerable)
                {
                    W(v);
                }
            }

            Console.WriteLine($" Raw object: {o}");
        }
    }
}