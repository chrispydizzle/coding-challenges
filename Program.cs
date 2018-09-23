namespace Pdrome2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Timers;
    using System.Xml.Schema;
    using Stack;

    internal class Program
    {
        public static void Main(string[] args)
        {
            
            // TreeNode root = TreeNode.BuildSimpleTree();
            
            int[,] thisone = { {1,2,3,4},
                {5,6,7,8},
                {9,10,11,12},
                {13,14,15,16} };
            new RotateMatrix().Rotate(thisone);
            // IList<int> inorderTraversal = new InorderTraverser().InorderTraversal(one);
            
            // 15,13,2,5
            // [14,8,6,1],
            // [12,4,3,9],
            // [16,7,10,11]]

            // W(new SingleNumberFinder().ContainsDuplicate(ints));
            // IList<IList<int>> preorderTraversal = new LevelOrderTraverse().LevelOrder(one);
            //TreeNode newTree = new BuildTreeFrom().BuildTree(new[] {9, 3, 15, 20, 7}, new[] {9, 15, 7, 20, 3});
            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}