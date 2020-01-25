namespace CodeChallenges
{
    using System;
    using System.Collections;
    using DynamicProgramming;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var s = new ChangeCoins();
            W(s.CoinChange(new[] {186, 419, 83, 408}, 6249));
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