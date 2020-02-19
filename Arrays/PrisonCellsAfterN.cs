namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PrisonCellsAfterN
    {
        public int[] PrisonAfterNDays(int[] cells, int n)
        {
            // can see right away that bas4ed on the 1 = 10^9 constraint this is a DP problem after a few iterations.
            // the state is limited tha there could not be possibly 10^9 different results. So let's create a hashset to store our current state.
            HashSet<List<int>> states = new HashSet<List<int>>();
            HashSet<string> stateString = new HashSet<string>();
            List<int> newState = new List<int>(cells);
            string stringResult = string.Empty;
            while (n > 0 && !stateString.Contains(stringResult))
            {
                states.Add(newState);

                List<int> nextState = new List<int>(newState);
                n--;
                // we can usually ignore and assume the 0 at the start and end of the set, but only after the first iter, so let's check that and deal with them first
                nextState[0] = 0;
                nextState[7] = 0;
                for (int i = 1; i < 7; i++)
                {
                    // check adjacentcy equal
                    if (newState[i - 1] == newState[i + 1])
                    {
                        nextState[i] = 1;
                    }
                    else
                    {
                        nextState[i] = 0;
                    }
                }

                StringBuilder b = new StringBuilder();
                newState.ForEach(c => b.Append(c));
                stringResult = b.ToString();
                stateString.Add(stringResult);
                newState = nextState;
                b.Clear();
                newState.ForEach(c => b.Append(c));
                stringResult = b.ToString();
            }


            if (n != 0)
            {
                List<string> list = stateString.ToList();
                int firstRepitition = list.IndexOf(stringResult);
                while (firstRepitition != 0)
                {
                    list.RemoveAt(0);
                    firstRepitition--;
                }

                int distanceAway = n % list.Count;
                // so if we kept doing this statestring.count times until we hit n, we'd
                // want to stop just before we crossed n, and then meet him where his remainder = us
                return states.ToList()[distanceAway + (states.Count - list.Count)].ToArray();
            }

            return newState.ToArray();
        }
    }
}