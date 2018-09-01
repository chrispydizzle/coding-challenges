namespace Pdrome2
{
    using System.Collections.Generic;
    using System.Linq;

    public class ReversePolishNotation
    {
        public int EvalRPN(string[] tokens)
        {
            string[] operators = new[] {"+", "-", "/", "*"};
            Stack<string> pnStack = new Stack<string>();
            foreach (string token in tokens)
            {
                if (!operators.Contains(token))
                {
                    pnStack.Push(token);
                }
                else
                {
                    int right = int.Parse(pnStack.Pop());
                    int left = int.Parse(pnStack.Pop());
                    int stackVal = 0;
                    
                    switch (token)
                    {
                        case "+":
                            stackVal = left + right;
                            break;
                        case "-":
                            stackVal = left - right;
                            break;
                        case "*":
                            stackVal = left * right;
                            break;
                        case "/":
                            stackVal = left / right;
                            break;
                    }
                    pnStack.Push(stackVal.ToString());
                }
            }

            return int.Parse(pnStack.Pop());
        }
    }
}