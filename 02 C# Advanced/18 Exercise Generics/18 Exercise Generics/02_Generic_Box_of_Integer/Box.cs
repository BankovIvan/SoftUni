namespace _02_Generic_Box_of_Integer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        public T Value { get; set; }


        public Box(T value)
        {
            this.Value = value;
        }


        public override string ToString()
        {
            return String.Format("{0}: {1}", this.Value.GetType(), this.Value.ToString());
        }

    }
}
