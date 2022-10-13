namespace ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Stack<T> : IEnumerable<T>
    {
        private List<T> Items { get; set; }
        public int Count { get { return Items.Count; } }

        public Stack()
        {
            this.Items = new List<T>();
        }

        public void Push(params T[] elements)
        {
            for(int i = 0; i < elements.Length; i++)
            {
                this.Items.Insert(0, elements[i]);
            }
            //this.Items.AddRange(elements);
        }

        public T Pop()
        {
            T ret = default(T);

            if(this.Count <= 0)
            {
                throw new InvalidOperationException("No elements");
            }
            else
            {
                ret = this.Items[0];
                this.Items.RemoveAt(0);
            }

            return ret;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                yield return this.Items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
