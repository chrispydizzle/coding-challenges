﻿namespace Pdrome2
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
//            BFSUnlockerOptimized l = new BFSUnlocker();
            //Unlocker l = new Unlocker();
            //FastUnlocker l = new FastUnlocker();
            Stopwatch t = new Stopwatch();
            t.Start();
            Console.WriteLine(l.OpenLock(new[] {"7887","7876","8677","7667","8686","6688","6777","8687","8877","8668","6676","7778","7788","6766","7687","6688","6867","8866","7878","6776","6888","7888","6767","8787","6876","8788","6767","7667","8768","8877","6786","7878","6888","8786","7866","8887","8866","8788","6787","7676","7766","7867","7687","6676","6776","6878","7876","7888","8877","7788","7876","8687","8866","8776","7666","7887","7787","6768","7876","8776","6877","8666","8868","8876","8868","6778","7887","6787","7878","7766","6887","7776","7867","6677","8788","7778","7878","8786","6667","7776","7687","6888","7776","6887","6788","7768","6767","7886","6787","7876","8678","7677","8776","7866","6777","6778","8788","8766","8768","8867","6876","7876","6766","6786","7786","7888","8868","8688","8788","6666","6788","6688","8887","7866","7878","6777","6786","7688","7677","7777","6767","6877","7677","6888","7668","8677","7668","8788","7666","7688","7688","7887","8877","7687","6868","6687","6668","6667","6886","6888","7676","7867","8786","7686","8666","7668","6766","7877","6667","7886","8786","6866","7788","6877","8878","7767","7766","7786","8788","7888","7778","8876","8778","6786","8786","8777","6667","8687","6776","8788","6878","8678","6887","8788","7676","8888","6788","7878","7878","8867","6767","8688","7888","6877","7866","7678","8878","8786","7887","6866","8668","7868","6887","6688","7686","6876","7677","7868","6876","6877","7678","7766","8787","6676","8776","6767","8877","6868","8786","8887","8776","7867","7678","8868","8887","6767","8778","7768","7666","7876","8686","7868","6777","8877","8888","6686","8768","6768","6768","8686","7776","7877","8887","6677","8878","8678","6677","7678","7768","6868","7867","7888","6788","6886","8677","8667","8788","7677","8678","8766","7686","8888","7666","7678","6676","8776","6668","8867","8668","8776","8687","8888","7778","6878","7678","6686","8667","8786","8877","7768","7666","8777","7878","8888","7787","7666","8676","6666","8778","6767","8886","7877","8787","7666","8868","7868","8887","8667","6787","7776","7778","6677","6877","6668","6767","8788","8866","8787","8676","6878","8787","6668","8776","8877","8778","8887","8887","7688","7886","7766","7887","7888","8866","6876","6868","6786","6788","8777","7668","6686","6867","7777","8678","6688","6878","8778","8877","6776","8776","7768","6678","8866","8677","8667","6667","6786","8867","6776","6787","7787","7777","6668","6777","6777","8778","6866","7786","7777","6866","8776","7666","8777","8876","7667","8678","8778","7776","6877","6787","7767","7777","6787","6678","6868","7886","6688","6888","6877","8887","6786","6876","7688","7686","8677","7766","7667","7676","6867","7666","8778","6786","7676","8777","8786","6687","7867","6788","6868","6868","7887","8778","7778","6777","8678","7876","8888","8687","6686","7887","8677","6688","7788","7776","7766","7768","6866","7666","7778","6676","6677","8776","8676","6866","8666","7787","7687","8676","7766","7777","8686","7888","7676","6666","7667","6886","6678","6888","8788","7867","8776","7768","7767","8778","7666","8667","7876","8868","6678","6766","6888","7678","6678","8878","7678","7876","7768","8678","6866","6787","6868","8778","8688","8688","8666","7776","7686","8876","6786","7878","8777","6766","7676","7686","8677","6768","8886","6766","8678","7878","8788","7688","7766","7677","7668","7678","8686","6888","8868","7887","8766","8678","6767","7877","6888","7666","8787","7767","6766","8677","7868","6778","7687","7766","6768","6786","8886","6688","8678","7778","6777"}, "8767")); // 6
            Console.WriteLine(t.Elapsed.TotalMilliseconds);
            t.Reset();
            t.Start();
            Console.WriteLine(l.OpenLock(new[] {"8888"}, "0009")); // 1
            Console.WriteLine(t.Elapsed.TotalMilliseconds);
            t.Reset();
            t.Start();
            Console.WriteLine(l.OpenLock(new[] {"8887", "8889", "8878", "8898", "8788", "8988", "7888", "9888"}, "8888")); // -1
            Console.WriteLine(t.Elapsed.TotalMilliseconds);
        }
    }
}