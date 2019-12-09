namespace CodeChallenges.Strings
{
    public class IsStringANumber
    {
        public bool IsNumber(string s)
        {
            // kill leading and trailing spaces;0
            s = s.Trim();
            if (s.Length == 0) return false;
            // seek through the string
            bool foundDecimalPoint = false;
            bool foundPositiveNegative = false;
            bool foundExponent = false;
            bool inMainNumber = false;
            bool inExponent = false;
            for (int i = 0; i < s.Length; i++)
            {
                char current = s[i];
                if (current == '-' || current == '+')
                {
                    if (!foundPositiveNegative && (i == 0 || inExponent) && !(i == s.Length - 1))
                    {
                        foundPositiveNegative = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (char.IsDigit(current))
                {
                    if (!(inMainNumber || inExponent))
                    {
                        inMainNumber = true;
                    }
                }
                else if (current == 'e')
                {
                    if (foundExponent || !inMainNumber || i == s.Length - 1) return false;
                    foundExponent = true;
                    inExponent = true;
                    foundPositiveNegative = false;
                }
                else if (current == '.')
                {
                    if (foundDecimalPoint || inExponent) return false;
                    foundDecimalPoint = true;
                }
                else
                {
                    return false;
                }
            }

            if (foundDecimalPoint && !inMainNumber)
            {
                return false;
            }

            return true;
            // number can contain leading spaces
            // exponents represented by e, and cannot be decimals
            // numbers cannot have more than one positivity modifier
        }
    }
}