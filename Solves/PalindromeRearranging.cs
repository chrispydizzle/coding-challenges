namespace Pdrome2.Solves
{
    using System.Collections.Generic;

    internal class PalindromeRearranging
    {
        public bool palindromeRearranging(string inputString)
        {
            Dictionary<char, int> counts = new Dictionary<char, int>();
            counts.Add('a', 0);
            counts.Add('b', 0);
            counts.Add('c', 0);
            counts.Add('d', 0);
            counts.Add('e', 0);
            counts.Add('f', 0);
            counts.Add('g', 0);
            counts.Add('h', 0);
            counts.Add('i', 0);
            counts.Add('j', 0);
            counts.Add('k', 0);
            counts.Add('l', 0);
            counts.Add('m', 0);
            counts.Add('n', 0);
            counts.Add('o', 0);
            counts.Add('p', 0);
            counts.Add('q', 0);
            counts.Add('r', 0);
            counts.Add('s', 0);
            counts.Add('t', 0);
            counts.Add('u', 0);
            counts.Add('v', 0);
            counts.Add('w', 0);
            counts.Add('x', 0);
            counts.Add('y', 0);
            counts.Add('z', 0);

            // count number of occurs of each letter
            foreach (char c in inputString)
            {
                counts[c]++;
            }

            int determinant = inputString.Length % 2;
            if (determinant == 0)
            {
                // all must be even
                foreach (KeyValuePair<char, int> keyValuePair in counts)
                {
                    if (keyValuePair.Value % 2 == 1)
                    {
                        return false;
                    }
                }
            }
            else
            {
                int foundOdd = 0;
                // if length is odd, all counts of letters must be even except one.
                foreach (KeyValuePair<char, int> keyValuePair in counts)
                {
                    if (keyValuePair.Value % 2 == 1)
                    {
                        if (foundOdd == 1) return false;
                        foundOdd++;
                    }
                }
            }

            return true;
        }
    }
}