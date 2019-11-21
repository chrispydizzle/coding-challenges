namespace CodeChallenges.Solves
{
    using System.Text;

    internal class AlphabeticShift
    {
        public string alphabeticShift(string inputString)
        {
            StringBuilder b = new StringBuilder();
            for (int index = 0; index < inputString.Length; index++)
            {
                char c = inputString[index];
                if (c == 'z')
                {
                    b.Append('a');
                }
                else
                {
                    b.Append(++c);
                }
            }

            return b.ToString();
        }
    }
}