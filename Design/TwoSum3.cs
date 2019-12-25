namespace CodeChallenges.Design
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TwoSum3
    {
        private readonly HashSet<int> added = new HashSet<int>();
        private readonly HashSet<int> sums = new HashSet<int>();

        /**
         * Add the number to an internal data structure..
         */
        public void Add(int number)
        {
            if (added.Contains(number))
            {
                sums.Add(number + number);
                return;
            }

            added.Add(number);
        }

        public bool Find(int value)
        {
            if (sums.Contains(value)) return true;
            if (added.Count < 2) return false;

            foreach (int item in added)
            {
                int target = value - item;
                if (target == item) continue;
                if (added.Contains(target)) return true;
            }

            return false;
        }

        /**
         * Find if there exists any pair of numbers which sum is equal to the value.
         */
        private bool OldFind(int value)
        {
            if (sums.Contains(value)) return true;
            if (added.Count < 2) return false;

            List<int> list = added.ToList();
            int? lastSum = new int?();
            int counter = 0;

            while (list[counter] + list[counter + 1] <= value && counter < list.Count - 1)
            {
                int currentTest = list[counter];
                for (int i = counter + 1; i < list.Count && (!lastSum.HasValue || lastSum.Value < value); i++)
                {
                    int thisNumber = list[i];
                    lastSum = currentTest + thisNumber;
                    sums.Add(lastSum.Value);
                    if (lastSum == value) return true;
                }

                counter++;
            }

            return false;
        }

        public static Queue<Func<bool?>> DoActions(string[] actions, int[] values, TwoSum3 ts3)
        {
            Queue<Func<bool?>> results = new Queue<Func<bool?>>();
            for (int i = 1; i < actions.Length; i++)
            {
                int number = values[i];
                if (actions[i] == "add")
                    results.Enqueue(() =>
                    {
                        ts3.Add(number);
                        return null;
                    });

                if (actions[i] == "find") results.Enqueue(() => ts3.Find(number));
            }

            return results;
        }
    }
}