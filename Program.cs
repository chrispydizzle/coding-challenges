namespace CodeChallenges
{
    using System;
    using System.Collections;
    using DynamicProgramming;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var s = new CanPartitionSubsets();
            W(s.CanPartitionKSubsets(new[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 1));
            W(s.CanPartitionKSubsets(new[] {10, 10, 10, 7, 7, 7, 7, 7, 7, 6, 6, 6}, 3));
            W(s.CanPartitionKSubsets(new[] {1, 2, 3, 4}, 3));
            W(s.CanPartitionKSubsets(new[] {1, 2, 3, 4}, 3));

            /*W(s.MaxProduct(new[] {-2, 0, -1}));
            W(s.MaxProduct(new[] {1, 0, -1, 2, 3, -5, -2}));
            W(s.MaxProduct(new[] {2, 3, -2, 4}));
            W(s.MaxProduct(new[] {0, 2}));
            W(s.MaxProduct(new[] {2, -5, -2, -4, 3}));
            W(s.MaxProduct(new[] {7, -2, -4}));
            W(s.MaxProduct(new[] {-2, 3, -4}));
            W(s.MaxProduct(new[] {-1, -2, -9, -6}));*/
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