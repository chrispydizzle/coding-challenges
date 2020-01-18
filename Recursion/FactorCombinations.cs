namespace CodeChallenges.Recursion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FactorCombinations
    {
        /// <summary>
        /// So, rather simplistically, this algo just goes from i to target finding every possible divisor,vs my min factors attempt.
        /// Bette remember this.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<IList<int>> GetFactors(int n)
        {
            var result = new List<IList<int>>();
            this.DoDfs(n, 2, new List<int>(), result);
            return result;
        }

        private void DoDfs(int target, int pre, IList<int> oneResult, IList<IList<int>> result)
        {
            if (oneResult.Count > 0 && pre <= target)
            {
                var tempResult = new List<int>(oneResult) {target};
                result.Add(tempResult);
            }

            for (int i = pre; i < target; i++)
            {
                if (target % i == 0)
                {
                    oneResult.Add(i);
                    this.DoDfs(target / i, i, oneResult, result);
                    oneResult.RemoveAt(oneResult.Count - 1);
                }
            }
        }
    }

    public class FactorCombinationsWrong
    {
        public IList<IList<int>> GetFactors(int n)
        {
            // first some validation, make sure we haven't been passed 1-3 to factor, those are all primes.
            if (n < 4)
            {
                var a = new List<IList<int>>();
                var b = new List<int>(new[] {n});
                a.Add(b);
                return a;
            }

            return this.ReduceToFactors(n);
        }

        private IList<IList<int>> ReduceToFactors(int target)
        {
            var result = new List<IList<int>>();

            Tuple<int, int> set = this.ReduceByOne(target);

            List<int> minFactors = new List<int>();
            while (set != null)
            {
                minFactors.Add(set.Item1);
                List<int> currentResult = new List<int>(minFactors);
                currentResult.Add(set.Item2);
                result.Add(currentResult);
                set = this.ReduceByOne(set.Item2);
            }

            // congrats, we have reduced the target to minimum factors now
            // if there is only one result, we have no more work to do.
            if (result.Count == 1) return result;

            // more likely, however, we have to walk this list and create new combinatons

            List<int> minfactors = result.Last().ToList();

            // should be similar to permutations, I think.
            List<List<int>> defactored = this.Defactor(minfactors);

            result.AddRange(defactored);

            return result;
        }

        private List<List<int>> Defactor(List<int> minfactors)
        {
            var result = new List<List<int>>();

            return result;
        }

        // takes in a target and reduces to a pair of factors
        private Tuple<int, int> ReduceByOne(int target)
        {
            if (target % 2 == 0)
            {
                target >>= 1; //div by
                return target == 1 ? null : new Tuple<int, int>(2, target);
            }


            // target is odd, so we can check for odd factors now-
            // the best path forward is now checking for odd factors
            int limit = (int) Math.Ceiling(Math.Sqrt(target));
            for (int i = 3; i < limit; i += 2)
            {
                if (target % i == 0)
                {
                    target = target / i;
                    return target == 1 ? null : new Tuple<int, int>(i, target);
                }
            }


            // target has no odd or even factors, it must be a prime. We'll return null to signal it cannot be factored further
            return null;
        }
    }
}