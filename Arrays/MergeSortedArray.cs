namespace CodeChallenges.Arrays
{
    public class MergeSortedArray
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            // create pointer on nums1
            int pointer = 0;

            // iterate each item in nums2
            foreach (int t in nums2)
            {
                // while !(nums[pointer+1] > nums2[i] >= nums1[pointer])
                while (pointer < nums1.Length && nums1[pointer] <= t && pointer < m)
                {
                    pointer++;
                }

                // to do insert into nums 1
                // for nums1[j] from end of nums1 - 1 j-- j > pointer
                for (int j = nums1.Length - 2; j >= pointer; j--)
                {
                    nums1[j + 1] = nums1[j];
                }

                nums1[pointer] = t;
                m++;
            }
        }
    }
}