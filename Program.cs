namespace CodeChallenges
{
    using System;
    using System.Collections;
    using BinaryTrees;
    using Sorts;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            FindFirstLastinSortedArray s = new FindFirstLastinSortedArray();
            W(s.SearchRange(new[] {0, 0, 2, 3, 4, 4, 4, 5}, 5));
            W(s.SearchRange(new[] {0, 0, 1, 2, 2}, 2));

            W(s.SearchRange(new[] {0, 0, 1, 1, 1, 4, 5, 5}, 2));

            W(s.SearchRange(new[] {0, 1, 2, 3, 4, 4, 4}, 2));
            W(s.SearchRange(new[] {1, 2, 3}, 3));
            W(s.SearchRange(new[] {1, 2, 3}, 3));
            W(s.SearchRange(new[] {2, 2}, 3));

            W(s.SearchRange(new[] {2, 2}, 2));
            W(s.SearchRange(new[] {1}, 1));

            W(s.SearchRange(new[] {5, 7, 7, 8, 8, 10}, 8));
            W(s.SearchRange(new[] {5, 7, 7, 8, 8, 10}, 6));
            W(s.SearchRange(new[] {1}, 0));
            W(s.SearchRange(new[] {1}, 1));
            Console.ReadLine();
        }

        public static void LCAMain(string[] args)
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