namespace CodeChallenges
{
    using System;
    using System.Collections;
    using Design;
    using Interviews;

    internal static class Program
    {
        public static void MainVC(string[] args)
        {
            Acorns.ZeroSum s = new Acorns.ZeroSum();
            W(s.HasValidCombo(new[] {6, 1, 3, 7, -2, -1}, 0));
            W(s.HasValidCombo(new[] {12, 3, 7, -2, 1}, 0));
        }

        public static void Main(string[] args)
        {
            NestedListWeightSum2 s = new NestedListWeightSum2();
            // [[1,1],2,[1,1]]

            NestedInteger n = new NestedInteger();
            NestedInteger n1 = new NestedInteger();
            NestedInteger nx1 = new NestedInteger(1);
            NestedInteger nx2 = new NestedInteger(1);
            n1.Add(nx1);
            n1.Add(nx2);

            NestedInteger n2 = new NestedInteger(2);

            NestedInteger n3 = new NestedInteger();
            n3.Add(new NestedInteger(1));
            n3.Add(new NestedInteger(1));


            n.Add(n1);
            n.Add(n2);
            n.Add(n3);

            W(s.DepthSumInverse(n.GetList()));

            NestedInteger a = new NestedInteger();
            NestedInteger a1 = new NestedInteger(1);
            a.Add(a1);

            NestedInteger a2 = new NestedInteger();
            NestedInteger ax2 = new NestedInteger(4);
            a2.Add(ax2);

            NestedInteger a3 = new NestedInteger();
            NestedInteger ax3 = new NestedInteger(6);
            a3.Add(ax3);

            a2.Add(a3);
            a.Add(a2);

            W(s.DepthSumInverse(a.GetList()));

            Console.Read();
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