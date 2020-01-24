namespace CodeChallenges.Arrays
{
    using System;

    public class TaskScheduler
    {
        public int LeastInterval(char[] tasks, int n)
        {
            int[] map = new int[26];
            foreach (var c in tasks)
            {
                map[c - 'A']++;
            }


            Array.Sort(map);
            int time = 0;
            while (map[25] > 0)
            {
                int i = 0;
                while (i <= n)
                {
                    if (map[25] == 0)
                    {
                        break;
                    }

                    if (i < 26 && map[25 - i] > 0)
                    {
                        map[25 - i]--;
                    }

                    time++;
                    i++;
                }

                Array.Sort(map);
            }

            return time;
        }
    }
}