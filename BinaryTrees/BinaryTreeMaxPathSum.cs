namespace CodeChallenges.BinaryTrees
{
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTreeMaxPathSum
    {
        public int MaxPathSum(TreeNode root)
        {
            int result = root.val;
            Stack<TreeNode> parentNodes = new Stack<TreeNode>();
            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();

            nodeQueue.Enqueue(root);
            while (nodeQueue.Any())
            {
                TreeNode current = nodeQueue.Dequeue();
                if (current.left != null)
                {
                    nodeQueue.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    nodeQueue.Enqueue(current.right);
                }

                if (current.right != null || current.left != null)
                {
                    parentNodes.Push(current);
                }
            }

            while (parentNodes.Any())
            {
                TreeNode parent = parentNodes.Pop();

                int bestBranch = parent.val;
                int total = parent.val;

                if (parent.left != null)
                {
                    int leftBranch = parent.val + parent.left.val;

                    if (leftBranch > bestBranch) bestBranch = leftBranch;

                    total += parent.left.val;

                    if (parent.left.val > bestBranch) bestBranch = parent.left.val;
                }

                if (parent.right != null)
                {
                    int rightBranch = parent.val + parent.right.val;
                    if (rightBranch > bestBranch) bestBranch = rightBranch;
                    total += parent.right.val;

                    if (parent.right.val > bestBranch) bestBranch = parent.right.val;

                }

                parent.val = bestBranch;

                if (bestBranch > result)
                {
                    result = bestBranch;
                }

                if (total > result)
                {
                    result = total;
                }
            }

            return result;
        }
    }
}