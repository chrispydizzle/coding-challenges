namespace CodeChallenges.Solves
{
    internal class EvenDigitsOnly
    {
        public bool evenDigitsOnly(int n)
        {
            string result = n.ToString();
            foreach (char c in result)
            {
                int number = int.Parse(c.ToString());
                if (number % 2 != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}