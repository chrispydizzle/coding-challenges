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
            var s = new FlattenBSTToLinkedList();

            TreeNode listNode = TreeNode.BuildTree(1, 2, 5, 3, 4, null, 6);
            listNode = TreeNode.BuildTree(1, null, 2, 3);
            listNode = TreeNode.BuildTree(4, 1, null, null, 3, 2);

            s.Flatten(listNode);

            
            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}