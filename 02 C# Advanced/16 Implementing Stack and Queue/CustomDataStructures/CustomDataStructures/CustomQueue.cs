namespace CustomDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CustomQueue
    {
        private const int InitialCapacity = 2;
        private const int UpsizeCapacityFactor = 2;
        private const int DownsizeCapacityFactor = 4;
        private const int DefaultValue = default(int);
        private const int FirstElementIndex = 0;

        private int[] items;
        private int count;

        public int Count { get { return this.count; } private set { this.count = value; } }

        public CustomQueue()
        {
            this.items = new int[InitialCapacity];
            this.Count = 0;
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.items[index];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                this.items[index] = value;
            }
        }

        private void IncreaseSize()
        {
            if (this.Count >= this.items.Length)
            {
                int[] copy = new int[this.items.Length * UpsizeCapacityFactor];
                Array.Copy(this.items, copy, this.items.Length);
                this.items = copy;
            }

        }

        private void Shrink()
        {
            if (this.Count >= InitialCapacity && this.Count * DownsizeCapacityFactor <= this.items.Length)
            {
                int[] copy = new int[this.items.Length / UpsizeCapacityFactor];
                Array.Copy(this.items, copy, copy.Length);
                this.items = copy;
            }

        }

        private void Shift(int index)
        {
            this.Count--;
            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.items[this.Count] = DefaultValue;
        }

        public void Enqueue(int item)
        {
            this.IncreaseSize();
            this.items[this.Count] = item;
            this.Count++;
        }

        private void IsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
        }

        public int Dequeue()
        {
            IsEmpty();

            int ret = this.items[FirstElementIndex];
            this.Shift(FirstElementIndex);
            //this.Count--;
            this.Shrink();

            return ret;
        }

        public int Peek()
        {
            IsEmpty();

            return this.items[FirstElementIndex];
        }

        public void Clear()
        {
            if(this.Count > 0)
            {
                this.items = new int[InitialCapacity];
                this.Count = 0;
            }

        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }

        public override string ToString()
        {
            return string.Format("Count = {0}\nSize = {1}\n", this.Count, this.items.Length) + String.Join('\n', this.items);

            StringBuilder ret = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                ret.AppendLine(this.items[i].ToString());
            }

            return ret.ToString();

        }
    }
}
