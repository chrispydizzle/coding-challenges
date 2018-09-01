namespace Pdrome2.Solves
{
    using System.Text;

    internal class RoadSignsTruncd
    {
        public string roadSigns(string[] sign)
        {
            string[][] s = new string[sign.Length][];
            int m = 0;
            for (int i = 0; i < sign.Length; i++)
            {
                s[i] = sign[i].ToLower().Split(' ');
                if (s[i].Length > m)
                {
                    m = s[i].Length;
                }
            }

            StringBuilder b = new StringBuilder();
            int c = 0;
            bool S = true;

            while (c < m)
            {
                foreach (string[] r in s)
                {
                    if (c >= r.Length) continue;

                    string w = r[c];
                    if (S)
                    {
                        char f = char.ToUpper(w[0]);
                        w = $"{f}{w.Substring(1)}";
                        S = false;
                    }

                    char l = w[w.Length - 1];
                    if (l == '!' || l == '.' || l == '?')
                    {
                        S = true;
                    }

                    if (w.Length == 1 && S)
                    {
                        b.Append($"{w}");
                    }
                    else
                    {
                        b.Append($" {w}");
                    }
                }

                c++;
            }

            return b.ToString().Trim();
        }
    }
}