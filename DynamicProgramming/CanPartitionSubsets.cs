namespace CodeChallenges.DynamicProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CanPartitionSubsets
    {
        // TODO: was really close on this one. Need to revisit.
        // TODO: has a DP solution.
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            int sum = nums.Sum();
            if (sum % k > 0) return false;
            int target = sum / k;

            Array.Sort(nums);

            int row = nums.Length - 1;
            if (nums[row] > target) return false;

            while (row >= 0 && nums[row] == target)
            {
                row--;
                k--;
            }

            return this.Search(new int[k], row, nums, target);
        }

        public bool Search(int[] groups, int row, int[] nums, int target)
        {
            if (row < 0) return true;
            int v = nums[row--];
            for (int i = 0; i < groups.Length; i++)
            {
                if (groups[i] + v <= target)
                {
                    groups[i] += v;
                    if (Search(groups, row, nums, target)) return true;
                    groups[i] -= v;
                }

                if (groups[i] == 0) break;
            }

            return false;
        }

        public bool CanPartitionKSubsetsWrong(int[] nums, int k)
        {
            if (k == 1) return true;
            List<int> numList = new List<int>(nums);

            // Sum all values in nums
            int sum = nums.Sum();
            int target = sum / k;

            int remains = sum % k;
            if (remains > 0) return false;

            var sets = new List<List<int>>();
            if (numList.Contains(target))
            {
                sets.Add(new List<int>(new[] {target}));
                numList.Remove(target);
            }

            bool possible = true;
            List<int> currentSet = new List<int>();

            Dictionary<int, int> numberDict = numList.GroupBy(c => c)
                .Select(x => new {x.Key, Count = x.Count()})
                .ToDictionary(v => v.Key, v => v.Count);
            while (sets.Count < k && numberDict.Any() && possible)
            {
                int max = numberDict.Keys.Max();
                int difference = target - max;
                numberDict[max]--;
                if (numberDict[max] == 0)
                {
                    numberDict.Remove(max);
                }

                currentSet.Add(max);


                if (numberDict.ContainsKey(difference))
                {
                    currentSet.Add(difference);
                    numberDict[difference]--;
                    if (numberDict[difference] == 0) numberDict.Remove(difference);
                    sets.Add(currentSet);
                    currentSet = new List<int>();
                    continue;
                }


                int highFreqKey = numberDict.First(v => v.Value == numberDict.Values.Max()).Key;
                numberDict[highFreqKey]--;

                if (numberDict[highFreqKey] == 0) numberDict.Remove(highFreqKey);

                currentSet.Add(highFreqKey);

                difference -= highFreqKey;
                List<int> diffSum = new List<int>();
                while (!diffSum.Any() && difference != diffSum.Sum())
                {
                    int remainder = difference - diffSum.Sum();
                    foreach (int key in numberDict.Where(kv => kv.Value > 0 && kv.Key < remainder).Select(kvp => kvp.Key))
                    {
                        int leftover = remainder - key;
                        if (numberDict.Keys.All(lk => leftover < lk)) continue;

                        if (numberDict[key] > 0)
                        {
                            numberDict[key]--;
                            if (numberDict[key] == 0) numberDict.Remove(key);
                            diffSum.Add(key);
                            break;
                        }
                        else
                        {
                            numberDict.Remove(key);
                        }

                        if (numberDict.ContainsKey(leftover))
                        {
                            numberDict[leftover]--;
                            if (numberDict[leftover] == 0) numberDict.Remove(leftover);
                            diffSum.Add(leftover);
                            break;
                        }
                    }
                }
            }

            if (numberDict.Any()) return false;
            return true;
        }
    }
}