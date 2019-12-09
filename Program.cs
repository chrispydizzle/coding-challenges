namespace CodeChallenges
{
    using System;
    using Arrays;
    using BinaryTrees;
    using LinkedList;
    using Strings;

    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new ValidateBinarySearchTree();

            TreeNode listNode = TreeNode.BuildTree(5, 1, 4, null, null, 3, 6);
            

            W(s.IsValidBST(listNode));

            W(s.IsValidBST(TreeNode.BuildTree(2, 1, 3)));
            
            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}