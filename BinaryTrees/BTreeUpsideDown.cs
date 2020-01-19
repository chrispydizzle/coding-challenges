namespace CodeChallenges.BinaryTrees
{
    using System.Collections.Generic;
    using System.Linq;

    public class BTreeUpsideDown
    {
        // TODO: This simple solution, and I was just waaaaay overcomplicating it. Need. To. Re. Visit.
        public TreeNode UpsideDownBinaryTree(TreeNode root)
        {
            // null or single item check
            if (root == null || (root.left == null && root.right == null)) return root;

            TreeNode currentNode = root;
            TreeNode temp = null;
            TreeNode prev = null;

            while (currentNode.left != null)
            {
                temp = new TreeNode(currentNode.left.val);
                temp.left = currentNode.right != null ? new TreeNode(currentNode.right.val) : null;
                temp.right = prev == null ? new TreeNode(currentNode.val) : prev;
                prev = temp;

                currentNode = currentNode.left;
            }

            return temp;
        }

        public TreeNode UpsideDownBinaryTreeNo(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null)) return root;
            // all right nodes are empty or have a sibling. ??
            // going to solve for the example first and then see what's what.
            var tn = root;
            var s = new Stack<TreeNode>();

            return this.DoIot(root, s);
        }

        private TreeNode DoIot(TreeNode tn, Stack<TreeNode> s)
        {
            // root becomes right sibling, right sibling becomes left sibling
            // left sibling becomes root. Then pass it up

            if (tn.right == null && tn.left == null)
            {
                TreeNode newRoot = null;
                TreeNode newNode = null;
                TreeNode t = s.Pop();

                if (t.right?.val == tn.val || t.left?.val == tn.val)
                {
                    if (newNode == null)
                    {
                        newRoot = newNode = new TreeNode(t.left.val);
                    }

                    newNode.left = t.right != null ? new TreeNode(t.right.val) : null;
                    newNode.right = new TreeNode(t.val);
                }

                while (s.Any())
                {
                    t = s.Pop();

                    if (t.left?.val == newNode?.right?.val)
                    {
                        TreeNode nextNode = newNode.right;
                        nextNode.left = t.right != null ? new TreeNode(t.right.val) : null;
                        nextNode.right = new TreeNode(t.val);
                        newNode.right = nextNode;
                        newNode = nextNode;
                    }
                    else if (t.right?.val == newNode?.left?.val)
                    {
                        TreeNode nextNode = new TreeNode(newNode.left.val);
                        nextNode.left = t.right != null ? new TreeNode(t.right.val) : null;
                        nextNode.right = new TreeNode(newNode.val);
                        newNode.left = nextNode;
                        newNode = nextNode;
                    }
                }

                return newRoot;

                // hit a leaf node, unroll the stack appropriately and return
            }

            TreeNode rightResult = null;
            if (tn.right != null)
            {
                s.Push(tn);
                rightResult = this.DoIot(tn.right, s);
            }

            TreeNode leftResult = null;
            if (tn.left != null)
            {
                s.Push(tn);
                leftResult = this.DoIot(tn.left, s);
                leftResult.right = rightResult;
            }

            return leftResult ?? tn;
        }

        private TreeNode DoIotOld(TreeNode tn, Stack<TreeNode> s)
        {
            // root becomes right sibling, right sibling becomes left sibling
            // left sibling becomes root. Then pass it up
            if (tn.right == null && tn.left == null)
            {
                // we are at a leaf.
                return null;
            }

            TreeNode n = new TreeNode(tn.left.val);

            TreeNode right = null;
            if (tn.right != null)
            {
                right = this.DoIot(tn.right, s);

                if (right != null)
                {
                    right = this.DoIot(tn.right?.right, s);
                }
            }

            n.left = tn.right;

            TreeNode left = this.DoIot(tn.left, s);
            if (left != null)
            {
                s.Push(left);
                left = this.DoIot(tn.left?.left, s);
            }

            n.right = new TreeNode(tn.val);
            if (s.Any())
            {
                TreeNode parent = s.Pop();
                TreeNode rightSeek = parent;
                while (rightSeek.right != null)
                {
                    if (rightSeek.right.val == n.val)
                    {
                        rightSeek.right = n;
                        break;
                    }

                    rightSeek = rightSeek.right;
                }

                return parent;
            }

            if (left != null)
            {
                TreeNode rightSeek = left;
                while (rightSeek.right != null)
                {
                    if (rightSeek.right.val == n.val)
                    {
                        rightSeek.right = n;
                        break;
                    }

                    rightSeek = rightSeek.right;
                }

                return left;
            }

            return n;
        }
    }
}