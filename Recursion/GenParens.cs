namespace CodeChallenges.Recursion
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GenParens
    {
        public List<String> GenerateParenthesis(int n)
        {
            List<String> res = new List<string>();
            if (n <= 0)
            {
                return res;
            }

            StringBuilder curr = new StringBuilder();
            backTracking(n, n, res, curr);
            return res;
        }

        private void backTracking(int left, int right, List<String> res, StringBuilder curr)
        {
            if (left == 0 && right == 0)
            {
                res.Add(curr.ToString());
                return;
            }

            if (left > 0)
            {
                curr.Append("(");
                backTracking(left - 1, right, res, curr);
                curr.Remove(curr.Length - 1, 1);
            }

            if (right > left)
            {
                curr.Append(")");
                backTracking(left, right - 1, res, curr);
                curr.Remove(curr.Length - 1, 1);
            }
        }
    }
}