namespace BoxOfT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Box<T>
    {
        private List<T> data;

        public int Count { get { return data.Count; } }

        public Box()
        {
            this.data = new List<T>();
        }

        /*
        public Box(List<T> data)
        {
            this.data = data;
        }
        */

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public T Remove()
        {
            T ret = this.data.Last();

            this.data.RemoveAt(this.data.Count - 1);

            return ret; 
        }

    }
}
