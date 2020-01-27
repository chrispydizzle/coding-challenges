namespace CodeChallenges.Design
{
    using System;

    public class SqrtOf
    {
        public int MySqrt(int x)
        {
            Console.WriteLine(x);
            if (x < 2) return x;

            int l = this.MySqrt(x >> 2);
            l = l << 1;
            int r = l + 1;
            long result = (long) r * r > x ? l : r;
            Console.WriteLine(result);
            return (int) result;
        }
    }
}