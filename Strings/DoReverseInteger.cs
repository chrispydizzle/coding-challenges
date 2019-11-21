namespace CodeChallenges.Strings
{
    using System;
    using System.Linq;

    internal class DoReverseInteger
    {
        public int Reverse(int x)
        {
            // note int.MaxValue
            string overFlowTarget = int.MaxValue.ToString();
            int overFlowTargetLength = overFlowTarget.Length;

            // get absolute value and note that if it differs from the original I'll need to negate it later.
            if (x == int.MinValue) return 0;

            int raw = Math.Abs(x);
            bool isNegative = false;
            if (raw != x)
            {
                isNegative = true;
                overFlowTarget = int.MinValue.ToString().Substring(1);
            }

            // convert x to a string
            string sInt = raw.ToString();

            // reverse the string
            string srInt = new string(sInt.Reverse().ToArray());

            // check for a string length that exceeds length of max, then return 0
            int maxStringLength = overFlowTargetLength;
            if (srInt.Length > overFlowTargetLength)
            {
                return 0;
            }

            int result = 0;

            if (srInt.Length == maxStringLength)
            {
                // if the string length equals the length of max, we need to check each digit and return zero if any internal digit is higher than it's associated digit in int maxvalue
                for (int i = 0; i < maxStringLength; i++)
                {
                    int rev = int.Parse(srInt[i].ToString());
                    int max = int.Parse(overFlowTarget[i].ToString());
                    // Console.WriteLine($"rev:{rev} max:{max}");                
                    if (rev < max) break;
                    if (rev > max) return 0; // if so, return 0
                }
            }

            result = int.Parse(srInt); // we've made it this far, it's not an overflow so set the result to the parsed value;

            // negate if necessary
            if (isNegative)
            {
                result *= -1;
            }

            return result;
        }
    }
}