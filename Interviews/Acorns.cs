namespace CodeChallenges.Interviews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BinaryTrees;

    public class Acorns
    {
        public string GetPreorderByRecursion(TreeNode node)
        {
            StringBuilder b = new StringBuilder();
            GetPreorderByRecursion(node, b);
            return b.ToString();
        }

        private void GetPreorderByRecursion(TreeNode node, StringBuilder builder)
        {
            if (node == null) return;

            builder.Append($"{node.val}, ");

            GetPreorderByRecursion(node.left, builder);

            GetPreorderByRecursion(node.right, builder);


            StringBuilder b = new StringBuilder();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(node);

            while (stack.Any())
            {
                // traverse node left
                TreeNode n = stack.Pop();

                b.Append($"{n.val}, ");

                if (n.right != null) stack.Push(n.right);

                if (n.left != null) stack.Push(n.left);
            }
        }

        public class ZeroSum
        {
            // Given an array of n numbers, return true if any unique combination of these numbers equals k
            public bool HasValidCombo(int[] nums, int target)
            {
                HashSet<int> usedNums = new HashSet<int>();
                if (nums.Contains(0)) return true;

                int currentNum = nums[0];
                usedNums.Add(nums[0]);

                for (int j = 1; j < nums.Length - 1; j++)
                {
                    HashSet<int> tempSet = new HashSet<int>();
                    int nextNum = nums[j];
                    foreach (int usedNum in usedNums)
                    {
                        int newSum = usedNum + nextNum;
                        if (newSum == 0) return true;

                        int difference = target - newSum;
                        if (usedNums.Contains(difference)) return true;

                        tempSet.Add(newSum);
                    }

                    usedNums.Add(nextNum);
                    usedNums.UnionWith(tempSet);
                    tempSet.Clear();
                }

                usedNums.Add(currentNum);


                return false;
            }
        }

        public class TicTacToe
        {
            private readonly int[][] b;
            private readonly Dictionary<int, HashSet<int>> colElig = new Dictionary<int, HashSet<int>>();
            private readonly int n;
            private readonly Dictionary<int, HashSet<int>> rowElig = new Dictionary<int, HashSet<int>>();
            private int moves;

            public TicTacToe(int n)
            {
                this.n = n;

                // build our gameboard.
                b = new int[n][];
                for (int index = 0; index < b.Length; index++)
                {
                    b[index] = new int[n];
                    rowElig.Add(n, new HashSet<int>());
                    colElig.Add(n, new HashSet<int>());
                }
            }

            /**
             * Player {player} makes a move at ({row}, {col}).
             * @param row The row of the board.
             * @param col The column of the board.
             * @param player The player, can be either 1 or 2.
             * @return The current winning condition, can be either:
             * 0: No one wins.
             * 1: Player 1 wins.
             * 2: Player 2 wins.
             */
            public int Move(int row, int col, int player)
            {
                // no validation required
                b[row][col] = player;

                rowElig[row].Add(player);
                colElig[col].Add(player);

                moves++;

                // draw
                foreach (int[] brow in b)
                {
                    for (int i = 0; i < n - 1; i++) Console.Write($"{brow[i]}|");

                    Console.WriteLine($"{brow[n - 1]}");
                }

                // have we made enough moves to validate?
                if (moves < n) return 0;

                int t = 0;

                // is the row eligible for a win?
                if (rowElig[row].Contains(player) && rowElig[row].Count == 1)
                    // check row
                    for (int i = 0; i < n; i++)
                        if (b[row][i] == player)
                            t++;

                if (t == n) return player;

                // check col
                t = 0;
                if (colElig[col].Contains(player) && colElig[col].Count == 1)
                    for (int i = 0; i < n; i++)
                        if (b[i][col] == player)
                            t++;

                if (t == n) return player;

                // check diag ltr ( player can only win two ways diagonal)
                t = 0;
                for (int i = 0; i < n; i++)
                    if (b[i][i] == player)
                        t++;

                if (t == n) return player;

                // check diag rtl ( player can only win two ways diagonal)
                t = 0;
                for (int i = 0; i < n; i++)
                    if (b[i][n - i - 1] == player)
                        t++;


                if (t == n) return player;

                return 0;
            }
        }
    }
}