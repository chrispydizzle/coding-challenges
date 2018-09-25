namespace Pdrome2
{
    using System.Text.RegularExpressions;

    public class DetectPalindrome
    {
        public bool IsPalindrome(string s) {
            if(string.IsNullOrEmpty(s) || s.Length == 1) return true;
            // cleanup - strip spaces, punctuation and lcase the string
            Regex rgx = new Regex("[^a-zA-Z0-9]");
            string clean = rgx.Replace(s, string.Empty).ToLower();
        
            if(string.IsNullOrEmpty(clean) || clean.Length == 1) return true;
        
            // loop through the string from the left, stopping at length / 2.
            for(int i =0; i < clean.Length / 2; i++){
                // compare the character values 
                char testChar = clean[i];
                char targetChar = clean[clean.Length - 1 - i];
                // Console.WriteLine($"test:{testChar} target:{targetChar} i:{i}");
                if(testChar != targetChar) return false;
            }
        
            return true;
        }
    }
}