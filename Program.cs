namespace CodeChallenges
{
    using System;
    using System.Collections;
    using DynamicProgramming;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var s = new PaintHous();
            W(s.MinCost(new[] {new[] {17, 2, 17}, new[] {16, 16, 5}, new[] {14, 3, 19}}));
            Console.ReadLine();
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