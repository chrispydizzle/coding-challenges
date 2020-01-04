namespace CodeChallenges.Interviews
{
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
            /**
             * Initialize your data structure here.
             */
            public TicTacToe(int n)
            {
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
                return 0;
            }
        }
    }
}