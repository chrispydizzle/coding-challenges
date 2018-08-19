namespace Pdrome2
{
    using System;
    using System.Collections;
    using System.Dynamic;
    using System.Runtime.Remoting.Messaging;
    using System.Runtime.Serialization.Formatters;
    using System.Text.RegularExpressions;

    internal class Program
    {
        public static void Main(string[] args)
        {
            MineSweeper a = new MineSweeper();
            Console.WriteLine(a.minesweeper(new [] {
                new[] {true,false,false}, 
                new[] {false,true,false}, 
                new[] {false,false,false}})); // 4
        } 
    }
}