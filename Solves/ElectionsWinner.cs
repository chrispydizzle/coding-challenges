namespace Pdrome2
{
    using System.Linq;

    internal class ElectionsWinner
    {
        public int electionsWinners(int[] votes, int k)
        {
            int votesMax = votes.Max();
            int counter = 0;

            if (k == 0)
            {
                if (votes.Count(c => c == votesMax) == 1)
                {
                    return 1;
                } 
            }
            
            foreach (int vote in votes)
            {
                if (vote + k > votesMax)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}