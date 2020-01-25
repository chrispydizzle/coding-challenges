namespace CodeChallenges.DynamicProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ChangeCoins
    {
        public int CoinChange(int[] coins, int amount)
        {
            int coinsUsed = 0;
            // naive approach, just try subtracting the largest value first as many times as possible, then smaller and smaller.
            // a better way might be to use division, it's faster let's do that.

            // okay, it's not that simple, we have to consider weird things like amounts of 6249 and coins ==  186
            // optimal subsystem, multiple repeating subproblems,this is DP.
            Array.Sort(coins); // sort the coin amounts so we can try the largest first
            List<int> coinList = new List<int>(coins);
            int bestZero = -1;
            HashSet<int> badMoves = new HashSet<int>(); // contains moves we shouldn't attempt again because they don't lead to zero.
            Dictionary<int, int> amountCoins = new Dictionary<int, int>(); // this is our best sum dictionary, keys are remianing amounts, values are coins used

            int smallest = amount;
            amountCoins[amount] = 0;
            int keys = 0;

            while (!amountCoins.ContainsKey(0) && amountCoins.Keys.Count != keys)
            {
                for (int i = coinList.Count - 1; i >= 0; i--)
                {
                    int currentCoin = coins[i];

                    List<int> list = amountCoins.Keys.Where(key => key >= currentCoin).ToList();
                    for (int j = 0; j < list.Count; j++)
                    {
                        int newVal = list[j] - currentCoin;
                        if (newVal < 0) break;

                        int targetAmount = amount - newVal;

                        int coin = amountCoins[list[j]] + 1;

                        if (amountCoins.ContainsKey(targetAmount))
                        {
                            int amountCoin = coin + amountCoins[targetAmount];

                            if (!amountCoins.ContainsKey(0) || amountCoins[0] < amountCoin)
                            {
                                amountCoins[0] = amountCoin;
                            }
                        }

                        amountCoins.Add(newVal, coin);
                        list.Add(newVal);
                    }

                    /* if ((!amountCoins.ContainsKey(testAmount) || amountCoins[testAmount] > coinsUsed) && testAmount >= 0)
                     {
                         amountCoins[testAmount] = coinsUsed;
                         smallest = Math.Min(smallest, testAmount);
                         if (testAmount == 0)
                         {
                             bestZero = coinsUsed;
                         }
                     }*/


                    smallest = amount;
                }

                keys = amountCoins.Keys.Count;
                Console.WriteLine($"{smallest} {coinsUsed}");
            }
            /*int baseValue = 0;
            List<int> baseCoins = new List<int>();
            Dictionary<int, int> newCoins = new Dictionary<int, int>(); // represents "combination coins"
            while (smallest != 0 && coinList.Count > 0)
            {
                int nextCoin = coinList.First();
                baseCoins.Add(nextCoin);
                coinList.Remove(nextCoin);
                baseValue += nextCoin;

                foreach (int coin in coinList)
                {
                    int newValue = coin + baseValue;
                    int coinCost = baseCoins.Count + 1;
                    newCoins.Add(newValue, coinCost);
                    if (amountCoins.ContainsKey(newValue) && (!amountCoins.ContainsKey(0) || amountCoins[0] > amountCoins[newValue] + coinCost))
                    {
                        amountCoins[0] = amountCoins[newValue] + coinCost;
                        smallest = 0;
                        bestZero = amountCoins[0];
                    }
                }
            }*/
            //}


            if (!amountCoins.ContainsKey(0)) return -1;

            return amountCoins[0];
        }
    }
}