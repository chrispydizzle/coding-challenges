namespace Pdrome2
{
    using System.Text;

    public class Atoi
    {
        public int MyAtoi(string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;

            // trim whitespace 
            string noLeadingSpace = str.Trim();

            int max = int.MaxValue;
            string maxValString = max.ToString();
            // char[] validNums = new {'0','1','2','3','4','5','6','7','8','9' };

            if (string.IsNullOrEmpty(noLeadingSpace)) return 0;

            // check if first character is a negation sign.
            bool negate = noLeadingSpace[0] == '-';
            if (negate)
            {
                noLeadingSpace = noLeadingSpace.Substring(1);
                max = int.MinValue;
                maxValString = max.ToString().Substring(1);
            }

            if (string.IsNullOrEmpty(noLeadingSpace)) return 0;

            // check if first character is a plus sign
            if (noLeadingSpace[0] == '+')
            {
                if (negate) return 0;

                noLeadingSpace = noLeadingSpace.Substring(1);
            }

            if (string.IsNullOrEmpty(noLeadingSpace)) return 0;

            // check if next character is numeric
            if (!char.IsDigit(noLeadingSpace[0])) return 0;

            // check for leading zeroes
            while (noLeadingSpace[0] == '0' && noLeadingSpace.Length > 1)
            {
                noLeadingSpace = noLeadingSpace.Substring(1);
            }

            // check if next character is numeric
            if (!char.IsDigit(noLeadingSpace[0])) return 0;

            // now we're ready to do our work
            StringBuilder sb = new StringBuilder();
            // loop through each character
            foreach (char next in noLeadingSpace)
            {
                if (char.IsDigit(next)) // and the next character is a number
                {
                    sb.Append(next); // add it to the string
                }
                else
                {
                    break;
                }

                if (sb.Length > maxValString.Length) // the current appended string length is greater than  maxValString's length
                {
                    return negate ? int.MinValue : int.MaxValue;
                }
            }

            string resultString = string.Empty;
            // if string length is less than maxvalstring, parse and set
            if (sb.Length < maxValString.Length)
            {
                resultString = sb.ToString();
            }
            else
            {
                // edge case is if the strings are equal length, then we need to validate char by char
                string returnString = sb.ToString();

                for (int i = 0; i < returnString.Length; i++)
                {
                    int mChar = int.Parse(maxValString[i].ToString());
                    int rChar = int.Parse(returnString[i].ToString());
                    if (rChar > mChar) return negate ? int.MinValue : int.MaxValue;

                    if (rChar < mChar)
                    {
                        break;
                    }
                }

                resultString = returnString;
            }

            if (negate) resultString = $"-{resultString}";
            return int.Parse(resultString);
        }
    }
}