namespace CodeChallenges
{
    using System;
    using System.Collections;
    using BinaryTrees;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var s = new BinaryTreeLca();
            TreeNode tree = TreeNode.BuildTree(3, 5, 1, 6, 2, 0, 8, null, null, 7, 4);
            W(s.LowestCommonAncestor(tree, new TreeNode(5), new TreeNode(4)).val);
            W(s.LowestCommonAncestor(tree, new TreeNode(5), new TreeNode(1)).val);
            W(s.LowestCommonAncestor(tree, new TreeNode(5), new TreeNode(4)).val);

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