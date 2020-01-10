namespace CodeChallenges.Design
{
    using System.Collections.Generic;

    public class NestedInteger : INestedInteger
    {
        private readonly List<NestedInteger> list;
        private bool isInt;
        private int value;

        public NestedInteger()
        {
            list = new List<NestedInteger>();
        }

        public NestedInteger(int val)
        {
            isInt = true;
            value = val;
        }

        public bool IsInteger()
        {
            return isInt;
        }

        public int GetInteger()
        {
            return value;
        }

        public void SetInteger(int value)
        {
            isInt = true;
            this.value = value;
        }

        public void Add(NestedInteger ni)
        {
            list.Add(ni);
        }

        public IList<NestedInteger> GetList()
        {
            return list;
        }

        public static NestedInteger GetSet()
        {
            NestedInteger n = new NestedInteger();
            NestedInteger n1 = new NestedInteger();
            NestedInteger n1a = new NestedInteger(1);
            NestedInteger n1b = new NestedInteger(1);
            n1.Add(n1a);
            n1.Add(n1b);

            NestedInteger n2 = new NestedInteger(2);

            NestedInteger n3 = new NestedInteger();
            NestedInteger n3a = new NestedInteger(1);
            NestedInteger n3b = new NestedInteger(1);
            n3.Add(n3a);
            n3.Add(n3b);

            n.Add(n1);
            n.Add(n2);
            n.Add(n3);

            return n;
        }
    }
}