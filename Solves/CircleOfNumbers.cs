namespace CodeChallenges.Solves
{
    internal class CircleOfNumbers
    {
        public int circleOfNumbers(int n, int firstNumber)
        {
            int half = n / 2;
            if (firstNumber < half)
            {
                return firstNumber + half;
            }

            return firstNumber - half;
        }
    }
}