namespace Pdrome2
{
    using System.Linq;

    internal class DoReverseString
    {
        public string ReverseString(string s) {
            // go through each char in the string, to the halfway point. 
            if(s.Length == 0) return string.Empty;
            char[] cArr = new char[s.Length];
            for(int i = 0; i <= s.Length /2 ; i++){ // len / 2 will ensure I don't have to worry about odd numbers
                // get the char I'm at, 
                char l = s[i];
                // and the get char on the opposite end (len - i)
                int rPos = s.Length - i - 1;
                char r = s[rPos];
                // do the swap 
                cArr[i] = r;
                cArr[rPos] = l;
            }
        
            return new string(cArr);
        }
    }
}