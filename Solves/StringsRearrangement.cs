namespace CodeChallenges.Solves
{
    using System;
    using System.Collections.Generic;

    public class StringsRearrangement
    {
        public void Main(string[] args)
        {
            StringsRearrangement s = new StringsRearrangement();
            Console.WriteLine(s.stringsRearrangement(new[]
            {
                "abc",
                "bef",
                "bcc",
                "bec",
                "bbc",
                "bdc"
            }));
            Console.WriteLine(s.stringsRearrangement(new[] {"aba", "bbb", "bab"}));
            Console.WriteLine(s.stringsRearrangement(new[] {"ab", "bb", "aa"}));
            Console.WriteLine(s.stringsRearrangement(new[] {"abc", "abx", "axx", "abc"}));
        }

        private bool Match(string root, string test)
        {
            int diffChars = 0;
            for (int index = 0; index < test.Length; index++)
            {
                char targetC = test[index];
                char rootC = root[index];
                if (targetC != rootC) diffChars++;
            }

            if (diffChars == 1)
            {
                return true;
            }

            return false;
        }

        public bool stringsRearrangement(string[] inputArray)
        {
            foreach (string root in inputArray)
            {
                List<string> available = new List<string>(inputArray);
                Stack<Tuple<string, List<string>>> processList = new Stack<Tuple<string, List<string>>>();
                available.Remove(root);
                processList.Push(new Tuple<string, List<string>>(root, available));

                while (processList.Count > 0)
                {
                    Tuple<string, List<string>> tuple = processList.Pop();
                    string test = tuple.Item1;

                    foreach (string s in tuple.Item2)
                    {
                        if (this.Match(test, s))
                        {
                            List<string> nextLevel = new List<string>(tuple.Item2);
                            nextLevel.Remove(s);
                            if (nextLevel.Count == 0)
                            {
                                return true;
                            }

                            processList.Push(new Tuple<string, List<string>>(s, nextLevel));
                        }
                    }
                }
            }

            return false;
        }
    }
}