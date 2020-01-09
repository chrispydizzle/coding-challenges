namespace CodeChallenges.Design
{
    using System.Collections.Generic;
    using System.Linq;

    public class NestedIterator
    {
        // pointer idea sucked, lets use a stack.
        // could definitely do this better, but will let it go for now.

        private readonly Stack<NestedInteger> pending = new Stack<NestedInteger>();

        public NestedIterator(IList<NestedInteger> nestedList)
        {
            PushStack(nestedList);
        }

        private void PushStack(IList<NestedInteger> nestedList)
        {
            IEnumerable<NestedInteger> nestedIntegers = nestedList.Reverse();
            foreach (NestedInteger nestedInteger in nestedIntegers) PushStack(nestedInteger);
        }

        private void PushStack(NestedInteger n)
        {
            if (n.IsInteger())
                pending.Push(n);
            else
                PushStack(n.GetList());
        }

        public bool HasNext()
        {
            return pending.Any();
        }

        public int Next()
        {
            return pending.Pop().GetInteger();
        }
    }
}