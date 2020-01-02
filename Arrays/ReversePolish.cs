namespace CodeChallenges.Arrays
{
    using System;
    using System.Collections.Generic;

    public class ReversePolish
    {
        public int EvalRPN(string[] tokens)
        {
            Stack<int> numbers = new Stack<int>();
            Dictionary<string, Func<int, int, int>> f = new Dictionary<string, Func<int, int, int>>
            {
                {"+", (i, i1) => i + i1},
                {"*", (i, i1) => i * i1},
                {"/", (i, i1) => i / i1},
                {"-", (i, i1) => i - i1}
            };

            foreach (string token in tokens)
                if (f.ContainsKey(token))
                {
                    int rightNumber = numbers.Pop();
                    int leftNumber = numbers.Pop();

                    numbers.Push(f[token](leftNumber, rightNumber));
                }
                else
                {
                    numbers.Push(int.Parse(token));
                }

            return numbers.Pop();
        }
    }
}