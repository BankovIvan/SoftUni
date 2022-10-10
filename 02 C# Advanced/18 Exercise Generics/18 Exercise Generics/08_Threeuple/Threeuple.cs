namespace _08_Threeuple
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Threeuple<T1,T2, T3>
    {
        public List<T1> Item1 { get; set; }
        public List<T2> Item2 { get; set; }
        public List<T3> Item3 { get; set; }

        public Threeuple()
        {
            this.Item1 = new List<T1>();
            this.Item2 = new List<T2>();
            this.Item3 = new List<T3>();
        }

        public Threeuple(T1[] item1, T2[] item2, T3[] item3)
        {
            this.Item1 = new List<T1>(item1);
            this.Item2 = new List<T2>(item2);
            this.Item3 = new List<T3>(item3);
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1} -> {2}", 
                string.Join(' ', this.Item1), 
                string.Join(' ', this.Item2), 
                string.Join(' ', this.Item3));
        }

    }
}
