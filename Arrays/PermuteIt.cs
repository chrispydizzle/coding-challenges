namespace CodeChallenges.Arrays
{
    using System;
    using System.Collections.Generic;

    public class PermuteIt
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            // validate input
            // nums will be distinct.
            // kind of a semi-recursive soltion.
            // we will foreach the first digit ? maybe not req
            return this.Permute(new int[] { }, nums);
            // create a method with signiture returns List<List<int>> (int[],  int[])
        }

        public IList<IList<int>> Permute(int[] lnums, int[] rnums)
        {
            // first we new up a result set of list<list

            var result = new List<IList<int>>();
            //     result.add(new list (1,2,3,4)) // when we have just one number on the right, we return it as a result <--!!base case
            if (rnums.Length == 1)
            {
                Console.WriteLine(rnums[0]);
                var nRes = new List<int>(lnums);
                nRes.Add(rnums[0]);
                result.Add(nRes);
                return result;
            }


            // otherwise we want to essentially start locking numbers in place and swapping around their counterparts like so:

            // the recursive call will also shift the depth of the left array by one step: ie:
            // lock(1) > 2, 3, 4
            //  lock(1,2) > 3, 4
            //   lock(1,2,3) > 4

            // create a new left array that's one size larger

            int[] newLeft = new int[lnums.Length + 1];

            // copy old left into new left leaving new spot empty
            Array.Copy(lnums, newLeft, lnums.Length);

            // foreach in rnums , with each recursion call pushing a number from the right to the left ie:

            //  { lock(1) > 2, 3, 4}
            //  { lock(2) > 1, 3, 4}
            //  { lock(3) > 1, 2, 4} etc..
            for (int i = 0; i < rnums.Length; i++)
            {
                // set new last lock digit
                newLeft[newLeft.Length - 1] = rnums[i];

                // create new right
                int[] newRight = new int[rnums.Length - 1];

                // copy everything to the left of i if i > 0 & the right if i < rnumsLe
                if (i > 0)
                {
                    Array.Copy(rnums, 0, newRight, 0, i);
                }

                Console.WriteLine($"{newRight[0]}");
                if (i < rnums.Length)
                {
                    // Console.WriteLine(i);
                    Array.Copy(rnums, i + 1, newRight, i, rnums.Length - i - 1);
                }

                // go deeper
                //   lock(1,2) > 3, 4
                //   lock(1,2, 4) > 3 // this will be our next to last recursion call. Should work, let's try it.
                // base case is when
                result.AddRange(this.Permute(newLeft, newRight));
            }


            //     return list

            return result;
        }
    }
}