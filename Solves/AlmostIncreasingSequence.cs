namespace Pdrome2.Solves
{
    using System.Collections.Generic;

    public class AlmostIncreasingSequence
    {
        public bool almostIncreasingSequence(int[] sequence)
        {
            bool isOrdered = true;
            int popsteps = 0;

            List<int> sequenceList = new List<int>(sequence);

            do
            {
                isOrdered = true;
                for (int index = 0; index < sequenceList.Count - 1; index++)
                {
                    int previousItem = int.MinValue;
                    int currentItem = sequenceList[index];
                    int nextItem = int.MinValue;
                    int nextNextItem = int.MinValue;
                    
                    
                    if (index != 0)
                    {
                        previousItem = sequenceList[index - 1];
                    }
                    
                    if (index != sequenceList.Count -1)
                    {
                        nextItem = sequenceList[index + 1];
                    }
                    
                    if (index != sequenceList.Count -2)
                    {
                        nextNextItem = sequenceList[index + 2];
                    }

                    if ( currentItem < nextItem)
                    {
                        continue;
                    }

                    int targetIndex = index;
                    
                    if ((index != 0 && index != sequenceList.Count - 1 && nextItem >= previousItem)
                        && !(nextNextItem >= int.MinValue && nextNextItem <= currentItem))
                    {
                        targetIndex = targetIndex + 1;
                    }

                    if (index == sequenceList.Count - 2 && nextItem < previousItem && nextItem < currentItem)
                    {
                        targetIndex = targetIndex + 1;
                    }
                    
                    isOrdered = false;
                    sequenceList.RemoveAt(targetIndex);
                    popsteps++;
                }
                
            } while (!isOrdered);

            return popsteps <= 1;
        }

        public bool almostIncreasingSequenceBleh(int[] sequence)
        {
            int removeCount = 0;
            for (int index = 1; index < sequence.Length - 1; index++)
            {
                int current = sequence[index];
                int next = sequence[index + 1];
                int previous = sequence[index - 1];

                if (current > next && previous > next && previous < current)
                {
                    removeCount++;
                }

                if (next <= previous)
                {
                    removeCount++;
                }
            }

            return removeCount < 1;
        }
    }
}