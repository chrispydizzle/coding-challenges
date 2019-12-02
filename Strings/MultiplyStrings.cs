namespace CodeChallenges.Strings
{
    public class MultiplyStrings
    {
        public string Multiply(string num1, string num2)
        {
            // constraints state the length of num1 & 2 < 110, so pad a string with 220 zeroes
            string result = "0".PadLeft(220, '0');

            // traverse num1 from right
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(num1[i].ToString());

                // account for current placement 
                int place = num1.Length - 1 - i;

                // init carryover
                int carryOver = 0;

                // traverse num2 from right
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    //account for current placement
                    place += num2.Length - 1 - j;

                    int otherDigit = int.Parse(num2[j].ToString());

                    // get the product                
                    int product = digit * otherDigit;

                    // add carryover
                    product += carryOver;

                    // get the substring of our result that's relevant to this product
                    int targetStart = result.Length - 1 - (num1.Length - 1 - i + num2.Length - 1 - j);
                    string targetString = result.Substring(targetStart, 1);

                    // convert that substring to an int, and add it to our product
                    int resultValue = int.Parse(targetString);
                    product += resultValue;

                    int tens = product / 10;
                    int remainder = product % 10;

                    // set carryover
                    carryOver = tens;

                    // convert result to string
                    // set remainder to the target string
                    result = result.Remove(targetStart, 1);
                    result = result.Insert(targetStart, remainder.ToString()[0].ToString());
                }

                // handle carryover if the last digit has one
                if (carryOver > 0)
                {
                    // go a place higher than we could have gone during the loop
                    int highestPlace = result.Length - 1 - (num1.Length - 1 - i + num2.Length - 1) - 1;

                    // snatch the value, add carryover
                    string targetString = result.Substring(highestPlace, 1);
                    int resultValue = int.Parse(targetString);
                    resultValue += carryOver;

                    // swap it
                    result = result.Remove(highestPlace, 1);
                    result = result.Insert(highestPlace, resultValue.ToString()[0].ToString());
                }
            }

            string finalResult = result.TrimStart('0');
            if (finalResult == string.Empty)
            {
                finalResult = "0";
            }

            return finalResult;
        }
    }
}