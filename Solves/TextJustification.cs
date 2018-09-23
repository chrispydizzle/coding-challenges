namespace Pdrome2.Solves
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class TextJustification
    {
        private void Main(string[] args)
        {
            TextJustification a = new TextJustification();
            string[] result = a.textJustification(new[]
            {
                "This", "is", "an", "example", "of", "text", "justification."
            }, 16);
            foreach (string s in result)
            {
                Console.WriteLine($"\"{s}\"");
            }

            result = a.textJustification(new[]
            {
                "Two", "words."
            }, 11);
            foreach (string s in result)
            {
                Console.WriteLine($"\"{s}\"");
            }


            result = a.textJustification(new[]
            {
                "a",
                "b",
                "c",
                "longword"
            }, 9);
            foreach (string s in result)
            {
                Console.WriteLine($"\"{s}\"");
            }

            result = a.textJustification(new[]
            {
                "Two", "words."
            }, 9);
            foreach (string s in result)
            {
                Console.WriteLine($"\"{s}\"");
            }

            result = a.textJustification(new[]
            {
                "a"
            }, 1);
            foreach (string s in result)
            {
                Console.WriteLine($"\"{s}\"");
            }


            Console.ReadLine();
        }

        public string[] textJustification(string[] words, int l)
        {
            List<List<string>> lines = new List<List<string>>();
            List<int> freeSpaceLines = new List<int>();
            int lineLength = 0;
            List<string> line = new List<string>();
            int freeSpace;
            // go over each of the words and assign them to lines
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                freeSpace = l - lineLength;
                lineLength += word.Length;

                if (lineLength >= l && line.Count > 0)
                {
                    lineLength = word.Length;
                    lines.Add(line);
                    freeSpaceLines.Add(freeSpace);
                    line = new List<string>();
                }

                line.Add(word);

                if (lineLength != word.Length)
                {
                    lineLength++;
                }
            }

            freeSpace = l - lineLength;
            freeSpaceLines.Add(freeSpace);
            lines.Add(line);

            // determine the missing number of spaces in each line
            // if last line or only one word, append right
            // otherwise find number of "holes" (words - 1)
            // div and mod to find the correct placement (remainders should be added to the left.
            string[] output = new string[lines.Count];
            for (int i = 0; i < lines.Count; i++)
            {
                StringBuilder b = new StringBuilder();
                List<string> lineWords = lines[i];
                int extras = 0;
                if (lineWords.Count != 1)
                {
                    extras = freeSpaceLines[i] % (lineWords.Count - 1);
                }

                for (int j = 0; j < lineWords.Count; j++)
                {
                    // append word.
                    if (j == 0)
                    {
                        b.Append($"{lineWords[j]}");
                    }
                    else
                    {
                        b.Append($" {lineWords[j]}");
                    }

                    if (lineWords.Count == 1 || (i == lines.Count - 1 && j == lineWords.Count - 1))
                    {
                        if (freeSpaceLines[i] > 0)
                        {
                            b.Append(' ', freeSpaceLines[i]);
                        }
                    }
                    else if (j != lineWords.Count - 1 && i != lines.Count - 1)
                    {
                        b.Append(' ', freeSpaceLines[i] / (lineWords.Count - 1));
                        if (extras > 0)
                        {                            
                            b.Append(' ');
                            extras--;
                        }

                    }

                    // append spaces
                }

                output[i] = b.ToString();
            }

            return output;
        }
    }
}