namespace CodeChallenges.BinaryTrees
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SerializeAndDeserializeBtree
    {
        public string serialize(TreeNode root)
        {
            TreeNode current = root;
            // we will do a bfs-type relay down the tree, starting with the root and going left, then right,
            // recording a null value or the value of the next item. if there is a next item it goes in a temp queue, to be
            // evaluated  during the next loop, and so on, until there are no nodes left. We can easily deserialize this by
            // reversing the process. I think.
            StringBuilder b = new StringBuilder();
            Queue<TreeNode> q = new Queue<TreeNode>();
            Queue<TreeNode> tq = new Queue<TreeNode>();
            q.Enqueue(current);
            b.Append("[");

            while (q.Any())
            {
                TreeNode tn = q.Dequeue();
                if (tn == null)
                {
                    // need to account for null nodes
                    b.Append("null");
                }
                else
                {
                    // drop the node value into the string and queue his left & rights in the temp q;
                    b.Append($"{tn.val}");
                    tq.Enqueue(tn.left);
                    tq.Enqueue(tn.right);
                }

                if (!q.Any())
                {
                    if (tq.All(c => c == null)) continue;

                    q = new Queue<TreeNode>(tq);
                    tq.Clear();
                }

                if (q.Any() || tq.Any())
                    // only append a comma if we have more values
                    b.Append(",");
            }


            b.Append("]");
            return b.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            // do the reverse of what we've done above- split the string by commas and layout the tree from top to bottom
            if (data[0] != '[' || data[data.Length - 1] != ']') return null;

            string trim = data.Trim('[').Trim(']');
            string[] tList = trim.Split(',');
            return null;
        }
    }
}