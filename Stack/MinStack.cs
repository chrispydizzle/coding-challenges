namespace Pdrome2.Stack
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class MinStack
    {
        private List<int> al;

        /** initialize your data structure here. */
        public MinStack()
        {
            this.al = new List<int>();
        }

        public void Push(int x)
        {
            this.al.Add(x);
        }

        public void Pop()
        {
            this.al.RemoveAt(this.al.Count - 1);
        }

        public int Top()
        {
            return this.al[this.al.Count - 1];
        }

        public int GetMin()
        {
            if (this.al.Count == 0) return -1;

            return this.al.Min();
        }
    }
}