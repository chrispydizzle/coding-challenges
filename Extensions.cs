namespace ExtensionMs
{
    using System.Collections.Generic;
    using CodeChallenges.Arrays;

    public static class Extensions
    {
        public static int CompareAsVersion(this string s1, string s2)
        {
            CompareVersionNums n = new CompareVersionNums();
            return n.CompareVersion(s1, s2);
        }

        public static List<IList<int>> MakeIList(this int[][] array)
        {
            List<IList<int>> result = new List<IList<int>>();
            foreach (int[] ints in array)
            {
                List<int> newL = new List<int>(ints);
                result.Add(newL);
            }

            return result;
        }
    }
}