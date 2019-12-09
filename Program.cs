namespace CodeChallenges
{
    using System;
    using BinaryTrees;

    internal class Program
    {
        public static void Main(string[] args)
        {
            BinaryTreeMaxPathSum s = new BinaryTreeMaxPathSum();

            TreeNode listNode = TreeNode.BuildTree(1, 2, 5, 3, 4, null, 6);
            listNode = TreeNode.BuildTree(1, null, 2, 3);
            listNode = TreeNode.BuildTree(4, 1, null, null, 3, 2);
            listNode = TreeNode.BuildTree(-10, 9, 20, null, null, 15, 7);
            listNode = TreeNode.BuildTree(1, -2, -3, 1, 3, -2, null, -1);
            W(s.MaxPathSum(listNode));

            listNode = TreeNode.BuildTree(1, 2, 3);
            W(s.MaxPathSum(listNode));

            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}