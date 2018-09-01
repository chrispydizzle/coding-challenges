namespace Pdrome2
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class LineEncoding
    {
        public string lineEncoding(string s)
        {
            StringBuilder b = new StringBuilder();
            char lastChar = char.MinValue;
            int charCounter = 0;

            List<char> chars = s.ToCharArray().ToList();
            while (chars.Count > 0)
            {
                int cCounter = 0;
                char cChar = chars[0];
                while (chars.Count > 0 && chars[0] == cChar)
                {
                    cCounter++;
                    chars.RemoveAt(0);
                }

                if (cCounter > 1)
                {
                    b.Append($"{cCounter}{cChar}");
                }
                else
                {
                    b.Append($"{cChar}");
                }
            }

            return b.ToString();
        }
    }
}