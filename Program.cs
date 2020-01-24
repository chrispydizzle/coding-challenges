namespace CodeChallenges
{
    using System;
    using System.Collections;
    using Arrays;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var s = new SubarraySumK();
            W(s.SubarraySum(new[] {1, 1, 1}, 2));
            W(s.SubarraySum(new[] {1, 2, 5, -10, -20, 15, 2, 2, 2, 6, -2, 1, 1}, 2));
            W(s.SubarraySum(new[] {1, 2, 5, -10, -20, 15, 2, 2, 2, 6, -2, 1, 1}, -2));
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