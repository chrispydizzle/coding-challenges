namespace CodeChallenges.BinaryTrees
{
    using System.Collections.Generic;
    using System.Linq;

    public class PreorderTraverse
    {
        // TODO: Recursive
        public IList<int> PreorderTraversal(TreeNode root)
        {
            // N 
            // L
            // R
            List<int> traversed = new List<int>();
            if (root == null)
            {
                return traversed;
            }

            Stack<TreeNode> s = new Stack<TreeNode>();
            HashSet<TreeNode> h = new HashSet<TreeNode>();
            s.Push(root);
            while (s.Any())
            {
                TreeNode treeNode = s.Pop();
                h.Add(treeNode);
                traversed.Add(treeNode.val);

                if (treeNode.right != null)
                {
                    s.Push(treeNode.right);
                }

                if (treeNode.left != null)
                {
                    s.Push(treeNode.left);
                    treeNode = treeNode.left;
                }
            }

            return traversed;
        }
    }
}