namespace CodeChallenges.Strings
{
    public class ValidPalindrome2
    { 
        public bool ValidPalindrome(string s)
        {
            if (s == string.Empty) return true;

            int leftPointer = 0;
            int rightPointer = s.Length - 1;
            bool proceed = true;

            bool didLeftDelete = false;
            bool didRightDelete = false;
            int leftPointerOnDelete = 0;
            int rightPointerOnDelete = 0;
            char deletedChar = char.MinValue;
            bool resetting = false;

            while (leftPointer < rightPointer && proceed)
            {
                if (rightPointer < leftPointer) return true;

                char left = s[leftPointer];
                char right = s[rightPointer];

                if (left != right)
                {
                    if (didLeftDelete && didRightDelete)
                    {
                        return false;
                    }

                    if (!resetting)
                    {
                        if (didLeftDelete)
                        {
                            s = s.Insert(leftPointerOnDelete, deletedChar.ToString());
                        }

                        if (didRightDelete)
                        {
                            s = s.Insert(rightPointerOnDelete, deletedChar.ToString());
                        }

                        if (didLeftDelete || didRightDelete)
                        {
                            leftPointer = leftPointerOnDelete;
                            rightPointer = rightPointerOnDelete;
                            resetting = true;
                            continue;
                        }
                    }

                    char spareLeft = s[leftPointer + 1];

                    char spareRight = char.MinValue;

                    if (rightPointer > 0 && rightPointer < s.Length)
                    {
                        spareRight = s[rightPointer - 1];
                    }

                    if (left == spareRight && !didRightDelete)
                    {
                        deletedChar = s[rightPointer];
                        leftPointerOnDelete = leftPointer;
                        rightPointerOnDelete = rightPointer;
                        s = s.Remove(rightPointer, 1);
                        rightPointer--;
                        didRightDelete = true;
                    }
                    else if (right == spareLeft && !didLeftDelete)
                    {
                        deletedChar = s[leftPointer];
                        leftPointerOnDelete = leftPointer;
                        rightPointerOnDelete = rightPointer;
                        s = s.Remove(leftPointer, 1);
                        rightPointer--;
                        didLeftDelete = true;
                    }
                    else
                    {
                        return false;
                    }
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