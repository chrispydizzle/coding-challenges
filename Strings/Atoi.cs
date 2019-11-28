namespace CodeChallenges.Strings
{
    using System.Collections.Generic;
    using System.Text;

    public class Atoi
    {
        public int MyAtoiImproved(string str)
        {
            int startPos = 0;

            HashSet<char> modifiers = new HashSet<char>();
            modifiers.Add('-');
            modifiers.Add('+');

            // roll through the string, bypassing whitespace
            for (int i = 0; i < str.Length; i++)
            {
                char currentChar = str[i];
                // continue forward on space char.
                if (currentChar == ' ') continue;
                // reject if next char is not valid
                if (char.IsDigit(currentChar) || modifiers.Contains(currentChar))
                {
                    // set startPos and break
                    startPos = i;
                    break;
                }

                // return zero for an invalid input
                return 0;
            }

            StringBuilder builder = new StringBuilder();
            for (int i = startPos; i < str.Length; i++)
            {
                char currChar = str[i];

                // specialCase start pos to handle + or -
                if (i == startPos && (currChar == '-' || currChar == '+'))
                {
                    if (currChar == '-') builder.Append('-');
                    continue;
                }

                // make sure next char is valid- if not, break out.
                if (!char.IsDigit(currChar))
                {
                    break;
                }

                // otherwise, append to builder
                builder.Append(currChar);
            }

            string result = builder.ToString();

            if (int.TryParse(result, out int returnValue)) return returnValue;

            if (result == "+" || result == "-" || result == string.Empty)
            {
                return 0;
            }

            returnValue = result[0] == '-' ? int.MinValue : int.MaxValue;

            return returnValue;
        }

        public int MyAtoi(string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;

            // trim whitespace 
            string noLeadingSpace = str.Trim();

            int max = int.MaxValue;
            string maxValString = max.ToString();

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

            string resultString;
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