namespace Pdrome2.BFS
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
                        int targetDigitDown = (digit == '0' ? 9 : digit - '0' - 1);
                        string suffix = currentPosition.Substring(i + 1);

                        string[] tests = new[] {$"{prefix}{targetDigitUp}{suffix}", $"{prefix}{targetDigitDown}{suffix}"};

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

        public int openLockFaster(string[] deadends, string target)
        {
            HashSet<string> begin = new HashSet<string>();
            HashSet<string> end = new HashSet<string>();
            HashSet<string> deads = new HashSet<string>(deadends);
            begin.Add("0000");
            end.Add(target);
            int level = 0;
            while (begin.Count != 0 && end.Count != 0)
            {
                HashSet<string> temp = new HashSet<string>();
                foreach (string s in begin)
                {
                    if (end.Contains(s)) return level;

                    if (deads.Contains(s)) continue;

                    deads.Add(s);
                    StringBuilder sb = new StringBuilder(s);
                    for (int i = 0; i < 4; i++)
                    {
                        char c = sb[i];
                        string s1 = sb.ToString().Substring(0, i) + (c == '9' ? 0 : c - '0' + 1) + sb.ToString().Substring(i + 1);
                        string s2 = sb.ToString().Substring(0, i) + (c == '0' ? 9 : c - '0' - 1) + sb.ToString().Substring(i + 1);
                        if (!deads.Contains(s1))
                            temp.Add(s1);
                        if (!deads.Contains(s2))
                            temp.Add(s2);
                    }
                }

                level++;
                begin = end;
                end = temp;
            }

            return -1;
        }
    }
}