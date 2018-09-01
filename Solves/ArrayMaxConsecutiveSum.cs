namespace Pdrome2
{
    internal class ArrayMaxConsecutiveSum
    {
        public int arrayMaxConsecutiveSum(int[] inputArray, int k)
        {
            int largest = int.MinValue;
            int sum = 0;
            for (int index = 0; index < inputArray.Length ; index++)
            {
                sum += inputArray[index];
                
                if (index >= (k - 1))
                {
                    int numberToSubtract = inputArray[index - (k - 1)];
                    if (sum > largest)
                    {
                        largest = sum;
                    }

                    sum -= numberToSubtract;
                }
            }

            return largest;
        }
    }
}