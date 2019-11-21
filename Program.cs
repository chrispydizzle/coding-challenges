namespace CodeChallenges
{
    using System;
    using Strings;

    internal class Program
    {
        public static void Main(string[] args)
        {
            FbLookAndSay f = new FbLookAndSay();
            W(f.LookAndSay(10));
            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}