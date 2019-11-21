namespace CodeChallenges.BinaryTrees
{
    internal class IsSymmetricTree
    {
        public bool IsSymmetric(TreeNode root)
        {
            return this.IsSymmetric(root.left, root.right);
        }

        private bool IsSymmetric(TreeNode rootLeft, TreeNode rootRight)
        {
            if (rootLeft == null && rootRight == null) return true;

            if (rootLeft == null || rootRight == null) return false;

            return rootLeft.val == rootRight.val && this.IsSymmetric(rootLeft.left, rootRight.right) && this.IsSymmetric(rootLeft.right, rootRight.left);
        }
    }
}