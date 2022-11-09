namespace _Explicit.Models
{
    using _Explicit.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Citizen : IPerson, IResident
    {
        private string name;
        private int age;
        private string country;

        public string Name { get => this.name; set => this.name = value; }
        public int Age { get => this.age; set => this.age = value; }
        public string Country { get => this.country; set => this.country = value; }

        public Citizen(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

        string IPerson.GetName()
        {
            return this.name;
        }

        string IResident.GetName()
        {
            return "Mr/Ms/Mrs " + this.name;
        }
    }
}
