namespace Pdrome2.BFS
{
    using System;
    using System.Collections.Generic;

    public class DivideAndConquerQueue<T>
    {
        private Queue<T> fq = new Queue<T>();
        private Queue<T> rq = new Queue<T>();
        private HashSet<T> fh = new HashSet<T>();
        private HashSet<T> rh = new HashSet<T>();
        
        public HashSet<T> ActiveHashSet { get; private set; }
        public HashSet<T> InactiveHashSet { get; private set; }
        
        public Queue<T> ActiveQueue { get; private set; }
        public Queue<T> InactiveQueue { get; private set; }
        
        public DivideAndConquerQueue(T start, T target, Action iterate)
        {
            this.fq.Enqueue(start);
            this.rq.Enqueue(target);
            this.ActiveQueue = this.fq;
            this.ActiveHashSet = this.fh;
            this.InactiveHashSet = this.rh;
            this.InactiveQueue = this.rq;
            this.swapAction = iterate;
        }

        public int Count
        {
            get
            {
                if (this.ActiveQueue.Count == 0)
                {
                    this.Swap();
                }

                return this.ActiveQueue.Count;
            }
        }

        public T Dequeue()
        {
            return this.ActiveQueue.Dequeue();
        }

        public void Swap()
        {
            this.swapAction();
            this.InactiveQueue = this.ActiveQueue;
            this.ActiveQueue = this.tempQueue;
            
            HashSet<T> activeHashset= this.ActiveHashSet;
            HashSet<T> inactiveHashset = this.InactiveHashSet;

            this.InactiveHashSet = activeHashset;
            this.ActiveHashSet = inactiveHashset;
            
        }

        Queue<T> tempQueue = new Queue<T>();
        private Action swapAction;

        public void Enqueue(T test)
        {
            this.tempQueue.Enqueue(test);
            this.InactiveHashSet.Add(test);
        }
    }
}