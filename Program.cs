namespace Pdrome2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Timers;
    using System.Xml.Schema;
    using LinkedList;

    internal class Program
    {
        public static void Main(string[] args)
        {
            ListNode root = new ListNode(1);
            root.next = new ListNode(2);
            root.next.next = new ListNode(3);
            root.next.next.next = new ListNode(4);
            root.next.next.next.next = new ListNode(5);

            ListNode root2 = new ListNode(2);
            root2.next = new ListNode(5);
            root2.next.next = new ListNode(6);
            
//            ListNode reverseList = new ReverseLinkedList().ReverseList(root);
            ListNode sortList = new SortList().MergeTwoLists(root, root2);
            
            
            new LinkedListPrinter().Print(sortList);

            Console.ReadLine();
        }

        private static void W(object o)
        {
            Console.WriteLine(o);
        }
    }

    internal class SortList
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
            // check which pointer between l1 and l2 is smaller, make that the new root.
            // if they are equal, just default to l1
        
            if(l1 == null) return l2;
            if(l2 == null) return l1;
        
            if(l1.val < l2.val)
            {
                l1.next = this.MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = this.MergeTwoLists(l2.next, l1);
                return l2;
            }
        }
    }

    internal class ReverseLinkedList
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null) return null;

            Stack<ListNode> nodes = new Stack<ListNode>();
            nodes.Push(head);
            ListNode nextNode = head.next;
            while (nextNode != null)
            {
                nodes.Push(nextNode);
                nextNode = nextNode.next;
            }

            ListNode newHead = nodes.Pop();
            nextNode = newHead;
            while (nodes.Any())
            {
                nextNode.next = nodes.Pop();
                nextNode = nextNode.next;
            }

            head.next = null;

            return newHead;
        }
    }
}