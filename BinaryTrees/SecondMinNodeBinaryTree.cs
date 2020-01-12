namespace CodeChallenges.BinaryTrees
{
    using System.Collections.Generic;
    using System.Linq;

    public class SecondMinNodeBinaryTree
    {
        public int FindSecondMinimumValue(TreeNode root)
        {
            // Start with just going right until we hit the end, then walk it back to the previous node and we're good?
            if (root == null || root.right == null && root.left == null) return -1;

            // as of right now, the smallest value we know is the root, and we know no second smallest.
            int smallest = root.val;
            int secondSmallest = int.MaxValue;

            Queue<TreeNode> q = new Queue<TreeNode>();
            Queue<TreeNode> tempQ = new Queue<TreeNode>();
            q.Enqueue(root);
            bool disableFalseFlag = false;
            // as long as we have nodes
            while (q.Any())
            {
                TreeNode tn = q.Dequeue();

                // check if the current value is our new second smallest
                int cVal = tn.val;
                if (cVal == int.MaxValue) disableFalseFlag = true;

                if (cVal > smallest && cVal < secondSmallest) secondSmallest = cVal;

                if (secondSmallest == smallest + 1) return secondSmallest;

                if (cVal < smallest)
                {
                    smallest = secondSmallest;
                    secondSmallest = cVal;
                }

                // if there's a right node, then there's also a left node.
                if (tn.right != null)
                {
                    if (tn.right.val < secondSmallest || tn.right.val >= smallest) tempQ.Enqueue(tn.right);

                    if (tn.left.val < secondSmallest || tn.left.val >= smallest) tempQ.Enqueue(tn.left);
                }

                if (!q.Any())
                {
                    q = new Queue<TreeNode>(tempQ);
                    tempQ.Clear();
                }
            }

            // if we've never reset the second smallest value then return a fail status.
            return secondSmallest == int.MaxValue && !disableFalseFlag ? -1 : secondSmallest;
        }
    }
}