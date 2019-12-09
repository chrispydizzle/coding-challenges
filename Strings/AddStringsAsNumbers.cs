namespace CodeChallenges.Strings
{
    public class AddStringsAsNumbers
    {
        public string AddStrings(string num1, string num2)
        {
            int maxLength = num1.Length > num2.Length ? num1.Length + 1 : num2.Length;
            num1 = num1.PadLeft(maxLength + 1, '0');
            num2 = num2.PadLeft(maxLength + 1, '0');

            string result = new string('0', maxLength + 1);
            int carryover = 0;
            for (int i = maxLength; i >= 0; i--)
            {
                int top = int.Parse(num1[i].ToString());
                int bottom = int.Parse(num2[i].ToString());
                int currentTotal = top + bottom + carryover;
                if (currentTotal == 0)
                {
                    continue;
                }

                carryover = currentTotal / 10;
                int numberResult = currentTotal % 10;
                result = result.Remove(i, 1);
                result = result.Insert(i, numberResult.ToString()[0].ToString());
            }

            result = result.TrimStart('0');

            if (result.Length == 0)
            {
                result = "0";
            }

            return result;
        }
    }
}