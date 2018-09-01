namespace Pdrome2.Solves
{
    using System;

    public class IsLucky
    {
        public bool isLucky(int n)
        {
            string s = n.ToString();
            int sLen = s.Length;
            int mid = sLen / 2;
            string fHalf = s.Substring(0, mid);
            string sHalf = s.Substring(mid);

            Func<string, int> addNums = (st) =>
            {
                int result = 0;
                foreach (char c in st)
                {
                    int i = int.Parse(c.ToString());
                    result += i;
                }

                return result;
            };
            
            return addNums(fHalf) == addNums(sHalf);
        }
    }
}