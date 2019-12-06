namespace CodeChallenges
{
    using System;
    using Arrays;
    using Strings;

    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new IntegerToEnglish();
            var result = s.NumberToWords(1001);
            result = s.NumberToWords(10000);
            result = s.NumberToWords(100000);
            // W(s.IsOneEditDistance("ba", "a"));


            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}