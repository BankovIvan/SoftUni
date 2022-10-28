namespace Zoo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Animal
    {
        private string name;

        public string Name { get { return name; } set { this.name = value; } }

        public Animal(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append(String.Format("Name: {0}", this.Name));
            return ret.ToString().Trim();
        }
    }
}
