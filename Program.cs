namespace CodeChallenges
{
    using System;
    using System.Collections;
    using Interviews;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            /*
             * ["TicTacToe","move","move","move"]
[[2],[],[1,1,2],[1,0,1]]
             */
            Acorns.TicTacToe t = new Acorns.TicTacToe(2);
            W(t.Move(0, 0, 2));
            W(t.Move(0, 1, 1));
            W(t.Move(1, 1, 2));

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