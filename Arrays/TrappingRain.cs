namespace CodeChallenges.Arrays
{
    using System;

    public class TrappingRain
    {
        /// <summary>
        /// 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 = 6
        /// 3, 1, 3, 2, 1, 0, 1, 3, 2, 1, 2, 1 = 6
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            int result = 0;
            int lPoint = 0;
            int lMax = 0;
            int rMax = 0;
            int rPoint = height.Length - 1;
            while (lPoint < rPoint)
            {
                int rHeight = height[rPoint];
                int lHeight = height[lPoint];

                lMax = Math.Max(lMax, lHeight);
                rMax = Math.Max(rMax, rHeight);
                if (lHeight < rMax)
                {
                    if (lHeight < lMax)
                    {
                        result += lMax - lHeight;
                    }

                    lPoint++;
                }
                else
                {
                    if (rHeight < rMax)
                    {
                        result += rMax - rHeight;
                    }

                    rPoint--;
                }
            }


            return result;
        }
    }
}