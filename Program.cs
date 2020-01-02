namespace CodeChallenges
{
    using System;
    using System.Collections;
    using System.Linq;
    using Strings;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            GetMinWindow s = new GetMinWindow();
            string res = s.MinWindow("a", "aa");

            res = s.MinWindow("ADOBECODEBANC", "ABC");
            W(res);
            if (!args.Any() || args[0] != "PROF") Console.ReadLine();
        }

        private static void W(object o)
        {
            if (o is IEnumerable)
                foreach (object v in o as IEnumerable)
                    Console.Write($"{v},");
            Console.WriteLine(o);
        }
    }
}