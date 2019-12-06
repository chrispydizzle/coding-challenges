namespace CodeChallenges.Strings
{
    using System.Text;

    public class IntegerToEnglish
    {
        // int.MaxValue is 2,147,483,647

        public string NumberToWords(int num)
        {
            StringBuilder builder = new StringBuilder();
            if (num == 0) return "Zero";

            int billions = num / 1000000000;

            if (billions > 0)
            {
                builder.Append(this.MapOneThroughNineteen(billions));
                builder.Append(" " + "Billion");
            }

            int toReduce = num % 1000000000;

            int millions = toReduce / 1000000;

            if (millions > 0)
            {
                builder.Append(this.MapHundreds(millions) + " Million");
            }

            toReduce = toReduce % 1000000;

            int thousands = toReduce / 1000;

            if (thousands > 0)
            {
                builder.Append(this.MapHundreds(thousands) + " Thousand");
            }

            toReduce = toReduce % 1000;

            builder.Append(this.MapHundreds(toReduce));

            return builder.ToString().Trim();
        }

        public string MapHundreds(int num)
        {
            StringBuilder b = new StringBuilder();

            int hundreds = num / 100;
            if (hundreds > 0)
            {
                b.Append(" " + this.MapOneThroughNineteen(hundreds) + " Hundred");
            }

            int remains = num % 100;

            int tens = remains / 10;

            if (remains > 0)
            {
                if (tens <= 1)
                {
                    b.Append(" " + this.MapOneThroughNineteen(remains));
                    return b.ToString();
                }

                b.Append(" " + this.MapTens(tens));
            }

            remains = remains % 10;

            if (remains > 0)
            {
                b.Append(" " + this.MapOneThroughNineteen(remains));
            }

            return b.ToString();
        }

        public string MapTens(int num)
        {
            if (num == 2) return "Twenty";
            if (num == 3) return "Thirty";
            if (num == 4) return "Forty";
            if (num == 5) return "Fifty";
            if (num == 6) return "Sixty";
            if (num == 7) return "Seventy";
            if (num == 8) return "Eighty";
            if (num == 9) return "Ninety";
            return string.Empty;
        }

        public string MapOneThroughNineteen(int num)
        {
            if (num == 1) return "One";
            if (num == 2) return "Two";
            if (num == 3) return "Three";
            if (num == 4) return "Four";
            if (num == 5) return "Five";
            if (num == 6) return "Six";
            if (num == 7) return "Seven";
            if (num == 8) return "Eight";
            if (num == 9) return "Nine";
            if (num == 10) return "Ten";
            if (num == 11) return "Eleven";
            if (num == 12) return "Twelve";
            if (num == 13) return "Thirteen";
            if (num == 14) return "Fourteen";
            if (num == 15) return "Fifteen";
            if (num == 16) return "Sixteen";
            if (num == 17) return "Seventeen";
            if (num == 18) return "Eighteen";
            if (num == 19) return "Nineteen";
            return string.Empty;
        }
    }
}