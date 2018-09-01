namespace Pdrome2
{
    using System.Text;

    internal class FindEmailDomain
    {
        public string findEmailDomain(string address) {
            StringBuilder b= new StringBuilder();
            bool trig = false;
            foreach (char c in address)
            {
                if (trig)
                {
                    b.Append(c);
                }
                
                if (c == '@')
                {
                    b = new StringBuilder();
                    trig = true;
                }
            }

            return b.ToString();
        }
 
    }
}