namespace Pdrome2.Solves
{
    internal class IncorrectPasscodeAttempts
    {
        public bool incorrectPasscodeAttempts(string passcode, string[] attempts)
        {
            int consecutive = 0;
            foreach (string attempt in attempts)
            {
                if (attempt == passcode)
                {
                    consecutive = 0;
                }

                if (attempt != passcode)
                {
                    consecutive++;
                }

                if (consecutive >= 10) return true;
            }

            return false;
        }
    }
}