namespace Pdrome2.Solves
{
    using System.Linq;

    internal class FirstDigit
    {
        public char firstDigit(string inputString) {
            char[] numChars = new char[] {'1','2','3','4','5','6','7','8','9','0' };
            foreach (char c in inputString)
            {
                if (numChars.Contains(c))
                {
                    return c;
                }
            }

            return '\0';
        }

    }
}