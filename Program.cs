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
            var s = new Facebook();

            int[][] result = s.KClosest(new[] { new[]{1, 3}, new[]{-2, 2}}, 1);
            result = s.KClosest(new[] { new[] {3,3},new[] {5,-1},new[] {-2,4}}, 2);
            result = s.KClosest(new[] {new[] {68,97},new[] {34,-84},new[] {60,100},new[] {2,31},new[] {-27,-38},new[] {-73,-74},new[] {-55,-39},new[] {62,91},new[] {62,92},new[] {-57,-67}}, 5);
            
            W(result);
            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}