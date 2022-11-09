namespace Food.Models
{
    using Food.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text;

    public class Citizen : Birthdate, ICitizen, IBuyer
    {
        private string name;
        private int age;
        private int food;

        public string Name { get => this.name; set => this.name = value; }
        public int Age { get => this.age; set => this.age = value;  }
        public int Food { get => this.food; set => this.food = value; }

        public Citizen(string name, int age, string id, DateTime birthday) : base(id, birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Food = 0;
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
