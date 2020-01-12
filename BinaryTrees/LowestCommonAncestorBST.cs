namespace CodeChallenges.BinaryTrees
{
    public class LowestCommonAncestorBST
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            // tried to solve this sort of like this but it was a mess. Below is optimal space and time for this algo.
            if (root == null) return null;

            int pN = p.val;
            int qN = q.val;

            TreeNode lca = root;

            // why does it work?
            while (lca != null)
            {
                int cN = lca.val;
                if (pN > cN && qN > pN)
                    lca = lca.right;
                else if (pN < cN && qN < cN)
                    lca = lca.left;
                else
                    return lca;
            }

            return null;
        }
    }
}