namespace _04_Border_Control.Models
{
    using _04_Border_Control.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text;

    public class Citizen : Identity, ICitizen
    {
        private string name;
        private int age;

        public string Name { get => this.name; set => this.name = value; }
        public int Age { get => this.age; set => this.age = value; }
        
        public Citizen(string id, string name, int age) : base(id)
        {
            this.Name = name;
            this.Age = age;
        }

    }
}
