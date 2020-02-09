namespace CodeChallenges.BinaryTrees
{
    using System.Collections.Generic;
    using System.Linq;

    public class SubTree
    {
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null || t == null) return false;

            // bfs to matching root node
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(s);

            while (q.Any())
            {
                TreeNode n = q.Dequeue();
                if (n == null) continue;

                if (n.val == t.val)
                {
                    bool complete = true;
                    //evaluate
                    Stack<TreeNode> rQ = new Stack<TreeNode>();
                    Stack<TreeNode> sQ = new Stack<TreeNode>();
                    sQ.Push(t.left);
                    sQ.Push(t.right);

                    rQ.Push(n.left);
                    rQ.Push(n.right);


                    while (sQ.Any() || rQ.Any())
                    {
                        var tS = sQ.Pop();
                        var tR = rQ.Pop();

                        if (tS == null && tR == null) continue;
                        complete = false;
                        if (tS.left?.val != tR.left?.val)
                        {
                            break;
                        }

                        sQ.Push(tS.left);
                        rQ.Push(tR.left);


                        if (tS.right?.val != tR.right?.val)
                        {
                            break;
                        }

                        sQ.Push(tS.right);
                        rQ.Push(tR.right);
                        complete = true;
                    }

                    // if we've exhausted both queue+s we've got a match.
                    if (complete) return true;
                }

                q.Enqueue(n.left);
                q.Enqueue(n.right);
            }

            return false;
        }
    }
}