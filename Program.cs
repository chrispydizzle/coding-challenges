namespace CodeChallenges
{
    using System;
    using DynamicProgramming;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            SearchInRotatedSortedArray s = new SearchInRotatedSortedArray();
            W(s.Search(new[] {4, 5, 6, 7, 0, 1, 2}, 0));
            W(s.Search(new[] {4, 5, 6, 7, 0, 1, 2}, 3));
            W(s.Search(new[] {1, 3}, 3));

            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}