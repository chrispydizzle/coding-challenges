namespace CodeChallenges.Solves
{
    using System.Collections.Generic;

    internal class FirstDuplicate
    {
        public int firstDuplicate(int[] a)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            foreach (int i in a)
            {
                if (d.ContainsKey(i))
                {
                    return i;
                }

                d.Add(i, 1);
            }

            return -1;
        }
    }
}