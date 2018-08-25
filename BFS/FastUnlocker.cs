namespace Pdrome2.BFS
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class FastUnlocker
    {
        public int OpenLock(string[] deadends, string target)
        {
            HashSet<string> heads = new HashSet<string>();
            HashSet<string> tails = new HashSet<string>();
            HashSet<string> deads = new HashSet<string>(deadends);
            
            heads.Add("0000");
            tails.Add(target);
            
            int level = 0;
            while (heads.Count != 0 && tails.Count != 0)
            {
                HashSet<string> temp = new HashSet<string>();
                foreach (string s in heads)
                {
                    if (deads.Contains(s)) continue;
                    
                    if (tails.Contains(s)) return level;

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
                heads = tails;
                tails = temp;
            }

            return -1;
        }
    }
}