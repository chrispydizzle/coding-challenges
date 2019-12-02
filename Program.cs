namespace CodeChallenges
{
    using System;
    using Strings;

    internal class Program
    {
        public static void Main(string[] args)
        {
            MinStringWindow s = new MinStringWindow();

            string result = s.MinWindow("ask_not_what_your_country_can_do_for_you_ask_what_you_can_do_for_your_country", "ask_country");

            W(result);
            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}