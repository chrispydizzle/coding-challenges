namespace CodeChallenges.Solves
{
    internal class AreSimilar
    {
        public bool areSimilar(int[] a, int[] b)
        {
            bool areSimilar = true;
            int[][] differentNumberSet =
            {
                new[] {0, 0},
                new[] {0, 0}
            };

            int differentNumbers = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    if (differentNumbers == 2) return false;
                    differentNumberSet[differentNumbers][0] = a[i];
                    differentNumberSet[differentNumbers][1] = b[i];
                    differentNumbers++;
                }
            }

            if (differentNumbers == 2)
            {
                int[] setOne = differentNumberSet[0];
                int[] setTwo = differentNumberSet[1];
                if (setOne[0] == setTwo[1] && setOne[1] == setTwo[0])
                {
                    return true;
                }

                return false;
            }

            return areSimilar;
        }
    }
}