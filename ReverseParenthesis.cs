namespace CodingChallenges
{
    using System.Text;

    public class ReverseParenthesis
    {
        public string reverseParentheses(string s)
        {
            StringBuilder b = new StringBuilder(s);
            bool reversing = false;

            // find the first close paren, and seek backwards to the associated open.
            // reverse that guy, replace it in the parent.
            // find the next close parent, seek seek backwards... so on
            int close = s.IndexOf(')');
            while (close >= 0)
            {
                int open = s.LastIndexOf('(', close);
                string swappy = s.Substring(open, (close - open + 1));
                string reversy = this.DoReverse(swappy.Substring(1, swappy.Length - 2));
                b.Replace(swappy, reversy);
                s = b.ToString();
                close = s.IndexOf(')');
            }

            return b.ToString();
        }

        string DoReverse(string target)
        {
            StringBuilder b = new StringBuilder();
            foreach (char c in target)
            {
                // this should reverse my string.
                b.Insert(0, c);
            }

            return b.ToString();
        }
    }
}