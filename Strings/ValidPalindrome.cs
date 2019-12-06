namespace CodeChallenges.Strings
{
    public class ValidPalindrome
    {
        public bool IsPalindrome(string s)
        {
            if (s == string.Empty) return true;

            int leftPointer = 0;
            int rightPointer = s.Length - 1;
            bool proceed = true;
            while (leftPointer < rightPointer && proceed)
            {
                while (!char.IsLetterOrDigit(s[leftPointer]))
                {
                    leftPointer++;
                    if (leftPointer > s.Length - 1) return true;
                }

                char leftChar = char.ToLower(s[leftPointer]);

                while (rightPointer > leftPointer && !char.IsLetterOrDigit(s[rightPointer]))
                {
                    rightPointer--;
                }

                if (rightPointer < leftPointer) return true;

                char rightChar = char.ToLower(s[rightPointer]);

                if (rightChar != leftChar)
                {
                    return false;
                }
                else
                {
                    leftPointer++;
                    rightPointer--;
                }

            }

            return proceed;
        }
    }
}