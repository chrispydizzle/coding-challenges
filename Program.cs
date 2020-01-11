namespace CodeChallenges
{
    using System;
    using System.Collections;
    using Arrays;
    using BinaryTrees;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            MergeIntervals s = new MergeIntervals();

            LowestCommonAncestorBST s = new LowestCommonAncestorBST();
            TreeNode tn = TreeNode.BuildTree(6, 2, 8, 0, 4, 7, 9, null, null, 3, 5);
            s.LowestCommonAncestor(tn, new TreeNode(2), new TreeNode(8));
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