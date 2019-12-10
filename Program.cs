using CodeChallenges.BinaryTrees;

namespace CodeChallenges
{
    using System;
    using Arrays;
    using Strings;

    internal class Program
    {
        public static void Main(string[] args)
        {
            BinaryTreeMaxPathSum s = new BinaryTreeMaxPathSum();

            TreeNode listNode = TreeNode.BuildTree(-10, 9, 20, null, null, 15, 7);
            W(s.MaxPathSum(listNode));

            listNode = TreeNode.BuildTree(1, 2, 3);
            W(s.MaxPathSum(listNode));

            listNode = TreeNode.BuildTree(-2, 6, null, 0, -6);
            W(s.MaxPathSum(listNode));

            listNode = TreeNode.BuildTree(-3);
            W(s.MaxPathSum(listNode));
            
            listNode = TreeNode.BuildTree(-2, 1);
            W(s.MaxPathSum(listNode));

            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}