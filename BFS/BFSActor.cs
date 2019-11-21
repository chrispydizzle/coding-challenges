namespace CodeChallenges.BFS
{
    using System.Collections.Generic;

    public abstract class BFSActor<T>
    {
        protected BFSActor(T target, T start)
        {
        }

        protected BFSActor()
        {
        }

        protected abstract void Iterate();

        protected abstract bool Ignore(T candidate);

        protected abstract void Done();

        protected abstract void AddSiblings(T next, Queue<T> queue, ICollection<T> visited);

        protected abstract void Failure();

        protected void Act(T start, T target)
        {
            Queue<T> q = new Queue<T>();
            HashSet<T> visited = new HashSet<T>();

            q.Enqueue(start);
            visited.Add(start);

            while (q.Count > 0)
            {
                int size = q.Count;
                while (size > 0)
                {
                    T next = q.Dequeue();

                    if (this.Ignore(next))
                    {
                        size--;
                        continue;
                    }

                    if (this.Validate(next)) return;

                    this.AddSiblings(next, q, visited);

                    size--;
                }

                this.Iterate();
            }

            this.Failure();
        }

        protected abstract bool Validate(T next);
    }
}