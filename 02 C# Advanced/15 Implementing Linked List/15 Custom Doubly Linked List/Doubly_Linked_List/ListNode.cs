namespace CustomDoublyLinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class ListNode
    {
        public int Value { get; set; }
        public ListNode NextNode { get; set; }
        public ListNode PreviousNode { get; set; }

        public ListNode(int value) { this.Value = value; }

    }
}
