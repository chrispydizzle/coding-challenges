namespace CodeChallenges
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Arrays;
    using BinaryTrees;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            SubTree st = new SubTree();
            W(st.IsSubtree(TreeNode.BuildTree(1), TreeNode.BuildTree(1)));
            W(st.IsSubtree(TreeNode.BuildTree(3, 4, 5, 1, 2, null, null, null, null, 0), TreeNode.BuildTree(4, 1, 2)));
            W(st.IsSubtree(TreeNode.BuildTree(3, 4, 5, 1, 2), TreeNode.BuildTree(4, 1, 2)));
        }

        public static void SecondOldMain(string[] args)
        {
            TwoSumLTK p = new TwoSumLTK();
            var res1 = p.TwoSumLessThanK(new[] {358, 898, 450, 732, 672, 672, 256, 542, 320, 573, 423, 543, 591, 280, 399, 923, 920, 254, 135, 952, 115, 536, 143, 896, 411, 722, 815, 635, 353, 486, 127, 146, 974, 495, 229, 21, 733, 918, 314, 670, 671, 537, 533, 716, 140, 599, 758, 777, 185, 549},
                1800);
            var res = p.TwoSumLessThanK(new[] {34, 23, 1, 24, 75, 33, 54, 8}, 60);
            Console.Read();
        }

/*
 *
 *     public bool Find132pattern(int[] nums) {
return true;
}

Given a sequence of n integers a1, a2, ..., an, a 132 pattern is a subsequence ai, aj, ak such that i < j < k and ai < ak < aj. Design an algorithm that takes a list of n numbers as input and checks whether there is a 132 pattern in the list.

   Note: n will be less than 15,000.

   Example 1:
   Input: [1, 2, 3, 4]

   Output: False

   Explanation: There is no 132 pattern in the sequence.
   Example 2:
   Input: [3, 1, 4, 2]

   Output: True

   Explanation: There is a 132 pattern in the sequence: [1, 4, 2].
   Example 3:
   Input: [-1, 3, 2, 0]

   Output: True

   Explanation: There are three 132 patterns in the sequence: [-1, 3, 2], [-1, 3, 0] and [-1, 2, 0].
 */
        public static void OldMain(string[] args)
        {
            /*
             *     UseCase1,UseCase4

                    UseCase2,UseCase3
             */


            //var s = new BridgeWaterPractice.DeadlockDetector();

            // case eight
            /*
             * UseCase1,UseCase2
               UseCase1,UseCase6
             */
            /*
            s.Consume(new List<string>(new[]
            {
                "UseCase1 Lock1,Lock2,Lock3,Lock4",
                "UseCase2 Lock2,Lock1",
                "UseCase3 Lock4,Lock5",
                "UseCase5, Lock6,Lock7",
                "UseCase6 Lock2,Lock4,Lock3,Lock8",
                "UseCase7 Lock4",
                "UseCase8 Lock8",
                "UseCase9 Lock0, Lock8, Lock2, Lock12"
            }));
            Console.WriteLine(s.FindLocks());
            s.Clear();

            // case 10
            // empty
            s.Consume(new List<string>(new[]
            {
                "UseCase1 Lock7,Lock8,Lock6,Lock1",
                "UseCase2 Lock4,Lock6,Lock5,Lock2",
                "UseCase3 Lock3,Lock5,Lock8,Lock9",
                "UseCase4 Lock7,Lock9,Lock4,Lock1"
            }));
            Console.WriteLine(s.FindLocks());
            s.Clear();

            s.Consume(new List<string>(new[]
            {
                "UseCase3 Lock1,Lock2",
                "UseCase4 Lock2,Lock1"
            }));
            Console.WriteLine(s.FindLocks());
            s.Clear();

            s.Consume(new List<string>(new[]
            {
                "UseCase1 Lock0,Lock1,Lock2",
                "UseCase2 Lock4,Lock2,Lock1",
                "UseCase3 Lock1,Lock2",
                "UseCase4 Lock2,Lock1"
            }));
            Console.WriteLine(s.FindLocks());
            s.Clear();

            Console.ReadLine();*/
        }

        private static void W(object o)
        {
            if (o is IEnumerable enumerable && !(o is string s))
            {
                if (o is IList)
                {
                    Console.WriteLine($" IList count: {(o as IList).Count}");
                }

                foreach (object v in enumerable)
                {
                    W(v);
                }
            }

            Console.WriteLine($" Raw object: {o}");
        }
    }

    public static class Extensions
    {
        public static List<IList<int>> MakeIList(this int[][] array)
        {
            List<IList<int>> result = new List<IList<int>>();
            foreach (int[] ints in array)
            {
                List<int> newL = new List<int>(ints);
                result.Add(newL);
            }

            return result;
        }
    }
}