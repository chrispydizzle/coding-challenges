namespace CodeChallenges.DFS
{
    using System.Collections.Generic;
    using BFS;

    public class Template
    {
        private bool DFS(Node cur, Node target, HashSet<Node> visited)
        {
            if (cur == target) return true;

            for (int i = 0; i < cur.Neighbors.Count; i++)
            {
                Node next = cur.Neighbors[i];
                if (!visited.Contains(next))
                {
                    visited.Add(next);
                    return this.DFS(next, target, visited);
                }
            }

            return false;
        }
    }
}