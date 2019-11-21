﻿namespace CodeChallenges.Solves
{
    using System;

    public class PalindromeChecker
    {
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