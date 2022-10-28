namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public string Name 
        { 
            get { return this.name; } 
            private set 
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Invalid input!");
                this.name = value; 
            } 
        }

        public int Age 
        { 
            get { return this.age; } 
            private set 
            {
                if(value <= 0) throw new ArgumentException("Invalid input!");
                this.age = value; 
            } 
        }

        public string Gender 
        { 
            get { return this.gender; } 
            private set 
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Invalid input!");
                this.gender = value; 
            } 
        }

        public virtual string ProduceSound() 
        {
            return "Noise";
        }

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.AppendLine(string.Format("{0}", this.GetType().Name));
            ret.AppendLine(string.Format("{0} {1} {2}", this.Name, this.Age, this.Gender));
            ret.AppendLine(this.ProduceSound());
            return ret.ToString().Trim();
        }
    }
}
