namespace CodeChallenges.Recursion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CombinationSumCheck
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            if (candidates == null || candidates.Length == 0) return null;

            List<IList<int>> result = new List<IList<int>>();

            Array.Sort(candidates);

            result = GetCombinations(candidates, target);

            return result;
        }

        private List<IList<int>> GetCombinations(int[] c, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            Queue<int> q = new Queue<int>(c);
            for (int i = 0; i < c.Length; i++)
            {
                IEnumerable<IList<int>> combinations = GetCombinations(q, 0, target);
                if (combinations != null) result.AddRange(combinations);
            }

            return result;
        }

        private IEnumerable<IList<int>> GetCombinations(Queue<int> ints, int current, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            while (ints.Any())
            {
                int dequeue = ints.Dequeue();

                result.AddRange(TryCombos(ints, current, dequeue, target));

                if (dequeue == target)
                {
                    result.Add(new List<int> {dequeue});
                    continue;
                }

                if (dequeue > target) continue;
            }

            return result;
        }

        private IEnumerable<IList<int>> TryCombos(Queue<int> ints, int current, int dequeue, int target)
        {
            List<IList<int>> result = new List<IList<int>>();

            List<int> potential = new List<int>();
            while (current + dequeue <= target)
            {
                current += dequeue;
                potential.Add(dequeue);
            }

            //if (current == target) return result;
            return result;
        }

        private List<int> GetCombosForDigit(Queue<int> q, List<int> components, int target)
        {
            List<int> result = new List<int>(components);
            Queue<int> tempQ = new Queue<int>();
            if (q.Any())
            {
                int dequeue = q.Dequeue();

                int newSum = components.Sum() + dequeue;

                if (newSum > target) tempQ.Enqueue(dequeue);
                if (newSum == target)
                {
                    result.Add(dequeue);
                    tempQ.Enqueue(dequeue);
                }

                if (newSum < target)
                {
                    result.Add(dequeue);
                    result = GetCombosForDigit(q, result, target);
                }
            }

            while (tempQ.Any()) q.Enqueue(tempQ.Dequeue());

            return result;
        }
    }
}