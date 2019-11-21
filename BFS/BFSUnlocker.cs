namespace CodeChallenges.BFS
{
    using System.Collections.Generic;
    using System.Text;

    public class BFSUnlocker : BFSActor<string>
    {
        private HashSet<string> deads;

        private int level;
        private string target;

        public BFSUnlocker()
        {
        }

        public BFSUnlocker(string[] deads, string start, string target)
            : base(target, start)
        {
            this.deads = new HashSet<string>(deads);
        }

        public int Result { get; private set; }

        protected override void Iterate()
        {
            this.level++;
        }

        protected override bool Ignore(string candidate)
        {
            return this.deads.Contains(candidate);
        }

        protected override void Done()
        {
            this.Result = this.level;
        }

        protected override void AddSiblings(string next, Queue<string> queue, ICollection<string> visited)
        {
            StringBuilder sb = new StringBuilder(next);
            for (int i = 0; i < 4; i++)
            {
                string currentPosition = sb.ToString();
                char digit = currentPosition[i];

                string prefix = currentPosition.Substring(0, i);
                int targetDigitUp = digit == '9' ? 0 : digit - '0' + 1;
                int targetDigitDown = digit == '0' ? 9 : digit - '0' - 1;
                string suffix = currentPosition.Substring(i + 1);

                string[] tests = {$"{prefix}{targetDigitUp}{suffix}", $"{prefix}{targetDigitDown}{suffix}"};

                foreach (string test in tests)
                {
                    if (visited.Contains(test) || this.deads.Contains(test)) continue;

                    queue.Enqueue(test);
                    visited.Add(test);
                }
            }
        }

        protected override void Failure()
        {
            this.Result = -1;
        }

        protected override bool Validate(string next)
        {
            if (next == this.target)
            {
                this.Done();
                return true;
            }

            return false;
        }

        public int OpenLock(string[] deads, string target)
        {
            this.level = 0;
            this.deads = new HashSet<string>(deads);
            this.target = target;
            this.Act("0000", target);
            return this.Result;
        }
    }
}