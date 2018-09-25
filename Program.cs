namespace Pdrome2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Timers;
    using System.Xml.Schema;
    using LinkedList;
    using Stack;

    internal class Program
    {
        public static void Main(string[] args)
        {
            // TreeNode root = TreeNode.BuildSimpleTree();

            int[,] thisone =
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16}
            };
            // new RotateMatrix().Rotate(thisone);
            // IList<int> inorderTraversal = new InorderTraverser().InorderTraversal(one);

            // 15,13,2,5
            // [14,8,6,1],
            // [12,4,3,9],
            // [16,7,10,11]]

            string text = "bloop";
            // Dictionary<char, char> groupBy = text.ToDictionary(c => c, text.Remove());
            // groupBy.Contains(c)

            foreach (IGrouping<char, char> group in text.GroupBy(c => c))
            {
                Console.WriteLine("{0} = {1}", group.Key, group.Count());
            }

            int.MinValue.ToString().Substring(1);
            // string bop = new DoReverseString().ReverseString("blep");

            // W(new SingleNumberFinder().ContainsDuplicate(ints));
            // IList<IList<int>> preorderTraversal = new LevelOrderTraverse().LevelOrder(one);
            //TreeNode newTree = new BuildTreeFrom().BuildTree(new[] {9, 3, 15, 20, 7}, new[] {9, 15, 7, 20, 3});
            // char.IsNumber()
            Console.ReadLine();
        }

        private static void W(object o)
        {
            
            Console.WriteLine(o);
        }
    }
    
    public class DeleteLinkedListNode{
        public void DeleteNode(ListNode node)
        {
            this.ReplaceNode(node, node.next);
        }

        private void ReplaceNode(ListNode node, ListNode nodeNext)
        {
            node.val = nodeNext.val;

            if (nodeNext.next == null)
            {
                node.next = null;
                return;
            }
            
            this.ReplaceNode(nodeNext, nodeNext.next);
        }
    }
}