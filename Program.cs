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

            W(s.MinRemoveToMakeValid("())()((("));
            W(s.MinRemoveToMakeValid("lee(t(c)o)de)"));
            
            W(s.MinRemoveToMakeValid("a)b(c)d)"));
            W(s.MinRemoveToMakeValid("))(("));
            W(s.MinRemoveToMakeValid("(a(b(c)d)"));
            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}