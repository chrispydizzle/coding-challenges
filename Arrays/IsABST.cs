namespace CodeChallenges.Arrays
{
    using BinaryTrees;

    public class IsABST
    {
        public bool IsValidBST(TreeNode root)
        {
            // need to check if current node meets bst standard.
            // additionally, need to make sure that no number on the left side of the tree > anything from root to right side
            // same for right side tree.
            int lMax = root.val - 1;
            int rMin = root.val + 1;
            //this.IsValidBST(n)
            return false;
        }

        /*public IsValidBST(TreeNode n, int min, int max)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            while (q.Any())
            {
                var c = q.Dequeue();

                if (c.left != null)
                {
                    if (c.left.val > lMax || c.left.val > c.val)
                    {
                        return false;
                    }

                    q.Enqueue(c.left);
                }

                if (c.right != null)
                {
                    if (c.right.val < rMin || c.right.val < c.val)
                    {
                        return false;
                    }

                    q.Enqueue(c.right);
                }
            }

            return true;
        }*/
    }
}