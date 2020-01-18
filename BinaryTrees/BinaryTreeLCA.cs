namespace CodeChallenges.BinaryTrees
{
    public class BinaryTreeLca
    {
        // TODO: Rushed through this one, need to review
        private TreeNode answer = null;

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;


            this.RecurseTree(root, p.val, q.val);
            return this.answer;
        }

        private bool RecurseTree(TreeNode currentNode, int p, int q)
        {
            // If reached the end of a branch, return false.
            if (currentNode == null)
            {
                return false;
            }

            // Left Recursion. If left recursion returns true, set left = 1 else 0
            int left = this.RecurseTree(currentNode.left, p, q) ? 1 : 0;

            // Right Recursion
            int right = this.RecurseTree(currentNode.right, p, q) ? 1 : 0;

            // If the current node is one of p or q
            int mid = (currentNode.val == p || currentNode.val == q) ? 1 : 0;

            // If any two of the flags left, right or mid become True
            if (mid + left + right >= 2)
            {
                this.answer = currentNode;
            }

            // Return true if any one of the three bool values is True.
            return (mid + left + right > 0);
        }
    }
}