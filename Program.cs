namespace CodeChallenges
{
    using System;
    using System.Collections;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            MyHashMap s = new MyHashMap();
            s.Put(1, 1);
            s.Put(2, 2);
            W(s.Get(1));
            W(s.Get(3));
            s.Put(2, 1);
            W(s.Get(2));
            s.Remove(2);
            W(s.Get(2));
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