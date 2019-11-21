namespace CodeChallenges.Solves
{
    using System.Linq;

    internal class AvoidObstacles
    {
        public int avoidObstacles(int[] inputArray)
        {
            int jumpsize = 1;
            bool leaptAll = false;
            int position = 0;
            int highest = inputArray.Max();
            do
            {
                position += jumpsize;
                foreach (int i in inputArray)
                {
                    if (position == i)
                    {
                        position = 0;
                        jumpsize++;
                        break;
                    }
                }

                if (position > highest)
                {
                    leaptAll = true;
                }
            } while (leaptAll == false);

            return jumpsize;
        }
    }
}