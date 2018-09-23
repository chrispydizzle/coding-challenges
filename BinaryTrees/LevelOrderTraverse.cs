namespace Pdrome2
{
    using System.Collections.Generic;
    using System.Linq;

    internal class LevelOrderTraverse
    {
        public IList<IList<int>> LevelOrder(TreeNode root) {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            
            while (q.Any())
            {
                // eval
                List<int> l = new List<int>();
                
                List<TreeNode> tempSet = new List<TreeNode>();

                while (q.Any())
                {
                    TreeNode t = q.Dequeue();
                    l.Add(t.val);
                    
                    // q left
                    if (t.left != null)
                    {
                        tempSet.Add(t.left);
                    }

                    // q right
                    if (t.right != null)
                    {
                        tempSet.Add(t.right);
                    }
                }
                
                result.Add(l);
                q = new Queue<TreeNode>(tempSet);
            }
            
            return result;
        }
    }
}