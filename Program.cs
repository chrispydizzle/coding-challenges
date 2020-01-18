namespace CodeChallenges
{
    using System;
    using System.Collections;
    using Recursion;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var s = new FactorCombinations();
            W(s.GetFactors(392832));

            W(s.GetFactors(1787866));
            W(s.GetFactors(7000));
            W(s.GetFactors(32));


            W(s.GetFactors(14));
            W(s.GetFactors(32));
            W(s.GetFactors(15));

            W(s.GetFactors(6));

            // W();


            Console.Read();
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