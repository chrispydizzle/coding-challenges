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
            var s = new MergeTwoSortedLists();

            var root1 = new ListNode(1);
            var child1Root1 = new ListNode(2);
            var child2Root1 = new ListNode(4);

            root1.next = child1Root1;
            child1Root1.next = child2Root1;

            var root2 = new ListNode(1);
            var child1Root2 = new ListNode(3);
            var child2Root2 = new ListNode(4);

            root2.next = child1Root2;
            child1Root2.next = child2Root2;

            var result = s.MergeTwoLists(root1, root2);
            

            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }
}