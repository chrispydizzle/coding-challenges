using CodeChallenges.BinaryTrees;
using CodeChallenges.DFS;
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
            var s = new NumberOfIslands();

            W(s.NumIslands(new[]
            {
                new[] {'1', '1', '1', '1', '0'},
                new[] {'1', '1', '0', '1', '0'},
                new[] {'1', '1', '0', '0', '0'},
                new[] {'0', '0', '0', '0', '0'},
            }));

            var m = new[]
            {
                new[] {'1', '1', '0', '0', '0'},
                new[] {'1', '1', '0', '0', '0'},
                new[] {'0', '0', '1', '0', '0'},
                new[] {'0', '0', '0', '1', '1'}
            };

            int result = s.NumIslands(m);
            W(result);
            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}