namespace CodeChallenges.Strings
{
    using System.Collections.Generic;

    public class ReverseOnlyLters
    {
        public string ReverseOnlyLetters(string S)
        {
            string s = S;
            Stack<char> cStack = new Stack<char>();
            foreach (char c in s)
            {
                if (char.IsLetter(c))
                {
                    cStack.Push(c);
                }
            }

            for (int i = 0; i < S.Length; i++)
            {
                if (!char.IsLetter(S[i])) continue;

                char sp = cStack.Pop();
                S = S.Insert(i, sp.ToString());
                S = S.Remove(i + 1, 1);
            }

            return S;
        }
    }
}