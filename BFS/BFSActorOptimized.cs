namespace CodeChallenges.BFS
{
    using System.Collections.Generic;

    public abstract class BFSActorOptimized<T>
    {
        protected BFSActorOptimized(T target, T start)
        {
        }

        protected BFSActorOptimized()
        {
        }

        protected abstract void Iterate();

        protected abstract bool Ignore(T candidate);

        protected abstract void Done();

        protected abstract void AddSiblings(T next, HashSet<T> temp);

        protected abstract void Failure();

        protected void Act(T start, T target)
        {
            HashSet<T> heads = new HashSet<T>();
            HashSet<T> tails = new HashSet<T>();
            HashSet<T> temp;
            heads.Add(start);
            tails.Add(target);

            while (heads.Count > 0 && tails.Count > 0)
            {
                if (heads.Count > tails.Count)
                {
                    temp = heads;
                    heads = tails;
                    tails = temp;
                }

                temp = new HashSet<T>();

                foreach (T token in heads)
                {
                    if (tails.Contains(token))
                    {
                        this.Done();
                        return;
                    }

                    if (this.Ignore(token))
                    {
                        continue;
                    }

                    this.AddSiblings(token, temp);
                }

                this.Iterate();

                heads = temp;
            }

            this.Failure();
        }
    }
}