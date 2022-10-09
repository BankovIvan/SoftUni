namespace CustomDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Metadata;
    using System.Text;

    public class CustomList
    {
        private const int InitialCapacity = 2;
        private const int UpsizeCapacityFactor = 2;
        private const int DownsizeCapacityFactor = 4;
        private const int DefaultValue = default(int);

        private int[] items;

        public int Count { get; private set; }

        public CustomList()
        {
            this.items = new int[InitialCapacity];
            this.Count = 0;
        }

        public int this[int index]
        {
            get
            {
                if(index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.items[index];
            }

            set
            {
                if(index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                this.items[index] = value;
            }
        }

        private void Resize()
        {
            if (this.Count >= this.items.Length)
            {
                int[] copy = new int[this.items.Length * UpsizeCapacityFactor];
                Array.Copy(this.items, copy, this.items.Length);
                this.items = copy;
            }

        }

        public void Add(int Element)
        {
            this.Resize();
            this.items[this.Count] = Element;
            this.Count++;
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

        private void Shrink()
        {
            if(this.Count >= InitialCapacity && this.Count * DownsizeCapacityFactor  <= this.items.Length)
            {
                int[] copy = new int[this.items.Length / UpsizeCapacityFactor];
                Array.Copy(this.items, copy, copy.Length);
                this.items = copy;
            }

        }

        public int RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            int ret = this.items[index];

            this.Shift(index);
            this.Shrink();

            return ret;
        }

        private void ShiftToRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
            this.items[index] = DefaultValue; //Maybe not used...
            this.Count++;
        }

        public void Insert(int index, int item)
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            this.Resize();
            this.ShiftToRight(index);
            this.items[index] = item;
        }

        public bool Contains(int element)
        {
            return Array.Exists(this.items, x => x == element);
        }

        public void Swap(int FirstIndex, int SecondIndex)
        {
            if (FirstIndex < 0 || FirstIndex >= this.Count || SecondIndex < 0 || SecondIndex >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            int swap = this.items[FirstIndex];
            this.items[FirstIndex] = this.items[SecondIndex];
            this.items[SecondIndex] = swap;

        }

        public override string ToString()
        {
            return string.Format("Count = {0}\nSize = {1}\n", this.Count, this.items.Length) + String.Join('\n', this.items);

            StringBuilder ret = new StringBuilder();

            for(int i = 0; i < this.Count; i++)
            {
                ret.AppendLine(this.items[i].ToString());
            }

            return ret.ToString();

        }

        public int Find(int Element)
        {
            int ret = -1;

            for(int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == Element)
                {
                    ret = i;
                    break;
                }
            }

            return ret;
        }

        public void Reverse()
        {
            Array.Reverse(this.items);
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }

    }
}
