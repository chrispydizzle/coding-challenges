using System;
using CodeChallenges.BinaryTrees;

public class BinaryTreeDepth
{
    int maxLength = 0;

    public int DiameterOfBinaryTree(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        // this should be nothing more than a DFS with some tricks sprinkled in.
        // we need to traverse the left and right sides individually, and their left and right sides individusally, etc...
        // perfect use case for recursion. So, how will we implement?
        // make a global pointer for maxlength
        // that guy will be responsible for storing subtree max lengths.
        // the recursive method will evaluate and return the Max path that includes the current root node.
        // I could see this maybe being done faster via BFS, since we could then terminate other paths when we have an obvious winner
        // but BFS is the intuitive method, so let's have a go.
        return Math.Max(this.BFSTree(root, 0), maxLength);
    }

    private int BFSTree(TreeNode root, int depth)
    {
        int right = 0;
        int left = 0;


        if (root.right == null && root.left == null)
        {
            // base case, we've hit the max depth of whichever branch we're in, return the depth to our caller
            return depth;
        }

        if (root.left != null)
        {
            left = this.BFSTree(root.left, depth + 1);
        }

        if (root.right != null)
        {
            right = this.BFSTree(root.right, depth + 1);
        }

        // the longest path will include at least one "root" node, even if it has no right or left branches.
        // here's where we check if a subtree lands us the largest diameter
        int withRoot = right - depth + left - depth;
        this.maxLength = Math.Max(withRoot, maxLength);
        return Math.Max(left, right);
    }
}