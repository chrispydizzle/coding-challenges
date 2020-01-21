namespace CodeChallenges
{
    using System;
    using System.Collections;

    internal static class Program
    {
        public static void Main(string[] args)
        {
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