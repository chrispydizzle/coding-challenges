namespace CodeChallenges.Strings
{
    using System.Collections.Generic;

    public class RomanToInteger
    {
        public int RomanToInt(string s)
        {
            // failsafe
            if (s.Length == 0) return 0;

            // build a table of roman numerals and thier integer values.
            Dictionary<char, int> vals = new Dictionary<char, int>() { };
            vals.Add('I', 1);
            vals.Add('V', 5);
            vals.Add('X', 10);
            vals.Add('L', 50);
            vals.Add('C', 100);
            vals.Add('D', 500);
            vals.Add('M', 1000);

            /*
            Subraction rules : 
                I can be placed before V (5) and X (10) to make 4 and 9. 
                X can be placed before L (50) and C (100) to make 40 and 90. 
                C can be placed before D (500) and M (1000) to make 400 and 900.
            */

            int result = 0;

            // loop through the string
            for (int i = 0; i < s.Length; i++)
            {
                char currChar = s[i];
                // if current value is at end of string, simply add it.
                if (i == s.Length - 1)
                {
                    result += vals[currChar];
                    break;
                }

                char nextChar = s[i + 1];
                bool doSubtractive = false;

                if (currChar == 'C')
                {
                    // for C's
                    // check if next value is a D or M
                    if (nextChar == 'D' || nextChar == 'M')
                    {
                        // if so, boost the loop position, and add the subtractive value to the total        
                        doSubtractive = true;
                    }
                }
                else if (currChar == 'X')
                {
                    // for X's
                    // check if next value is an L or C
                    if (nextChar == 'L' || nextChar == 'C')
                    {
                        // if so, boost the loop position, and add the subtractive value to the total        
                        doSubtractive = true;
                    }
                }
                else if (currChar == 'I')
                {
                    // for I's
                    // check if next value is a V or X
                    if (nextChar == 'V' || nextChar == 'X')
                    {
                        // if so, boost the loop position, and add the subtractive value to the total        
                        doSubtractive = true;
                    }
                }

                if (doSubtractive)
                {
                    i++;
                    result += (vals[nextChar] - vals[currChar]);
                }
                else
                {
                    // finally, just add the value if it doesnt meet above criteria
                    result += vals[currChar];
                }
            }

            return result;
        }
    }
}