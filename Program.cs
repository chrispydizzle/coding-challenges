using System.Collections.Generic;
using CodeChallenges.BinaryTrees;
using CodeChallenges.DFS;
using CodeChallenges.Graphs;
using CodeChallenges.Interviews;

namespace CodeChallenges
{
    using System;
    using Arrays;
    using Strings;

    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new LongestPalindromeSubstring();

            W(s.LongestPalindrome("babad"));
            W(s.LongestPalindrome("cbbd"));
            
            var newS = new Acorns();
            W(newS.GetPreorderByRecursion(TreeNode.BuildTree(12, 9, 1, 7, 5, 2, null)));
            W(newS.GetPreorder(TreeNode.BuildTree(12, 9, 1, 7, 5, 2, null)));
            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}