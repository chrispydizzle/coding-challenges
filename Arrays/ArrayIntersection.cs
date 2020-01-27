namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;
    using System.Linq;

    public class ArrayIntersection
    {
        public int[] Intersection(int[] nums1, int[] nums2) {
            var n = new HashSet<int>();
            var n2 = new HashSet<int>();
            for(int i = 0; i < nums1.Length; i++){
                n.Add(nums1[i]);
            }

            for(int i = 0; i < nums2.Length; i++){
                if(n.Contains(nums2[i]))
                {
                    n2.Add(nums2[i]);
                }
            }

            return n2.ToArray();
        }
    }
}