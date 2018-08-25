namespace Pdrome2
{
    public class AdjacentGreatestProduct
    {
        public int adjacentElementsProduct(int[] inputArray)
        {
            int currentTop = int.MinValue;

            if (inputArray.Length == 2)
            {
                return inputArray[0] * inputArray[1];
            }
            
            for (int i = 1; i < inputArray.Length -1; i++)
            {
                currentTop = this.CurrentTop(inputArray[i] * inputArray[i - 1], currentTop);
                currentTop = this.CurrentTop(inputArray[i] * inputArray[i + 1], currentTop);
            }

            return currentTop;
        }

        private int CurrentTop(int currentContenderLeft, int currentTop)
        {
            if (currentContenderLeft > currentTop)
            {
                currentTop = currentContenderLeft;
            }

            return currentTop;
        }
    }
}