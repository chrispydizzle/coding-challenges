namespace CodeChallenges.BinaryTrees
{
    using System;

    public class MaxDepthFind
    {
        public int MaxDepth(TreeNode root)
        {
            return this.MaxDepth(root, 1);
        }

        private int MaxDepth(TreeNode root, int depth)
        {
            if (root == null) return depth - 1;

            return Math.Max(this.MaxDepth(root.left, depth + 1), this.MaxDepth(root.right, depth + 1));
        }
    }
}