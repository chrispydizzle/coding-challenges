namespace CodeChallenges.BinaryTrees
{
    internal class RootLeafPath
    {
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;

            return this.HasPathSum(root, sum, 0);
        }

        private bool HasPathSum(TreeNode root, int sum, int running)
        {
            if (root == null) return false;

            running += root.val;
            if (root.left == null && root.right == null) return sum == running;

            return this.HasPathSum(root.left, sum, running) || this.HasPathSum(root.right, sum, running);
        }
    }
}