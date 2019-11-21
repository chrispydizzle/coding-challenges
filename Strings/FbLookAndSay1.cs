namespace CodeChallenges.Strings
{
    using System.Text;

    public class FbLookAndSay
    {
        public string LookAndSay(int iterations)
        {
            StringBuilder b = new StringBuilder();
            string currentState = "1";
            int counter = 0;
            while (counter < iterations)
            {
                // dump current state
                b.AppendLine(currentState);

                StringBuilder internalBuilder = new StringBuilder();
                char currentTarget = currentState[0];
                int currentTargetCount = 1;

                // parse string, counting number of consecutive digits.
                for (int i = 1; i < currentState.Length; i++)
                {
                    char currentChar = currentState[i];
                    if (currentChar == currentTarget)
                    {
                        currentTargetCount++;
                    }
                    else
                    {
                        internalBuilder.Append(currentTargetCount);
                        internalBuilder.Append(currentTarget);
                        currentTargetCount = 1;
                        currentTarget = currentChar;
                    }
                }

                // we've run out of string to parse, append final value
                internalBuilder.Append(currentTargetCount);
                internalBuilder.Append(currentTarget);
                currentState = internalBuilder.ToString();
                counter++;
            }

            return b.ToString();
        }
    }
}