namespace CustomDoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    internal class DoublyLinkedList : IEnumerable<ListNode>
    {
        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public void AddFirst(int element)
        {
            if(this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                ListNode newHead = new ListNode(element);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;

        }

        public void AddLast(int element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                ListNode newTail = new ListNode(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public int RemoveFirst()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var ret = this.head.Value;
            this.head = this.head.NextNode;
            if(this.Count == 1)
            {
                this.tail = null;
            }
            else
            {
                this.head.PreviousNode = null;
            }

            this.Count--;
            return ret;
        }

        public int RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var ret = this.tail.Value;
            this.tail = this.tail.PreviousNode;
            if (this.Count == 1)
            {
                this.head = null;
            }
            else
            {
                this.tail.NextNode = null;
            }

            this.Count--;
            return ret;
        }

        public void ForEach(Action<int> action)
        {
            var currentNode = this.head;
            while(currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            var ret = new int[this.Count];
            int counter = 0;
            var currentNode = this.head;

            while (currentNode != null)
            {
                ret[counter] = currentNode.Value;
                currentNode = currentNode.NextNode;
                counter++;
            }

            return ret;
        }

        public IEnumerator<ListNode> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
