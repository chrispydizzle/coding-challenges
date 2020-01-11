namespace CodeChallenges.BinaryTrees
{
    using System.Collections.Generic;
    using Enumerable = System.Linq.Enumerable;

    public class LowestCommonAncestorBST
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            // we should bfs this, so we need a queue;
            if (root == null) return null;
            Queue<TreeNode> que = new Queue<TreeNode>();

            // stack to walk back once we hit the nodes we were looking for.
            HashSet<int> seekNodes = new HashSet<int>();
            seekNodes.Add(p.val);
            seekNodes.Add(q.val);

            que.Enqueue(root);

            Stack<TreeNode> pStack = new Stack<TreeNode>();
            Stack<TreeNode> qStack = new Stack<TreeNode>();

            while (Enumerable.Any(que) || Enumerable.Any(seekNodes))
            {
                TreeNode tn = que.Dequeue();
                if (seekNodes.Contains(tn.val))
                {
                }

                if (tn.left != null)
                {
                    if (seekNodes.Contains()
                    {
                        seekNodes.Remove(p);
                    }

                    if (tn.left.val == p.val) fp = true;
                }
            }
        }
    }
}