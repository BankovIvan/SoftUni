namespace Person
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Child : Person
    {
        public new int Age
        {
            get { return base.Age; }
            set 
            {
                if(value > 15)
                {
                    //throw new ArgumentException("Child age above 15 not allowed!");
                }
                base.Age = value; 
            }
        }

        public Child(string name, int age) : base(name)
        {
            this.Age = age;
        }
    }
}
