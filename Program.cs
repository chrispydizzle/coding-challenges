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
            ThreeSum ts = new ThreeSum();
            IList<IList<int>> threeSum = ts.GetThreeSum(new[] {-1, 0, 1, 2, -1, -4});
            W(threeSum);
            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}