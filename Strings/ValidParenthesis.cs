namespace CodeChallenges.Strings
{
    using System.Collections.Generic;
    using System.Linq;

    public class ValidParenthesis
    {
        public bool IsValid(string s)
        {
            bool valid = true;
            var opens = new Stack<char>();
            foreach (char t in s)
            {
                switch (t)
                {
                    case ')':
                        valid = DoCheck(opens, '(');
                        break;
                    case '}':
                        valid = DoCheck(opens, '{');
                        break;
                    case ']':
                        valid = DoCheck(opens, '[');
                        break;
                    default:
                        opens.Push(t);
                        break;
                }

                if (!valid) break;
            }

            if (opens.Any()) valid = false;

            return valid;
        }

        public bool DoCheck(Stack<char> chars, char target)
        {
            if (chars.Count == 0) return false;

            char current = chars.Pop();
            if (current != target) return false;
            return true;
        }
    }
}