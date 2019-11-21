namespace CodeChallenges.Solves
{
    internal class GrowingPlant
    {
        public int growingPlant(int upSpeed, int downSpeed, int desiredHeight)
        {
            int days = 0;
            do
            {
                days++;
                desiredHeight -= upSpeed;
                if (desiredHeight <= 0) break;

                desiredHeight += downSpeed;
            } while (desiredHeight > 0);

            return days;
        }
    }
}