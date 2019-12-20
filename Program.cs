using System.Collections.Generic;
using CodeChallenges.BinaryTrees;
using CodeChallenges.DFS;
using CodeChallenges.Graphs;
using CodeChallenges.Interviews;

namespace CodeChallenges
{
    using System;
    using Arrays;
    using DynamicProgramming;
    using Strings;

    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new LongestPalindromeSubstring();

            W(s.LongestPalindrome("babad"));
            W(s.LongestPalindrome("cbbd"));

            var newS = new MaximumSubArray();
            W(newS.MaxSubArray(new[] {-2, 1, -3, 4, -1, 2, 1, -5, 4, 10, -20, 7}));
            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}