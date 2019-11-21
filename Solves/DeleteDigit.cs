namespace CodeChallenges.Solves
{
    internal class DeleteDigit
    {
        public int deleteDigit(int n)
        {
            int max = int.MinValue;
            string strResult = n.ToString();

            for (int index = 0; index < strResult.Length; index++)
            {
                string newStringLeft = strResult.Substring(0, index);
                string newStringRight = strResult.Substring(index + 1);
                int current = int.Parse($"{newStringLeft}{newStringRight}");
                if (current > max) max = current;
            }

            return max;
        }
    }
}