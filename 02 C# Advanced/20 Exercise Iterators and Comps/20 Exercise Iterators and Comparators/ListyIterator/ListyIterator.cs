namespace ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class ListyIterator<T> : IEnumerable<T>
    {
        public List<T> Items { get; set; }  
        private int index { get; set; }

        public ListyIterator()
        {
            this.Items = new List<T>();
            this.index = 0;
        }

        public ListyIterator(List<T> items)
        {
            this.Items = items;
            this.index = 0;
        }

        public ListyIterator(params T[] items)
        {
            this.Items = new List<T>(items);
            this.index = 0;
        }

        public override string ToString()
        {
            return string.Join('\n', this.Items);
        }

        public bool Move()
        {
            bool ret = this.HasNext();

            if(ret)
            {
                this.index++;
            }

            return ret;
        }

        public bool HasNext()
        {
            bool ret = (this.index + 1) < this.Items.Count;

            return ret;
        }

        public void Print()
        {
            if (this.index < this.Items.Count)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(this.Items[this.index].ToString());
                Console.ResetColor();
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine("Invalid Operation!");
                //Console.ResetColor();
            }
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
