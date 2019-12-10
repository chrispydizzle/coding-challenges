using CodeChallenges.BinaryTrees;
using CodeChallenges.Graphs;

namespace CodeChallenges
{
    using System;
    using Arrays;
    using Strings;

    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new BTreeRightSideView();

            TreeNode listNode = TreeNode.BuildTree(1, 2);
            W(s.RightSideView(listNode));

            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}