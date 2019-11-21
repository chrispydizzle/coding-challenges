namespace CodeChallenges.Solves
{
    using System.Text;

    internal class RoadSignsLong
    {
        public string roadSigns(string[] sign)
        {
            // split string and normalize it to lowercase. The goal is to be able to traverse the strings vertically popping off the leftmost word until none are left.
            // We also need to capitalize every word following sentence-ending punctuation.
            string[][] splits = new string[sign.Length][];
            int maxLength = 0;
            for (int i = 0; i < sign.Length; i++)
            {
                splits[i] = sign[i].ToLower().Split(' ');
                if (splits[i].Length > maxLength)
                {
                    maxLength = splits[i].Length;
                }
            }

            StringBuilder b = new StringBuilder();

            int column = 0;
            bool startingSentence = true;

            while (column < maxLength)
            {
                for (int i = 0; i < splits.Length; i++)
                {
                    string[] row = splits[i];
                    if (column >= splits[i].Length) continue;

                    string word = row[column];
                    if (startingSentence)
                    {
                        char firstChar = char.ToUpper(word[0]);
                        word = $"{firstChar}{word.Substring(1)}";
                        startingSentence = false;
                    }

                    char lastChar = word[word.Length - 1];
                    if (lastChar == '!' || lastChar == '.' || lastChar == '?')
                    {
                        startingSentence = true;
                    }

                    if (word.Length == 1 && startingSentence)
                    {
                        b.Append($"{word}");
                    }
                    else
                    {
                        b.Append($" {word}");
                    }
                }

                column++;
            }

            return b.ToString().Trim();
        }
    }
}