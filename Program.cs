namespace CodeChallenges
{
    using System;
    using Arrays;
    using Strings;

    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new ValidPalindrome2();


            W(s.ValidPalindrome("abc"));
            W(s.ValidPalindrome("eccer"));
            W(s.ValidPalindrome("cbbcc"));
            W(s.ValidPalindrome("ebcbbececabbacecbbcbe"));
            

            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}