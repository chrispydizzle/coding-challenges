namespace Pdrome2
{
    using System.Linq;
    using System.Text;

    internal class LongestDigitPrefix
    {
        public string longestDigitsPrefix(string inputString) {
            char[] numChars = new char[] {'1','2','3','4','5','6','7','8','9','0' };
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < inputString.Length; i++)
            {
                char c = inputString[i];
                if (i == 0 && !numChars.Contains(c))
                {
                    return string.Empty;
                }

                if (numChars.Contains(inputString[i]))
                {
                    result.Append(inputString[i]);
                }
                else
                {
                    return result.ToString();
                }
            }

            return result.ToString();
        }
    }
}