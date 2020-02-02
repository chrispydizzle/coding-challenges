namespace CodeChallenges.Interviews
{
    using System;
    using System.Collections.Generic;

    // "the", "quick", "brown", "fox", "quick"

    public class WordDistanceFinder
    {
        private readonly Dictionary<string, List<int>> wordIndexes = new Dictionary<string, List<int>>();

        public WordDistanceFinder(List<string> words)
        {
            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];
                if (this.wordIndexes.ContainsKey(word))
                {
                    this.wordIndexes[word].Add(i);
                }
                else
                {
                    this.wordIndexes.Add(word, new List<int>());
                    this.wordIndexes[word].Add(i);
                }
            }
        }

        //"fox", "quick", "the", "fox", "quick"

        public int distance(string wordOne, string wordTwo)
        {
            // wordOne and two pull out index list
            // foreach in wordOne list Absolute Val of the difference between current item and index of word two
            if (!this.wordIndexes.ContainsKey(wordOne) || !this.wordIndexes.ContainsKey(wordTwo))
            {
                return -1;
            }

            if (wordOne == wordTwo) return 0;

            List<int> w1 = this.wordIndexes[wordOne];
            List<int> w2 = this.wordIndexes[wordTwo];

            int currentValue = int.MaxValue;
            foreach (int pos1 in w1)
            {
                foreach (int pos2 in w2)
                {
                    currentValue = Math.Min(currentValue, Math.Abs(pos1 - pos2));
                }
            }

            return currentValue;
        }
    }

    // distance("the", "quick") // return 1

    // loop start
    // find first occurance of either word
    // seek left until other word
    // seek right until other word
    // continue

    internal class HelloWorld
    {
        public bool HasOpen(int[] row, int num)
        {
            if (num == 0) return true;

            if (row.Length == 1)
            {
                if (row[0] == 0 && num == 1) return true;
                return false;
            }

            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] == 0 // seat is empty
                    && (i == 0 || row[i - 1] == 0) // check left or make sure it's the first seat
                    && (i == row.Length - 1 || row[i + 1] == 0)) // check right or make sure it's the last seat
                {
                    num--;
                    row[i] = 1;
                }

                if (num <= 0) return true;
            }

            return false;
        }
        // [1,8,5,3,7,2], 3

        // [5,7,8]

        public int FindKLargest(int[] nums, int k)
        {
            Heap h = new RHeap();
            for (int i = 0; i < nums.Length; i++)
            {
                int n = nums[i];
                if (h.Count() < k)
                {
                    h.Insert(n);
                    continue;
                }


                if (n > h.Peek())
                {
                    h.Pop();
                    h.Insert(n);
                }
            }

            return h.Peek();
        }

        // Input: [1,0,0,1,0,0,1,0,0]

        // x = 3 ; return => true
        // x = 4; return => false

        /*

    Write a function that, given a List returns the Nth largest element in that List

    */

        interface Heap
        {
            int Peek();

            void Pop();

            void Insert(int i);

            int Count();
        }

        public class RHeap : Heap
        {
            public int Peek()
            {
                throw new NotImplementedException();
            }

            public void Pop()
            {
                throw new NotImplementedException();
            }

            public void Insert(int i)
            {
                throw new NotImplementedException();
            }

            public int Count()
            {
                throw new NotImplementedException();
            }
        }
        // convert to array

        // [1,5,8]
        // Heap : [8, 7, 5,3,2,1]
        // while heap.pop()
        // heap.pop
        // array sort
        // array len - k - 1
    }
}