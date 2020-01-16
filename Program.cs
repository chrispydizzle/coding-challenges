namespace CodeChallenges
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Recursion;
    using Stack;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var s = new Permutations();
            W(s.Permute(new[] {1, 2, 3}));
            Console.Read();
        }

        private static void W(object o)
        {
            if (o is IEnumerable enumerable && !(o is string s))
                foreach (object v in enumerable)
                    Console.Write($"{v},");

            Console.WriteLine($" Raw object: {o}");
        }
    }
}