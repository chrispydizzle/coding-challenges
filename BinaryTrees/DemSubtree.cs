namespace CodeChallenges.BinaryTrees
{
    using System.Collections.Generic;
    using System.Linq;

    public class DemSubtree
    {
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            // nonempty
            // traverse s BF, seek t.val
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(s);
            while (q.Any())
            {
                TreeNode n = q.Dequeue();
                if (n.val == t.val)
                {
                    if (this.Validate(n.left, t.left) && this.Validate(n.right, t.right))
                    {
                        return true;
                    }
                }

                if (n.left != null) q.Enqueue(n.left);
                if (n.right != null) q.Enqueue(n.right);
            }

            return false;
        }

        private bool Validate(TreeNode n, TreeNode n2)
        {
            if (n == null && n2 == null) return true;
            if (n == null || n2 == null) return false;

            if (n.val == n2.val)
            {
                return this.Validate(n.left, n2.left) && this.Validate(n.right, n2.right);
            }

            return false;
        }
    }
}