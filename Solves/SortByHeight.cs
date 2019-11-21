namespace CodeChallenges.Solves
{
    using System.Collections.Generic;
    using System.Linq;

    public class SortByHeight
    {
        public static int[] people = {-1, 150, 190, 170, -1, -1, 160, 180};

        public int[] sortByHeight(int[] a)
        {
            Queue<int> orderedList = new Queue<int>(a.Where(i => i > 0).OrderBy(c => c));
            int[] orderedArray = new int[a.Length];

            for (int index = 0; index < a.Length; index++)
            {
                if (a[index] == -1)
                {
                    orderedArray[index] = -1;
                    continue;
                }

                orderedArray[index] = orderedList.Dequeue();
            }

            return orderedArray;
        }
    }
}