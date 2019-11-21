namespace CodeChallenges.BinaryTrees
{
    using System.Collections.Generic;
    using System.Linq;

    internal class PostOrderTraverse
    {
        // Todo: Recursive
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> traversed = new List<int>();
            if (root == null) return traversed;
            Stack<TreeNode> s = new Stack<TreeNode>();
            new HashSet<TreeNode>();
            s.Push(root);
            while (s.Any())
            {
                TreeNode treeNode = s.Pop();

                if (treeNode.left == null && treeNode.right == null)
                {
                    traversed.Add(treeNode.val);
                    continue;
                }

                s.Push(treeNode);
                if (treeNode.right != null)
                {
                    s.Push(treeNode.right);
                }

                if (treeNode.left != null)
                {
                    s.Push(treeNode.left);
                }

                treeNode.left = null;
                treeNode.right = null;
            }

            return traversed;
        }
    }
}