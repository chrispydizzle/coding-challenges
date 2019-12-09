namespace CodeChallenges.BinaryTrees
{
    using System.Collections.Generic;
    using System.Linq;

    public class FlattenBSTToLinkedList
    {
        public void Flatten(TreeNode root)
        {
            if (root == null) return;
            TreeNode currentNode = root;

            Flatten(root.right);

            while (currentNode.left != null)
            {
                TreeNode tempRight = null;
                if (currentNode.right != null)
                {
                    Flatten(currentNode.right);
                    tempRight = currentNode.right;
                }

                currentNode.right = currentNode.left;
                currentNode.left = null;
                currentNode = currentNode.right;

                TreeNode lastRight = currentNode;
                while (lastRight.right != null)
                {
                    lastRight = lastRight.right;
                    Flatten(lastRight);
                }

                if (tempRight != null)
                {
                    lastRight.right = tempRight;
                }
            }
        }
    }
}