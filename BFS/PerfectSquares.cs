namespace Pdrome2
{
    using System.Collections.Generic;
    using BFS;

    internal class PerfectSquares : BFSActorQueue<int>
    {
        private int steps;
        private int target;

        public int NumSquares(int n)
        {
            this.steps = 0;
            this.target = n;
            this.Act(0, n);
            return this.steps;
        }

        protected override void Iterate()
        {
            this.steps++;
        }

        protected override bool Ignore(int candidate)
        {
            return false;
        }

        protected override void Done()
        {
        }

        protected override void AddSiblings(int next, HashSet<int> temp)
        {
            int i = 1;
            int square = 1;
            int difference = this.target - next;

            while (square < difference)
            {
                temp.Add(square);
                i++;
                square = i * i;
            }
        }

        protected override void Failure()
        {
        }

        protected override bool Validate(int dequeue)
        {
            if (dequeue == this.target) return true;

            return false;
        }
    }
}