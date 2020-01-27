namespace CodeChallenges.Design
{
    using BinaryTrees;

    public class SymmetricTree
    {
        /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
        public class Solution
        {
            public bool IsSymmetric(TreeNode root)
            {
                if (root == null) return true;
                return Recurse(root.left, root.right);
            }

            public bool Recurse(TreeNode l, TreeNode r)
            {
                if (l == null && r == null) return true;
                if (l == null || r == null) return false;

                if (l.val != r.val) return false;

                return this.Recurse(l.left, r.right) && Recurse(r.left, l.right);
            }
        }
    }
}