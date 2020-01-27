namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;
    using System.Linq;
    using Design;

    public class DepthSumIV
    {
        public int DepthSumInverse(IList<NestedInteger> nestedList)
        {
            return D(nestedList, new List<int>());
        }

        public int D(IList<NestedInteger> nestedList, List<int> leafInts)
        {
            if (nestedList == null || nestedList.Count == 0) return 0;

            int sum = leafInts.Sum();

            List<NestedInteger> lists = new List<NestedInteger>();
            foreach (NestedInteger n in nestedList)
            {
                if (n.IsInteger())
                {
                    int number = n.GetInteger();
                    sum += number;
                    leafInts.Add(number);
                }
                else
                    lists.AddRange(n.GetList());
            }

            sum += this.D(lists, leafInts);
            return sum;
        }
    }
}