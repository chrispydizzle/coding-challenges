namespace CodingChallenges
{
    using System;
    using System.Text;

    internal class AddBorder
    {
        public string[] addBorder(string[] picture)
        {
            StringBuilder b = new StringBuilder();
            int width = picture[0].Length + 2;
            b.AppendLine(new string('*', width));
            foreach (string s in picture)
            {
                b.AppendLine($"*{s}*");
            }
            b.AppendLine(new string('*', width));
            return b.ToString().Split(new []{"\n"}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}