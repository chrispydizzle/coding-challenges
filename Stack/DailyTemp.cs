namespace Pdrome2
{
    using System.Collections.Generic;
    using System.Linq;

    internal class DailyTemp
    {
        public int[] dailyTemperatures(int[] temperatures)
        {
            int m = temperatures.Length;
            int[] ans = new int[m];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < m; i++)
            {
                while (stack.Any() && temperatures[stack.Peek()] < temperatures[i])
                {
                    ans[stack.Peek()] = i - stack.Pop();
                }

                stack.Push(i);
            }

            return ans;
        }

        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] dayStack = new int[temperatures.Length];
            Stack<int> tempStack = new Stack<int>();
            for (int i = 0; i < temperatures.Length; i++)
            {
                // tempstack will act to store the index of a day which does not yet have an answer
                // as we iterate, if there is anything in the tempstack, we check the top item to see if it's less than
                // the current temp.
                while (tempStack.Any() && temperatures[tempStack.Peek()] < temperatures[i])
                {
                    // if it is, we can address our answer's proper index, since we've stored it on the stack.
                    // the solution is to then subtract our original index from our current iteration value to get the number of days. 
                    dayStack[tempStack.Peek()] = i - tempStack.Pop();
                }

                // most importantly, push an index onto the stack. the answer is always one (except for the unmatchables at the end
                tempStack.Push(i);
            }

            return dayStack;
        }
    }
}