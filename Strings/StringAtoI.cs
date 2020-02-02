namespace CodeChallenges.Strings
{
    public class StringAtoI
    {
        public int MyAtoi(string str)
        {
            int index = 0, sign = 1, total = 0;

            //1. Remove spaces
            while (index < str.Length && str[index] == ' ') index++;

            //2. Get sign
            sign = index < str.Length && (str[index] == '+' || str[index] == '-') ? str[index++] == '+' ? 1 : -1 : 1;

            //3. Calculate it and take care of overflow
            while (index < str.Length)
            {
                int digit = str[index++] - '0';
                if (digit < 0 || 9 < digit) break;

                if (int.MaxValue / 10 < total || int.MaxValue / 10 == total && int.MaxValue % 10 < digit)
                {
                    return sign == -1 ? int.MinValue : int.MaxValue;
                }

                total = total * 10 + digit;
            }

            return total * sign;
        }
    }
}