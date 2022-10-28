namespace Person
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private string name;
        private int age;

        public string Name { get { return name; } set { name = value; } }
        public int Age 
        { 
            get { return age; } 
            set 
            {
                if(value < 0)
                {
                    //throw new ArgumentException("Invalid age less than zeroe!");
                }
                age = value; 
            } 
        }

        public Person(string name)
        {
            this.Name = name;
            this.Age = default(int);
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString();
        }

    }
}
