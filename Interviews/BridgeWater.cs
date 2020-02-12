namespace CodeChallenges.Interviews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BridgeWater
    {
        public string IsPossible(int a, int b, int c, int d)
        {
            ValueTuple<int, int> start = new ValueTuple<int, int>(a, b);
            ValueTuple<int, int> target = new ValueTuple<int, int>(c, d);
            Queue<ValueTuple<int, int>> q = new Queue<ValueTuple<int, int>>();
            q.Enqueue(start);
            while (q.Any())
            {
                ValueTuple<int, int> dequeue = q.Dequeue();
                ValueTuple<int, int> pathOne = new ValueTuple<int, int>(a + b, b);
                ValueTuple<int, int> pathTwo = new ValueTuple<int, int>(a, b + a);
                if ((pathOne.Item1 == target.Item1 && pathOne.Item2 == target.Item2) || (pathTwo.Item1 == target.Item1 && pathTwo.Item2 == target.Item2))
                {
                    return "Yes";
                }

                if (pathOne.Item1 <= target.Item1 && pathOne.Item2 <= target.Item2)
                {
                    q.Enqueue(pathOne);
                }

                if (pathTwo.Item1 <= target.Item1 && pathTwo.Item2 <= target.Item2)
                {
                    q.Enqueue(pathTwo);
                }
            }

            return "No";
        }
    }
}