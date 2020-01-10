namespace CodeChallenges.Design
{
    using System;
    using System.Collections.Generic;

    public class NestedListWeightSum2
    {
        private readonly Dictionary<int, List<int>> d = new Dictionary<int, List<int>>();

        public int DepthSumInverse(IList<NestedInteger> nestedList)
        {
            d.Clear();
            GetSum(nestedList, 0);

            int depth = d.Keys.Count;

            int sum = 0;
            foreach (KeyValuePair<int, List<int>> keyValuePair in d)
            foreach (int i in keyValuePair.Value)
                sum += (depth - keyValuePair.Key) * i;

            // post process
            return sum;
        }

        private void GetSum(IList<NestedInteger> getList, int depth)
        {
            // okay it's slightly more complicated than I thought.
            // we need to dig as deep as we can in any Nestedset. It can be done in one pass though, with a stack.  I think.

            Queue<IList<NestedInteger>> s = new Queue<IList<NestedInteger>>();

            s.Enqueue(getList);
            HashSet<Tuple<int, int>> set = new HashSet<Tuple<int, int>>();

            // each pass we go through is a level deeper. This is essentially a BFS for the deepest level, and as we dequeue each
            // level we will increment a counter

            Console.WriteLine($"Entered GetSum - List is {getList.Count}, depth will be {depth + 1}  ");
            int sum = 0;

            foreach (NestedInteger nestedInteger in getList)
            {
                if (!d.ContainsKey(depth)) d.Add(depth, new List<int>());


                Console.WriteLine($"Looping, {getList.Count}, current sum is {sum}");
                if (nestedInteger.IsInteger())
                    d[depth].Add(nestedInteger.GetInteger());
                else
                    GetSum(nestedInteger.GetList(), depth + 1);
            }
        }
    }
}