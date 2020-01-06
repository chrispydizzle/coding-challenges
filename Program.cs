namespace CodeChallenges
{
    using System;
    using System.Collections;
    using BinaryTrees;
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
            BTreeLeaves s = new BTreeLeaves();
            W(s.FindLeaves(TreeNode.BuildTree(4, 1, null, 2, null, 3)));
            W(s.FindLeaves(TreeNode.BuildTree(1, 2, 3, 4, 5)));
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