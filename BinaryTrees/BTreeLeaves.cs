namespace CodeChallenges.BinaryTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BTreeLeaves
    {
        public IList<IList<int>> FindLeaves(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            // basically, we want to find each node in the tree that has no children, and lop it off during each iteration.

            if (root == null) return result;

            // is BFS or DFS more efficient? I think DFS.

            Queue<TreeNode> q = new Queue<TreeNode>();
            Stack<TreeNode> s = new Stack<TreeNode>();
            HashSet<TreeNode> v = new HashSet<TreeNode>();

            List<int> leaves = new List<int>();
            q.Enqueue(root);
            bool left = false;
            bool right = false;
            while (q.Any())
            {
                TreeNode currentNode = q.Dequeue();

                if (v.Contains(currentNode.left)) currentNode.left = null;
                if (v.Contains(currentNode.right)) currentNode.right = null;

                if (currentNode.right != null)
                {
                    right = true;
                    q.Enqueue(currentNode.right);
                }

                if (currentNode.left != null)
                {
                    left = true;
                    q.Enqueue(currentNode.left);
                }

                if (currentNode.left != null || currentNode.right != null)
                {
                    // if he has a left or a right, they've now been queued. He gets pushed on the stack.
                    // To revisit later
                    s.Push(currentNode);
                }
                else
                {
                    // otherwise he belongs in this collection!
                    leaves.Add(currentNode.val);
                    // we store him in a hashset so we can remove him later
                    v.Add(currentNode);
                }

                // once the queue is empty, we've reached all of our end nodes, so we can send our list to the master list
                // and reset it 

                if (!q.Any())
                {
                    result.Add(leaves);
                    leaves = new List<int>();
                    // now, we should start popping items off the stack to find the parents of our orphans. we need to trim 
                    // them
                    HashSet<TreeNode> tempSet = new HashSet<TreeNode>();
                    while (s.Any())
                    {
                        TreeNode tn = s.Pop();
                        if (v.Contains(tn.left))
                        {
                            left = true;
                            tn.left = null;
                        }

                        if (v.Contains(tn.right))
                        {
                            right = true;
                            tn.right = null;
                        }
                        // if after pruning, this node has no children, he's going to wind up in the next list.

                        if (tn.left == null && tn.right == null)
                        {
                            leaves.Add(tn.val);
                            tempSet.Add(tn);
                        }
                        else
                        {
                            // otherwise, he gets queue'd up.
                            q.Enqueue(tn);
                        }
                    }

                    v.UnionWith(tempSet);


                    // at the end of this loop we should have another set ready to go.
                    if (leaves != null && leaves.Count > 0)
                    {
                        if (q.Count == 1 && !(left && right)) leaves.Add(q.Dequeue().val);

                        result.Add(leaves);
                    }

                    leaves = new List<int>();
                }
            }

            return result;
        }

        public IList<IList<int>> FindLeavesBetter(TreeNode root)
        {
            IList<IList<int>> levels = new List<IList<int>>();
            Add(root, levels);
            return levels;
        }

        public int Add(TreeNode node, IList<IList<int>> levels)
        {
            if (node == null) return 0;
            int level = 1 + Math.Max(Add(node.left, levels), Add(node.right, levels));
            if (levels.Count < level) levels.Add(new List<int>());
            levels[level - 1].Add(node.val);
            return level;
        }
    }
}