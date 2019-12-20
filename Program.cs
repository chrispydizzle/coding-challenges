namespace CodeChallenges
{
    using System;
    using Sorts;
    using Strings;

    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new MergeSort();
            W(s.SortArray(new int[] {5, 2, 3, 1}));
            W(s.SortArray(new int[] {5, 1, 1, 2, 0, 0}));
            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}