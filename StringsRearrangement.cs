namespace Pdrome2
{
    using System;
    using System.Collections.Generic;

    internal class StringsRearrangement
    {
        public void Main(string[] args)
        {
            StringsRearrangement s = new StringsRearrangement();
            Console.WriteLine(s.stringsRearrangement(new string[] {"aba", "bbb", "bab"}));
            Console.WriteLine(s.stringsRearrangement(new string[] {"ab", "bb", "aa"}));
            Console.WriteLine(s.stringsRearrangement(new string[] {"abc", "abx", "axx", "abc"}));
        }

        internal bool stringsRearrangement(string[] inputArray)
        {
            Queue<string> q = new Queue<string>();
            List<string> visited = new List<string>();
            
            string node = inputArray[0];
            q.Enqueue(node);
            visited.Add(node);
            
            while (q.Count > 0)
            {
                string s = q.Dequeue();
                
                for (int i = 1; i < inputArray.Length; i++)
                {
                    
                }

                string target = "bleh";
                for (int index = 0; index < target.Length; index++)
                {
                    char targetC = target[index];
                    char rootC = s[index];
                    //if (targetC != rootC) diffChars++;
                }
            }
            
            for (int i = 1; i < inputArray.Length; i++)
            {
                string target = inputArray[i];
                if (target == null)
                {
                    continue;
                }

                int diffChars = 0;
                for (int index = 0; index < target.Length; index++)
                {
                    char targetC = target[index];
                    //char rootC = dequeue[index];
                    //if (targetC != rootC) diffChars++;
                }

                if (diffChars == 1)
                {
                    //queue.Enqueue(target);
                }

                foreach (string s in inputArray)
                {
                    if (s != null)
                        return false;
                }

                return true;
            }

            return false;
        }
    }
}