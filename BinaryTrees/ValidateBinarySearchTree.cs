namespace CodeChallenges.BinaryTrees
{
    public class ValidateBinarySearchTree
    {
        public bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, null, null);
        }

        public bool IsValidBST(TreeNode root, int? lowerLimit, int? upperLimit)
        {
            if (root == null) return true;

            if (lowerLimit.HasValue && root.val <= lowerLimit) return false;
            if (upperLimit.HasValue && root.val >= upperLimit) return false;

            if (!IsValidBST(root.right, root.val, upperLimit)) return false;
            if (!IsValidBST(root.left, lowerLimit, root.val)) return false;

            return true;
        }
    }
}