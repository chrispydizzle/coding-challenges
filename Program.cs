namespace CodeChallenges
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Design;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            NestedInteger n = new NestedInteger();
            NestedInteger n1 = new NestedInteger();
            NestedInteger n1a = new NestedInteger(1);
            NestedInteger n1b = new NestedInteger(1);
            n1.Add(n1a);
            n1.Add(n1b);

            NestedInteger n2 = new NestedInteger(2);

            NestedInteger n3 = new NestedInteger();
            NestedInteger n3a = new NestedInteger(1);
            NestedInteger n3b = new NestedInteger(1);
            n3.Add(n3a);
            n3.Add(n3b);

            n.Add(n1);
            n.Add(n2);
            n.Add(n3);
            NestedIterator s = new NestedIterator(n.GetList());
            List<int> l = new List<int>();
            while (s.HasNext()) l.Add(s.Next());
            W(l);
            Console.Read();
        }

        private static void W(object o)
        {
            if (o is IEnumerable enumerable && !(o is string s))
                foreach (object v in enumerable)
                    Console.Write($"{v},");

            Console.WriteLine(o);
        }
    }
}