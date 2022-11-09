namespace Food.Models
{
    using Food.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Rebel : ICitizen, IBuyer
    {
        private string name;
        private int age;
        private string group;
        private int food;

        public string Name { get => this.name; set => this.name = value; }
        public int Age { get => this.age; set => this.age = value; }
        public string Group { get => this.group; set => this.group = value; }
        public int Food { get => this.food; set => this.food = value; }

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
