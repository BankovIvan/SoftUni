namespace Birthday.Models
{
    using Birthday.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text;

    public class Citizen : Birthdate, ICitizen
    {
        private string name;
        private int age;

        public string Name { get => this.name; set => this.name = value; }
        public int Age { get => this.age; set => this.age = value;  }
        
        public Citizen(string name, int age, string id, DateTime birthday) : base(id, birthday)
        {
            this.Name = name;
            this.Age = age;
        }

    }
}
