namespace CodeChallenges
{
    using System;
    using System.Collections.Generic;
    using Arrays;
    using Strings;

    internal class Program
    {
        public static void Main(string[] args)
        {
            RemoveDupes sa = new RemoveDupes();
            int[] array = new[] {0, 0, 1, 1, 1, 2, 2, 3, 3, 4};
            int[] array2 = new[] { 1, 1, 2 };
            int removeDuplicates = sa.RemoveDuplicates(array2);

            W(removeDuplicates);
            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}