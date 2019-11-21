namespace CodeChallenges.Solves
{
    internal class DigitDegree
    {
        public int digitDegree(int n)
        {
            string currentResult = n.ToString();
            int counter = 0;
            while (currentResult.Length > 1)
            {
                counter++;
                int sum = 0;
                foreach (char c in currentResult)
                {
                    sum += int.Parse(c.ToString());
                }

                currentResult = sum.ToString();
            }

            return counter;
        }
    }
}