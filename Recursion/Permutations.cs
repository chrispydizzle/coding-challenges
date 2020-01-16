namespace CodeChallenges.Recursion
{
    using System.Collections.Generic;
    using System.Linq;

    public class Permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (nums.Length == 0) return result;


            if (nums.Length == 1)
            {
                result.Add(new List<int>(new[] {nums[0]}));
                return result;
            }

            foreach (int i in nums)
            {
                int[] tempNums = nums.Where(n => n != i).ToArray();
                result.AddRange(this.Permute(new[] {i}, tempNums));
            }

            return result;
        }

        private List<IList<int>> Permute(int[] leftSide, int[] rightSide)
        {
            var result = new List<IList<int>>();

            // items on the left remain static, right side items are iterated.
            var left = new List<int>(leftSide);

            // base case
            if (rightSide.Length == 1)
            {
                left.Add(rightSide[0]);
                result.Add(left);
                return result;
            }

            // otherwise, loop through right side, taking one out and moving it to the left
            foreach (int i in rightSide)
            {
                var tempLeft = new List<int>(left);
                tempLeft.Add(i);
                int[] newLeft = tempLeft.ToArray();
                int[] newRight = rightSide.Where(n => n != i).ToArray();
                result.AddRange(this.Permute(newLeft, newRight).ToList());
            }

            return result;
        }
    }
}