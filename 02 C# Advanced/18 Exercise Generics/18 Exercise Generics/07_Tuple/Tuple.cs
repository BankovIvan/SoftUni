namespace _07_Tuple
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tuple<T1,T2>
    {
        //private T1 item1;
        //private T2 item2;

        //public T1 Item1 { get { return item1; } set { this.Item1 = value; } }
        //public T2 Item2 { get { return item2; } set { this.Item2 = value; } }

        public List<T1> Item1 { get; set; }
        public List<T2> Item2 { get; set; }

        public Tuple()
        {
            this.Item1 = new List<T1>();
            this.Item2 = new List<T2>();
        }

        public Tuple(T1[] item1, T2[] item2)
        {
            this.Item1 = new List<T1>(item1);
            this.Item2 = new List<T2>(item2);
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1}", string.Join(' ', this.Item1), string.Join(' ', this.Item2));
        }

    }
}
