namespace PersonsInfo
{
    using System;
    using System.Text;

    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        
        public string FirstName { get => this.firstName; set => this.firstName = value; }
        public string LastName { get => this.lastName; set => this.lastName = value; }
        public int Age { get => this.age; set => this.age = value; }

        public Person(string firstName, string lastName, int age){
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("{0} {1} is {2} years old.", this.FirstName, this.LastName, this.Age));

            return ret.ToString().Trim();
        }

    }
}