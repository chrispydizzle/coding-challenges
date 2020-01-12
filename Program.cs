namespace CodeChallenges
{
    using System;
    using System.Collections;
    using BinaryTrees;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            LowestCommonAncestorBST s = new LowestCommonAncestorBST();
            TreeNode tn = TreeNode.BuildTree(6, 2, 8, 0, 4, 7, 9, null, null, 3, 5);
            TreeNode tn5 = TreeNode.BuildTree(5, 3, 6, 2, 4, null, null, 1);
            TreeNode tn1 = TreeNode.BuildTree(2, 1);

            TreeNode tn3 = TreeNode.BuildTree(3, 1, 4, null, 2);


            W(s.LowestCommonAncestor(tn, new TreeNode(2), new TreeNode(5)));
            W(s.LowestCommonAncestor(tn, new TreeNode(7), new TreeNode(9)));

            W(s.LowestCommonAncestor(tn, new TreeNode(3), new TreeNode(5)));

            W(s.LowestCommonAncestor(tn, new TreeNode(2), new TreeNode(4)));

            W(s.LowestCommonAncestor(tn5, new TreeNode(1), new TreeNode(4)));
            W(s.LowestCommonAncestor(tn, new TreeNode(2), new TreeNode(8)));
            W(tn.ToStringFancy());

            W(s.LowestCommonAncestor(tn3, new TreeNode(2), new TreeNode(4)));
            W(s.LowestCommonAncestor(tn3, new TreeNode(2), new TreeNode(3)));
            Console.Read();
        }

        private static void W(object o)
        {
            if (o is IEnumerable enumerable && !(o is string s))
                foreach (object v in enumerable)
                    Console.Write($"{v},");

            Console.WriteLine($" Raw object: ${o}");
        }
    }
}