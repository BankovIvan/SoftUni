namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Kitten : Cat
    {
        /*
        public Kitten(string name, int age, string gender) : base(name, age, "Female")
        {
        }
        */

        public Kitten(string name, int age) : base(name, age, "Female")
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

    }
}
