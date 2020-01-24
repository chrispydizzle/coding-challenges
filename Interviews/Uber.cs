namespace CodeChallenges
{
    using System.Collections.Generic;
    using System.Linq;

    public class Uber
    {
        public Uber()
        {
        }

        int digitsManipulations(int n)
        {
            // sanitizaiton required?

            string s = n.ToString();
            // start with zero sum (To do x+=)
            int sum = 0;
            // 1 production (To do x*=)
            int product = 1;
            for (int i = 0; i < s.Length; i++)
            {
                // get the next char
                string c = s[i].ToString();

                // get current int
                int currentInt = int.Parse(s);

                // do work
                sum += currentInt;
                product *= currentInt;
            }

            return product - sum;
        }

        public int countPairsWithSum(int k, int[] a)
        {
            // k is my target
            // for each number, take target minus the num, which will give you the other number you need.
            // first let's get all the pairs,

            HashSet<int> uniqueDifferences = new HashSet<int>();

            List<List<int>> combosFound = new List<List<int>>();

            for (int i = 0; i < a.Length; i++)
            {
                int currentDifference = k - a[i];


                int foundMatch = uniqueDifferences.FirstOrDefault(x => x == a[i]);
                if (foundMatch > 0)
                {
                    uniqueDifferences.Add(currentDifference);
                }
            }

            return combosFound.Count;
            // we should now have in comboosFound all possible combos, need to reduce them to uniques
            // this is not the most efficient :/
            // int array2 = a.ToList().ToArray();
            // need to get multiple pairs and return the count of those distinct pairs. How?
        }
    }
}