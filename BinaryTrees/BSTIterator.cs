namespace CodeChallenges.BinaryTrees
{
    using System.Collections.Generic;
    using System.Linq;

    public class BSTIterator
    {
        TreeNode cNode;
        int index;
        TreeNode large;
        List<int> nodesSorted;

        TreeNode root;

        public BSTIterator(TreeNode root)
        {
            // Array containing all the nodes in the sorted order
            this.nodesSorted = new List<int>();

            // Pointer to the next smallest element in the BST
            this.index = -1;

            // Call to flatten the input binary search tree
            this.Inorder(root);
        }

        private void Inorder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            this.Inorder(root.left);
            this.nodesSorted.Add(root.val);
            this.Inorder(root.right);
        }

        /**
     * @return the next smallest number
     */
        public int Next()
        {
            return this.nodesSorted[++this.index];
        }

        /**
     * @return whether we have a next smallest number
     */
        public bool HasNext()
        {
            return this.index + 1 < this.nodesSorted.Count;
        }

        /** @return the next smallest number */
        /** @return whether we have a next smallest number */
        public bool HasNextNo()
        {
            if (cNode == null) return false;
            return true;
        }

        public int NextNo()
        {
            int cVal = cNode.val;
            int newVal = cVal;

            var q = new Queue<TreeNode>();
            TreeNode prevParent = cNode;
            q.Enqueue(cNode);
            int nextSmall = cNode.val;
            while (q.Any())
            {
                var c = q.Dequeue();
                if (c.left != null)
                {
                    nextSmall = c.left.val;
                    var ln = c.left;
                    if (ln.left != null || ln.right != null)
                    {
                        cNode = ln;
                    }
                    else
                    {
                        cNode.left = null;
                    }
                }
                else if (c.right != null)
                {
                    cNode = cNode.right;
                }
                else
                {
                    cNode = null;
                }
            }

            return nextSmall;
        }

        public void BSTIteratorNor(TreeNode root)
        {
            this.root = root;
            this.cNode = root;
            var c = root;
            while (c != null)
            {
                this.large = c.right;
                c = c.right;
            }
        }
    }
}