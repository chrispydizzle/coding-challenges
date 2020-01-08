namespace CodeChallenges.Arrays
{
    public class PlaceFlowers
    {
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int pointer = 0;
            // we will move a pointer across the array, checking both sides of each zero we find.
            // if we're at an edge and the other side is a zero we  can also place flowers.

            while (n > 0 && pointer < flowerbed.Length)
            {
                // validate far right or far left and tweak behavior
                if (flowerbed[pointer] != 1)
                {
                    bool freeLeft, freeRight;
                    if (pointer == 0)
                        freeLeft = true;
                    else
                        freeLeft = flowerbed[pointer - 1] == 0;

                    if (pointer == flowerbed.Length - 1)
                        freeRight = true;
                    else
                        freeRight = flowerbed[pointer + 1] == 0;

                    if (freeLeft && freeRight)
                    {
                        flowerbed[pointer] = 1;
                        n--;
                    }
                }

                pointer++;
            }

            return n == 0;
        }
    }
}