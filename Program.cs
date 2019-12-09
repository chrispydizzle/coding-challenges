namespace CodeChallenges
{
    using System;
    using Arrays;
    using LinkedList;
    using Strings;

    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new BackwardsReorderList();

            ListNode listNode = ListNode.Make(1, 2, 3, 4, 5);
            // listNode = ListNode.Make(1, 2, 3, 4);

            s.ReorderList(listNode);

            //string repChards = new string('a', )
            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}