namespace CodeChallenges
{
    using System;
    using System.Collections;
    using Arrays;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            MergeIntervals s = new MergeIntervals();

            //var test = new[] {new[] {1, 3}, new[] {2, 6}, new[] {8, 10}, new[] {15, 18}};
            int[][] test = new[] {new[] {2, 3}, new[] {4, 5}, new[] {6, 7}, new[] {8, 9}, new[] {1, 10}};
            s.Merge(test);
            Console.Read();
        }

        private static void W(object o)
        {
            if (o is IEnumerable enumerable && !(o is string s))
                foreach (object v in enumerable)
                    Console.Write($"{v},");

            Console.WriteLine(o);
        }
    }
}