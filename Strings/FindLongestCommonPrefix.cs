namespace CodeChallenges.Strings
{
    using System.Text;

    public class FindLongestCommonPrefix
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return string.Empty;
            if (strs.Length == 1) return strs[0];

            string rString = strs[0]; // take the top string as a reference point
            StringBuilder b = new StringBuilder(); // init a stringbuilder to empty string

            for (int j = 0; j < rString.Length; j++)
            {
                // loop through each character in the reference string                
                char tChar = rString[j];

                // iterate through remaining strings
                for (int i = 1; i < strs.Length; i++)
                {
                    if (j > strs[i].Length - 1 // the index must not be beyond the check string length
                        || strs[i][j] != tChar) // a match at that index
                    {
                        return b.ToString();
                    } // if any reference strings fail to match return stringbuilder contents
                }

                b.Append(tChar); // if all reference strings match, add current index to builder                
            }

            return b.ToString();
        }
    }
}