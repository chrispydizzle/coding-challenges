namespace CodeChallenges.BFS
{
    using System.Collections.Generic;
    using System.Text;

    internal class Unlocker
    {
        public int OpenLock(string[] deadends, string target)
        {
            return this.OpenLockExample(deadends, target);
        }

        public int OpenLockExample(string[] deadends, string target)
        {
            Queue<string> q = new Queue<string>();
            HashSet<string> deads = new HashSet<string>(deadends);
            HashSet<string> visited = new HashSet<string>();
            q.Enqueue("0000");
            visited.Add("0000");

            int level = 0;
            while (q.Count > 0)
            {
                int size = q.Count;
                while (size > 0)
                {
                    string s = q.Dequeue();
                    if (deads.Contains(s))
                    {
                        size--;
                        continue;
                    }

                    if (s == target) return level;

                    StringBuilder sb = new StringBuilder(s);
                    for (int i = 0; i < 4; i++)
                    {
                        string currentPosition = sb.ToString();
                        char digit = currentPosition[i];

                        string prefix = currentPosition.Substring(0, i);
                        int targetDigitUp = digit == '9' ? 0 : digit - '0' + 1;
                        int targetDigitDown = digit == '0' ? 9 : digit - '0' - 1;
                        string suffix = currentPosition.Substring(i + 1);

                        string[] tests = {$"{prefix}{targetDigitUp}{suffix}", $"{prefix}{targetDigitDown}{suffix}"};

                        foreach (string test in tests)
                        {
                            if (visited.Contains(test) || deads.Contains(test)) continue;

                            q.Enqueue(test);
                            visited.Add(test);
                        }
                    }

                    size--;
                }

                level++;
            }

            return -1;
        }
    }
}