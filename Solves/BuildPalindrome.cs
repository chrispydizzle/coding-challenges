﻿namespace CodeChallenges.Solves
{
    using System;
    using System.Text;

    internal class BuildPalindrome
    {
        public string buildPalindrome(string st)
        {
            char lastChar = st[st.Length - 1];
            StringBuilder b = new StringBuilder();
            for (int i = st.Length - 2; i >= 0; i--)
            {
                char c = st[i];

                b.Append(c);

                if (c == lastChar)
                {
                    if (this.checkPalindrome(st.Substring(i)))
                    {
                        b = new StringBuilder();
                    }
                }
            }

            b.Insert(0, st);
            return b.ToString();
        }

        public bool checkPalindrome(string inputString)
        {
            int sourceLength = inputString.Length;

            int midpoint = (int) Math.Floor(sourceLength / 2d);

            string frontPart = inputString.Substring(0, midpoint);

            if (sourceLength % 2 > 0)
            {
                midpoint += 1;
            }

            string backPart = inputString.Substring(midpoint);

            //Console.WriteLine(frontPart);
            //Console.WriteLine(backPart);

            for (int i = 0; i < frontPart.Length; i++)
            {
                if (frontPart[i] != backPart[frontPart.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}