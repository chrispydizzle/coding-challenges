namespace CodeChallenges.Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CompareVersionNums
    {
        public int CompareVersion(string version1, string version2)
        {
            // like implementing an Icompare
            // if right side > return 1
            // left side > return -1
            // equal return 0
            var v1 = new List<int>(Array.ConvertAll(version1.Split(new[] {'.'}), int.Parse));
            var v2 = new List<int>(Array.ConvertAll(version2.Split(new[] {'.'}), int.Parse));
            while (v1.Count < v2.Count)
            {
                v1.Add(0);
            }

            while (v2.Count() < v1.Count())
            {
                v2.Add(0);
            }

            for (int i = 0; i < v1.Count(); i++)
            {
                if (v1[i] > v2[i]) return 1;
                if (v1[i] < v2[i]) return -1;
            }

            return 0;
        }
    }
}