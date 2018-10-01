﻿namespace Pdrome2
{
    using System;
    using LinkedList;

    internal class LinkedListPrinter
    {
        public void Print(ListNode root)
        {
            Console.Write(root.val);

            ListNode nextNode = root.next;
            while (nextNode != null)
            {
                Console.Write($"->{nextNode.val}");
                nextNode = nextNode.next;
            }
        }
    }
}