using System.Collections.Generic;
using System.Linq;
using CodeChallenges.BinaryTrees;

namespace CodeChallenges.Graphs
{
    public class BTreeRightSideView
    {
        public IList<int> RightSideView(TreeNode root)
        {
            List<int> visible = new List<int>();
            var n = root;
            // queue all items at each level.
            Queue<TreeNode> levelQueue = new Queue<TreeNode>();
            levelQueue.Enqueue(n);

            while (levelQueue.Any())
            {
                var treeNode = levelQueue.Dequeue();
                if (treeNode == null) continue;

                visible.Add(treeNode.val);
                Queue<TreeNode> newQueue = new Queue<TreeNode>();

                newQueue.Enqueue(treeNode.right);
                newQueue.Enqueue(treeNode.left);

                while (levelQueue.Any())
                {
                    var dq = levelQueue.Dequeue();
                    if (dq == null) continue;
                    newQueue.Enqueue(dq.right);
                    newQueue.Enqueue(dq.left);
                }

                levelQueue = newQueue;
            }

            return visible;
        }
    }
}