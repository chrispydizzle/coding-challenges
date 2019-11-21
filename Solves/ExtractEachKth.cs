namespace CodeChallenges.Solves
{
    using System.Collections.Generic;

    public class ExtractEachKth
    {
        public int[] extractEachKth(int[] inputArray, int k)
        {
            // int[] output = new int[inputArray.Length - 1];
            List<int> output = new List<int>();

            int counter = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                counter++;
                if (counter == k)
                {
                    counter = 0;
                }
                else
                {
                    output.Add(inputArray[i]);
                }
            }

            return output.ToArray();
        }
    }
}