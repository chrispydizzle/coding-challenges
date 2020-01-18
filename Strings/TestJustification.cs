namespace CodeChallenges.Strings
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TestJustification
    {
        //TODO:  it ain't pretty... and def not optimal, but it works.
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            List<string> result = new List<string>();

            Queue<string> currentLine = new Queue<string>();

            Queue<string> q = new Queue<string>(words);
            int lineLength = 0;
            while (q.Any())
            {
                // first, allocate words to the current line
                string currentString = q.Dequeue();
                if (currentLine.Count > 0)
                {
                    currentString = $" {currentString}";
                }

                lineLength += currentString.Length;
                currentLine.Enqueue(currentString);

                // I peek at the next word
                if (!q.Any())
                {
                    StringBuilder finalSb = new StringBuilder();
                    // if there isn't one, take the last line and we're done
                    while (currentLine.Any())
                    {
                        string lineItem = currentLine.Dequeue();
                        finalSb.Append(lineItem);
                    }

                    result.Add(finalSb.ToString());
                    break;
                }

                string next = q.Peek();

                // if it fits, keep going
                if (lineLength + next.Length + 1 <= maxWidth) continue;

                // if not
                // need to adjust the spaces to fit maxWidth
                int difference = maxWidth - lineLength;


                Queue<string> tempQ = new Queue<string>();
                while (difference > 0 && currentLine.Count > 1)
                {
                    string nextWord = currentLine.Dequeue();
                    nextWord = $"{nextWord} ";
                    tempQ.Enqueue(nextWord);
                    difference--;

                    if (currentLine.Count == 1 || difference == 0)
                    {
                        Queue<string> remainder = new Queue<string>(currentLine);
                        currentLine.Clear();

                        while (tempQ.Any())
                        {
                            currentLine.Enqueue(tempQ.Dequeue());
                        }

                        while (remainder.Any())
                        {
                            currentLine.Enqueue(remainder.Dequeue());
                        }
                    }
                }

                StringBuilder sb = new StringBuilder();
                while (currentLine.Any())
                {
                    sb.Append(currentLine.Dequeue());
                }

                // add sb output to result list.
                result.Add(sb.ToString().Trim());

                // and clear the list
                currentLine.Clear();
                lineLength = 0;
            }

            // one more check
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].PadRight(maxWidth);
            }

            return result;
        }
    }
}