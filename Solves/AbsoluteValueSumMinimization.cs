namespace Pdrome2.Solves
{
    internal class AbsoluteValueSumMinimization
    {
        public int absoluteValuesSumMinimization(int[] a)
        {
            int middle = a.Length / 2;
            if (a.Length % 2 == 0 && a.Length > 1)
            {
                middle--;
            }
            return a[middle];
        }
    }
}