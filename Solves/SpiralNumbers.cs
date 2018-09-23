namespace Pdrome2
{
    using System.Collections.Generic;

    internal class SpiralNumbers
    {
        public int[][] spiralNumbers(int n)
        {
            int[][] container = new int[n][];
            for (int i = 0; i < container.Length; i++)
            {
                container[i] = new int[n];
            }

            bool done = false;
            int loopStart = 0;
            int number = 0;
            while (!done)
            {
                number++;

                //mv right
                for (int i = loopStart; i < container[loopStart].Length - loopStart; i++)
                {
                    container[loopStart][i] = number;
                    number++;
                }

                //mv dn
                for (int i = loopStart + 1; i < container.Length - loopStart; i++)
                {
                    container[i][container[i].Length - loopStart - 1] = number;
                    number++;
                }

                //mv left
                for (int i = container[0].Length - 1 - loopStart - 1; i > loopStart; i--)
                {
                    container[container[i].Length - loopStart - 1][i] = number;
                    number++;
                }

                //mv up
                for (int i = container.Length - loopStart - 1; i > loopStart; i--)
                {
                    container[i][loopStart] = number;
                    number++;
                }

                loopStart++;
                number--;
                if (container[loopStart][loopStart] != 0)
                {
                    done = true;
                }
            }

            return container;
        }
    }
}