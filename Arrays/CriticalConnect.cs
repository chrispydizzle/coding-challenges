namespace CodeChallenges.Arrays
{
    using System;
    using System.Collections.Generic;

    public class CriticalConnect
    {
        private int id;
        private int[] ids;
        private int[] low;
        private Dictionary<int, IList<int>> dNodes;
        private IList<IList<int>> ans;

        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            // prepare adjacency list
            this.dNodes = new Dictionary<int, IList<int>>();
            foreach (IList<int> conn in connections)
            {
                int link1 = conn[0];
                int link2 = conn[1];

                if (!dNodes.ContainsKey(link1))
                    dNodes.Add(link1, new List<int>());
                if (!dNodes.ContainsKey(link2))
                    dNodes.Add(link2, new List<int>());

                dNodes[link1].Add(link2);
                dNodes[link2].Add(link1);
            }

            this.ids = new int[n];
            this.low = new int[n];
            this.id = 0;
            this.ans = new List<IList<int>>();

            // mark nodes as unvisited
            for (int i = 0; i < n; i++)
                ids[i] = -1;

            // start with unvisited
            for (int i = 0; i < n; i++)
            {
                if (ids[i] == -1)
                    DFS(i, -1);
            }

            return ans;
        }

        private void DFS(int at, int prev)
        {
            ids[at] = id;
            low[at] = id;
            id++;

            foreach (int to in dNodes[at])
            {
                // ignore the node we came from
                if (to == prev)
                    continue;

                if (ids[to] == -1)
                {
                    // visit
                    DFS(to, at);

                    if (ids[at] < low[to])
                        ans.Add(new List<int>() {at, to});
                }

                // update low-link value
                low[at] = Math.Min(low[at], low[to]);
            }
        }
    }
}