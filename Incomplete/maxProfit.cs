namespace Pdrome2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class maxProfit
    {
        public void Main()
        {
            Console.WriteLine(new maxProfit().MaxProfit(new[] {7, 1, 5, 3, 6, 4})); // 7
            Console.WriteLine(new maxProfit().MaxProfit(new[] {1, 2, 3, 4, 5})); // 4
            Console.WriteLine(new maxProfit().MaxProfit(new[] {7, 6, 4, 3, 1})); // 0
        }

        // TODO: Understand this better
        public int MaxProfit(int[] prices)
        {
            if (prices.Count() < 2) return 0;

            int result = 0, buy = prices[0];
            for (int i = 0; i < prices.Count(); i++)
            {
                buy = Math.Min(prices[i], buy);
                int max = Math.Max(buy, prices[i]);
                result += max - buy;
                if (max - buy != 0) buy = prices[i];
            }

            return result;
        }
    }
}