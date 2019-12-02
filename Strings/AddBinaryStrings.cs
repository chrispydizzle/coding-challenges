namespace CodeChallenges.Strings
{
    using System.Text;

    public class AddBinaryStrings
    {
        public string AddBinary(string a, string b)
        {
            // make both strings the same length
            int longestLength = a.Length > b.Length ? a.Length : b.Length;
            //         string result = "".PadLeft('0', longestLength + 1);

            // create a stringBuilder to build our result
            StringBuilder builder = new StringBuilder();
            a = a.PadLeft(longestLength, '0');
            b = b.PadLeft(longestLength, '0');

            int carryOver = 0;

            // go backwwards across the strings
            for (int i = longestLength - 1; i >= 0; i--)
            {
                int top = int.Parse(a[i].ToString());
                int bottom = int.Parse(b[i].ToString());

                // add the values plus any carryover
                int total = top + bottom + carryOver;

                // set carryover to 0
                carryOver = 0;

                // if value is > 1, make it carrover and convert this place to 0
                if (total > 1)
                {
                    carryOver = 1;
                    total = total - 2;
                }

                // insert the total at the left of the string

                builder.Insert(0, total);
            }

            if (carryOver > 0)
            {
                // if we have a carryOver, add another 1 to the string
                builder.Insert(0, '1');
            }

            string finalResult = builder.ToString();

            return finalResult;
        }
    }
}