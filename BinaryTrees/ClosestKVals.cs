namespace CodeChallenges.BinaryTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ClosestKVals
    {
        public IList<int> ClosestKValues(TreeNode root, double target, int k)
        {
            List<double> li = new List<double>();
            Helper(root, li);
            double[] nli = li.OrderBy(x => (Math.Abs(x - target))).ToArray();
            IList<int> ret = new List<int>();
            int i = 0;
            while (k-- > 0)
            {
                ret.Add((int) nli[i++]);
            }

            return ret;
        }

        private void Helper(TreeNode root, List<double> li)
        {
            if (root == null) return;

            this.Helper(root.left, li);
            li.Add(root.val);
            this.Helper(root.right, li);
        }
    }
}