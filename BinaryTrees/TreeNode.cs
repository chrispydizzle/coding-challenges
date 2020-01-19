namespace CodeChallenges.BinaryTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    // [DebuggerDisplay("val: {val} left: {left} right: {right}")]
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int val;

        public TreeNode(int x)
        {
            val = x;
        }

        public string DrawTree()
        {
            StringBuilder builder = new StringBuilder();

            DrawNextNode(this, builder);

            return builder.ToString();
        }

        private void DrawNextNode(TreeNode root, StringBuilder builder)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            builder.AppendLine(root.val.ToString());

            q.Enqueue(root.left);
            q.Enqueue(root.right);

            Queue<TreeNode> tempQ = new Queue<TreeNode>();
            while (q.Any())
            {
                TreeNode nextItem = q.Dequeue();
                builder.Append(nextItem == null ? "[X]  " : $"{nextItem}   ");

                if (nextItem != null)
                {
                    tempQ.Enqueue(nextItem.left);
                    tempQ.Enqueue(nextItem.right);
                }

                if (!q.Any() && tempQ.Any()) Console.WriteLine();
            }
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

        public string ToStringFancy()
        {
            Queue<TreeNode> q = new Queue<TreeNode>(new[] {this});
            List<string> ss = new List<string>();
            Queue<TreeNode> tempQ = new Queue<TreeNode>();
            StringBuilder b = new StringBuilder();
            int indent = 0;
            while (q.Any())
            {
                TreeNode tn = q.Dequeue();
                if (tn == null)
                {
                    b.Append("    ");
                }
                else
                {
                    if (tn.left != null)
                    {
                        tempQ.Enqueue(tn.left);
                    }
                    else
                    {
                        tempQ.Enqueue(null);
                    }

                    b.Append($"val: {tn.val} ");

                    if (tn.right != null)
                    {
                        b.Append("    ");
                        tempQ.Enqueue(tn.right);
                    }
                    else
                    {
                        tempQ.Enqueue(null);
                    }
                }

                if (!q.Any())
                {
                    ss.Add(b.ToString());
                    if (tempQ.All(c => c == null)) break;
                    q = new Queue<TreeNode>(tempQ);
                    tempQ.Clear();
                    b.Clear();
                }

                indent++;
            }

            int max = ss.Max(s => s.Length);
            StringBuilder sb = new StringBuilder("--Tree--\n");
            foreach (string s in ss)
            {
                int diff = max - s.Length;
                string fString = s.PadLeft(diff / 2);
                string aString = fString.PadRight(diff / 2);
                sb.AppendLine(aString);
            }

            sb.AppendLine("--End Tree--");
            return sb.ToString();
        }
    }
}