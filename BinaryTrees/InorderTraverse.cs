namespace Pdrome2
{
    using System.Collections.Generic;

    public class InorderTraverser
    {   
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> traverser = new List<int>();
            this.InorderTraverse(root, traverser);
            return traverser;
        }

        private void InorderTraverse(TreeNode root, List<int> traverser)
        {
            if (root == null) return;
            if (root.left != null)
            {
                this.InorderTraverse(root.left, traverser);
            }
            traverser.Add(root.val);

            if (root.right != null)
            {
                this.InorderTraverse(root.right, traverser);
            }
        }
    }
}