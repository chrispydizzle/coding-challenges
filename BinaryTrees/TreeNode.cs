namespace CodeChallenges.BinaryTrees
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;

    [DebuggerDisplay("val: {val} left: {left?.val} right: {right?.val}")]
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int val;

        public TreeNode(int x)
        {
            this.val = x;
        }

        public static TreeNode BuildSimpleTree()
        {
            TreeNode one = new TreeNode(1);
            TreeNode two = new TreeNode(2);
            one.right = two;
            TreeNode three = new TreeNode(3);
            two.left = three;
            return one;
        }

        public static TreeNode BuildTree(params int?[] args)
        {
            if (!args[0].HasValue) return null;
            TreeNode root = new TreeNode(args[0].Value);
            Queue<TreeNode> childNodes = new Queue<TreeNode>();
            childNodes.Enqueue(root);
            int pointer = 1;
            while (pointer < args.Length)
            {
                TreeNode node = childNodes.Dequeue();

                if (args[pointer].HasValue)
                {
                    node.left = new TreeNode(args[pointer].Value);
                    childNodes.Enqueue(node.left);
                }
                else
                {
                    node.left = null;
                }
                
                pointer++;

                if (pointer >= args.Length) break;

                if (args[pointer].HasValue)
                {
                    node.right = new TreeNode(args[pointer].Value);
                    childNodes.Enqueue(node.right);
                }
                else
                {
                    node.right = null;
                }

                pointer++;
            }

            return root;
        }

        public override string ToString()
        {
            return $"val: {this.val} left: {this.left?.val} right: {this.right?.val}";
        }
    }
}