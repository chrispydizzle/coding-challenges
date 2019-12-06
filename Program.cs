namespace CodeChallenges
{
    using System;
    using Arrays;
    using Strings;

    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new ValidPalindrome();

            W(s.IsPalindrome("\"Sue,\" Tom smiles, \"Selim smote us.\""));
            

            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}