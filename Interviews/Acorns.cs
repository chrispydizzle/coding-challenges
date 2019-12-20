using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeChallenges.BinaryTrees;

namespace CodeChallenges.Interviews
{
    public class Acorns
    {
/*
Create a function(s) that prints a binary tree in *preorder*.
An example constructed binary tree is 
            12 
          /   \ 
        9      1 
      /  \    / 
    7     5  2
    
    12, 9, 7, 5, 1, 2
*/


        public string GetPreorderByRecursion(TreeNode node)
        {
            StringBuilder b = new StringBuilder();
            this.GetPreorderByRecursion(node, b);
            return b.ToString();
        }

        private void GetPreorderByRecursion(TreeNode node, StringBuilder builder)
        {
            if (node == null) return;

            builder.Append($"{node.val}, ");

            this.GetPreorderByRecursion(node.left, builder);

            this.GetPreorderByRecursion(node.right, builder);
        }

        public string GetPreorder(TreeNode node)
        {
            var b = new StringBuilder();
            var stack = new Stack<TreeNode>();
            stack.Push(node);

            while (stack.Any())
            {
                // traverse node left
                var n = stack.Pop();

                b.Append($"{n.val}, ");

                if (n.right != null) stack.Push(n.right);

                if (n.left != null) stack.Push(n.left);
            }

            return b.ToString();
        }
    }
}