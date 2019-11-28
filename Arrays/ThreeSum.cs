namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;

    public class ThreeSum
    {
        public IList<IList<int>> GetThreeSum(int[] nums)
        {
            IList<IList<int>> resultSet = new List<IList<int>>();

            // sort the array
            List<int> intList = new List<int>(nums);
            intList.Sort();

            for (int i = 0; i < nums.Length - 2; i++)
            {

                int target = intList[i];
                // do not try duplicate targets
                if (i > 0 && target == intList[i - 1]) continue;

                // init left and right pointers for this target
                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int leftTarget = intList[left];
                    int rightTarget = intList[right];
                    int total = target + leftTarget + rightTarget;

                    // if total is less than target, move left pointer up
                    if (total < 0)
                    {
                        left++;
                        continue;
                    }

                    // if total is more than target, move right pointer down
                    if (total > 0)
                    {
                        right--;
                        continue;
                    }

                    // total must be zero, add set to resultset
                    List<int> result = new List<int> { target, leftTarget, rightTarget };
                    resultSet.Add(result);

                    // avoid duplicate left and right pointers
                    while (left < right && leftTarget == intList[left + 1])
                        left++;

                    while (left < right && rightTarget == intList[right - 1])
                        right--;

                    left++;
                    right--;
                }
            }

            return resultSet;
        }
    }
}