namespace CodeChallenges
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using Arrays;
    using BinaryTrees;
    using Design;
    using DynamicProgramming;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var s = new HouseRobber();
            W(s.Rob(new[] {1, 2}));
            W(s.Rob(new[] {2, 4, 8, 9, 9, 3}));

            //var s = new KSmallestPair();
            //var s = new ClosestKVals();
            /*var s = new PowerOf();
            s.MyPow(2, 160);
            s.AltPow(2, 160);

            s.MyPow(.99999, 948688);*/
            //var s = new SqrtOf();
            //W(s.MySqrt(1024));
            //W(s.Insert(new[] {new[]{2, 3}, new[] {5, 5}, new[] {6, 6}, new[] {7, 7}, new[] {8, 11}}, new[] {6, 13}));
            /*W(s.ClosestKValues(TreeNode.BuildTree(41,37,44,24,39,42,48,1,35,38,40,null,43,46,49,0,2,30,36,null,null,null,null,null,null,45,47,null,null,null,null,null,4,29,32,null,null,null,null,null,null,3,9,26,null,31,34,null,null,7,11,25,27,null,null,33,null,6,8,10,16,null,null,null,28,null,null,5,null,null,null,null,null,15,19,null,null,null,null,12,null,18,20,null,13,17,null,null,22,null,14,null,null,21,23), 5.14, 45));
            W(s.ClosestKValues(TreeNode.BuildTree(5,3,6,1,4,null,null,null,2), 2.57, 1));
            W(s.ClosestKValues(TreeNode.BuildTree(3, 2, 4, 1), 2.0, 3));
            W(s.ClosestKValues(TreeNode.BuildTree(3, 1, 4, null, 2), 2.0, 1));
            W(s.ClosestKValues(TreeNode.BuildTree(1500000000, 1400000000), -1500000000.0, 1));
            W(s.ClosestKValues(TreeNode.BuildTree(0), 2147483648, 1));
            W(s.ClosestKValues(TreeNode.BuildTree(4, 2, 5, 1, 3), 3.7, 2));*/
            //W(s.KSmallestPairs(new[] {1, 1, 2}, new[] {1, 2, 3}, 10));
            //W(s.CoinChange(new[] {186, 419, 83, 408}, 6249));
            Console.ReadLine();
        }

        private static void W(object o)
        {
            if (o is IEnumerable enumerable && !(o is string s))
            {
                foreach (object v in enumerable)
                {
                    W(v);
                }
            }

            List<int> a;

            Console.WriteLine($" Raw object: {o}");
        }
    }
}