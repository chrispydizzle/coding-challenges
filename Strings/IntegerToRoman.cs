namespace CodeChallenges.Strings
{
    using System.Text;

    public class IntegerToRoman
    {
        public string IntToRoman(int num)
        {
            StringBuilder b = new StringBuilder();
            int thous = num / 1000;
            int rem = num % 1000;
            b.Append('M', thous);

            // here we need to check
            int hun = rem / 100;
            rem = rem % 100;

            if (hun == 9)
            {
                b.Append("CM");
                hun = 0;
            }
            else if (hun >= 5)
            {
                b.Append("D");
                hun -= 5;
            }

            if (hun == 4)
            {
                b.Append("CD");
            }
            else if (hun > 0)
            {
                b.Append('C', hun);
            }


            int tens = rem / 10;
            rem = rem % 10;

            if (tens == 9)
            {
                b.Append("XC");
                tens = 0;
            }
            else if (tens >= 5)
            {
                b.Append("L");
                tens -= 5;
            }

            if (tens == 4)
            {
                b.Append("XL");
            }
            else if (tens > 0)
            {
                b.Append('X', tens);
            }

            if (rem == 9)
            {
                b.Append("IX");
                rem = 0;
            }
            else if (rem >= 5)
            {
                rem -= 5;
                b.Append("V");
            }

            if (rem == 4)
            {
                b.Append("IV");
            }
            else if (rem > 0)
            {
                b.Append('I', rem);
            }

            return b.ToString();
        }
    }
}