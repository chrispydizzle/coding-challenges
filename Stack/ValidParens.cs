namespace CodeChallenges.Stack
{
    using System.Collections.Generic;
    using System.Linq;

    public class ValidParens
    {
        private readonly List<char> parenStack = new List<char>();

        public bool IsValid(string s)
        {
            char oP = '(';
            char cP = ')';
            char oC = '{';
            char cC = '}';
            char oB = '[';
            char cB = ']';

            char[] spChars = {oP, cP, oC, cC, oB, cB};
            char[] opChars = {oP, oB, oC};
            foreach (char c in s)
            {
                if (!spChars.Contains(c)) continue;

                if (opChars.Contains(c))
                {
                    this.parenStack.Add(c);
                }
                else
                {
                    if (this.parenStack.Count == 0) return false;
                    char lastOpen = this.parenStack[this.parenStack.Count - 1];
                    if (lastOpen == oP && c != cP) return false;
                    if (lastOpen == oC && c != cC) return false;
                    if (lastOpen == oB && c != cB) return false;

                    this.parenStack.RemoveAt(this.parenStack.Count - 1);
                }
            }

            if (this.parenStack.Any()) return false;

            return true;
        }
    }
}