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
    }
}