namespace CodeChallenges.DynamicProgramming
{
    using System.Linq;

    public class EditDistance
    {
        /// <summary>
        /// Let's have a go at this.
        /// It can be broken down into smaller subproblems.
        /// It helps to work backwords to understand it.
        /// This, in the worst case, can be exponentially difficult to solve if we use the naive (ie: bforce)
        ///    NOTE: optimal substructure & overlapping subproblems.
        /// However, since the naive solution will cause us to do the same thing over and over to solve it (as with fibonacci)
        /// We can treat this as a DP problem.
        /// </summary>
        /// <param name="word1">horse</param>
        /// <param name="word2">ros</param>
        /// <returns></returns>
        public int MinDistance(string word1, string word2)
        {
            // data for dp can be stored in a tabular format, as so:

            // we are adding an extra row because there is a chance one string could be empty.
            // that is the base case we will discuss later.
            // rows represent the letters in word 1
            int[][] dpTable = new int[word1.Length + 1][];
            for (int i = 0; i < dpTable.Length; i++)
            {
                // columns represent the letters in word 2
                dpTable[i] = new int[word2.Length + 1];
            }


            // an optimization we can consider later would be doing some sort of word alignment. I'm not there yet.


            // the optimal substructure is the lowest number of edits.
            // the subproblems are the three types of calculations we can do against each letter. (insert, delete, or replace)

            // base case is word2 (or word1) is string.Empty (our "zero")
            for (int i = 0; i < word1.Length + 1; i++)
            {
                for (int j = 0; j < word2.Length + 1; j++)
                {
                    // "zero" case would be the word we'd have to do if the counter string was empty.
                    // create a table for this in each case and then build upon that.
                    if (i == 0)
                    {
                        dpTable[i][j] = j;
                        continue;
                    }

                    if (j == 0)
                    {
                        dpTable[i][j] = i;
                        continue;
                    }

                    // Once we've accounted for our base case, we build the rows, taking into account
                    // whether letters are equal in each case. It doesn't actually matter whether they are replaced,
                    // deleted, or inserted.
                    // NOTE: the 1 + in front of each expresion is due to the zero row we've added.
                    int previousColumn = dpTable[i][j - 1];
                    int previousRow = dpTable[i - 1][j];
                    int previousColumnAndRow = dpTable[i - 1][j - 1];

                    if (word1[i - 1] == word2[j - 1])
                    {
                        // if the letters are equal we take he minimum value of our previously calculated last steps
                        dpTable[i][j] = 1 + new[] {previousColumn, previousRow, previousColumnAndRow - 1}.Min();
                    }
                    else
                    {
                        // if the letters are not equal we take he minimum value of our previously calculated last steps plus one, indicating the need for a change.
                        dpTable[i][j] = 1 + new[] {previousColumn, previousRow, previousColumnAndRow}.Min();
                    }
                }
            }

            // it's really that simple. The top right value is our answer (that is, the smallest value we've managed to come up with after
            // traversing both words

            return dpTable.Last().Last();
        }
    }
}