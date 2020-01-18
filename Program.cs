namespace CodeChallenges
{
    using System;
    using System.Collections;
    using Strings;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var s = new TestJustification();
            W(s.FullJustify(new[] {"This", "is", "an", "example", "of", "text", "justification."}, 16));
            W(s.FullJustify(new[] {"What", "must", "be", "acknowledgment", "shall", "be"}, 16));
            W(s.FullJustify(new[] {"Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do"}, 20));
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