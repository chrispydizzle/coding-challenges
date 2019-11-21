namespace CodeChallenges.Solves
{
    internal class DepositProfit
    {
        public int depositProfit(int deposit, int rate, int threshold)
        {
            decimal d = deposit;
            decimal r = rate;
            r = r / 100;
            int counter = 0;
            while (d < threshold)
            {
                d += d * r;
                counter++;
            }

            return counter;
        }
    }
}