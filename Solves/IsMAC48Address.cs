namespace Pdrome2
{
    using System;
    using System.Linq;

    internal class IsMAC48Address
    {
        public bool isMAC48Address(string inputString)
        {
            // 48-57, 65-70
            char[] macChars = new char[] {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'A', 'B', 'C', 'D', 'E', 'F'};
            string[] sets = inputString.Split(new[] {"-"}, StringSplitOptions.None);
            if (sets.Length != 6) return false;

            foreach (string s in sets)
            {
                if (s.Length != 2) return false;
                for (int i = 0; i < s.Length; i++)
                {
                    char c = s[i];
                    if (!macChars.Contains(c))
                        //if (!(('0' <= c && '9' >= c) || ('A' <= c && 'F' >= c)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}