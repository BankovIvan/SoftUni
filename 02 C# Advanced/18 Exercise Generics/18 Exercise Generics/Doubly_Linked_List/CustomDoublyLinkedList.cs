namespace CustomDoublyLinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CustomDoublyLinkedList<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }

        public CustomDoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public void AddFirst(T element)
        {
            if(this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newHead = new ListNode<T>(element);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;

        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newTail = new ListNode<T>(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
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

        public T RemoveLast()
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

        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;
            while(currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            var ret = new T[this.Count];
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

    }
}
