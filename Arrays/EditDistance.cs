namespace CodeChallenges.Arrays
{
    using System.Collections.Generic;
    using System.Linq;

    public class EditDistance
    {
        public int MinDistance(string word1, string word2)
        {
            // how does a person do this?
            // a bfs is optimal.
            int numChanges = 0;
            Queue<string> nextOp = new Queue<string>();

            nextOp.Enqueue(word1);
            while (nextOp.Any())
            {
                string result = nextOp.Dequeue();
                if (result == word2) return numChanges;

                numChanges++;

                if (result.Length < word2.Length)
                {
                    // insert
                }

                if (result.Length > word2.Length)
                {
                    // delete
                }

                // replace
            }

            return numChanges;
        }
    }
}