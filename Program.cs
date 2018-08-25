namespace Pdrome2
{
    using System;
    using System.Diagnostics;
    using System.Timers;
    using BFS;

    internal class Program
    {
        public static void Main(string[] args)
        {
            BFSUnlocker l = new BFSUnlocker();
            //Unlocker l = new Unlocker();
            Stopwatch t = new Stopwatch();
            t.Start();
            Console.WriteLine(l.OpenLock(new[] {"0201", "0101", "0102", "1212", "2002"}, "0202")); // 6
            Console.WriteLine(t.Elapsed.TotalMilliseconds);
            Console.WriteLine(l.OpenLock(new[] {"8888"}, "0009")); // 1
            Console.WriteLine(t.Elapsed.TotalMilliseconds);
            Console.WriteLine(l.OpenLock(new[] {"8887", "8889", "8878", "8898", "8788", "8988", "7888", "9888"}, "8888")); // -1
            Console.WriteLine(t.Elapsed.TotalMilliseconds);
        }
    }
}