namespace Pdrome2.BFS
{
    using System.Collections.Generic;
    using System.Text;

    public class BFSUnlockerOptimized : BFSActorOptimized<string>
    {
        public BFSUnlockerOptimized()
        {
        }

        public BFSUnlockerOptimized(string[] deads, string start, string target)
            : base(target, start)
        {
            this.deads = new HashSet<string>(deads);
        }

        private int level = 0;
        private HashSet<string> deads;

        protected override void Iterate()
        {
            this.level++;
        }

        protected override bool Ignore(string token)
        {
            if (!this.deads.Contains(token))
            {
                this.deads.Add(token);
                return false;
            }

            return true;
        }

        protected override void Done()
        {
            this.Result = this.level;
        }

        protected override void AddSiblings(string next, HashSet<string> queue)
        {
            StringBuilder sb = new StringBuilder(next);
            for (int i = 0; i < 4; i++)
            {
                string currentPosition = sb.ToString();
                char digit = currentPosition[i];

                string prefix = currentPosition.Substring(0, i);
                int targetDigitUp = digit == '9' ? 0 : digit - '0' + 1;
                int targetDigitDown = (digit == '0' ? 9 : digit - '0' - 1);
                string suffix = currentPosition.Substring(i + 1);

                string[] tokens = {$"{prefix}{targetDigitUp}{suffix}", $"{prefix}{targetDigitDown}{suffix}"};

                foreach (string token in tokens)
                {
                    if (this.deads.Contains(token)) continue;
                    queue.Add(token);
                }
            }
        }

        protected override void Failure()
        {
            this.Result = -1;
        }

        public int Result { get; private set; }

        public int OpenLock(string[] deads, string target)
        {
            this.level = 0;
            this.deads = new HashSet<string>(deads);
            this.Act("0000", target);
            return this.Result;
        }
    }
}