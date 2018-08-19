namespace CodingChallenges
{
    internal class AlternatingSums
    {
        public int[] alternatingSums(int[] a)
        {
            int weightOne = 0;
            int weightTwo = 0;

            bool flip = false;
            for (int i = 0; i < a.Length; i++)
            {
                if (flip)
                {
                    weightTwo += a[i];
                }
                else
                {
                    weightOne += a[i];
                }

                flip = !flip;
            }

            return new[] {weightOne, weightTwo};
        }

    }
}