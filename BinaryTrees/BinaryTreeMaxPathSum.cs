using System;

namespace CodeChallenges.BinaryTrees
{
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTreeMaxPathSum
    {
        private int maxValue = int.MinValue;

        public int MaxPathSum(TreeNode root)
        {
            this.maxValue = root.val;
            int finalTest = GetBestSum(root);

            return Math.Max(maxValue, finalTest);
        }

        private int GetBestSum(TreeNode node)
        {
            if (node == null) return int.MinValue;

            int currentValue = node.val;
            int leftValue = GetBestSum(node.left);
            int rightValue = GetBestSum(node.right);

            // check to see if an individual node can trump max value.
            maxValue = Math.Max(leftValue, maxValue);
            maxValue = Math.Max(rightValue, maxValue);

            if (rightValue == int.MinValue)
            {
                rightValue = 0;
            }
            
            if (leftValue == int.MinValue)
            {
                leftValue = 0;
            }

            int lToR = leftValue + rightValue + currentValue;

            maxValue = Math.Max(lToR, maxValue);

            if (Math.Max(leftValue, rightValue) == int.MinValue) return node.val;


            return Math.Max(node.val + Math.Max(leftValue, rightValue), node.val);
        }
    }
}