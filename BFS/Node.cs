namespace CodeChallenges.BFS
{
    using System.Collections.Generic;

    public abstract class Node
    {
        protected Node()
        {
            this.Neighbors = new List<Node>();
        }

        public List<Node> Neighbors { get; set; }
    }

    public class TypedNode<T> : Node
    {
    }
}