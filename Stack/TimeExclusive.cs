namespace CodeChallenges.Stack
{
    using System.Collections.Generic;
    using System.Linq;

    public class TimeExclusive
    {
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            // I think we can stack them. Let's go through logs, and assume for now they are ordered correctly.

            int[] result = new int[n];
            Stack<int> s = new Stack<int>();

            if (logs.Count == 0) return new int[] { };

            // A bit different than expected due to recursion.
            // This is the optimized verison
            // TODO: Revisit

            string[] functionCall = logs[0].Split(':');
            s.Push(int.Parse(functionCall[0]));
            int previousLog = int.Parse(functionCall[2]);

            for (int i = 1; i < logs.Count; i++)
            {
                string log = logs[i];
                functionCall = log.Split(':');
                int time = int.Parse(functionCall[2]);
                int func = int.Parse(functionCall[0]);

                if (functionCall[1] == "start")
                {
                    if (s.Any()) result[s.Peek()] += time - previousLog;

                    s.Push(func);
                    previousLog = time;
                }
                else
                {
                    int f = s.Pop();
                    result[f] += time - previousLog + 1;
                    previousLog = time + 1;
                }
            }

            return result;
        }
    }
}