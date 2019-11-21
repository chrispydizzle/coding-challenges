namespace CodeChallenges.BFS
{
    using System.Collections.Generic;

    public abstract class BFSActorQueue<T>
    {
        protected BFSActorQueue(T target, T start)
        {
        }

        protected BFSActorQueue()
        {
        }

        protected abstract void Iterate();

        protected abstract bool Ignore(T candidate);

        protected abstract void Done();

        protected abstract void AddSiblings(T next, HashSet<T> temp);

        protected abstract void Failure();

        protected void Act(T start, T target)
        {
            Queue<T> nodes = new Queue<T>();

            nodes.Enqueue(start);

            while (nodes.Count > 0)
            {
                this.Iterate();
                int currentSize = nodes.Count;

                HashSet<T> tempSet = new HashSet<T>();
                for (int i = 0; i < currentSize; i++)
                {
                    T dequeue = nodes.Dequeue();
                    if (this.Validate(dequeue))
                    {
                        this.Done();
                        return;
                    }

                    this.AddSiblings(dequeue, tempSet);
                }

                nodes = new Queue<T>(tempSet);
            }
        }

        protected abstract bool Validate(T dequeue);
    }
}