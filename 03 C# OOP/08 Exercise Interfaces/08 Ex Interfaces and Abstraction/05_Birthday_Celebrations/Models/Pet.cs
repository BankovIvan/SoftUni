namespace Birthday.Models
{
    using Birthday.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Pet : Birthdate, IPet
    {
        private string name;

        public string Name { get => this.name; set => this.name = value; }

        public Pet(string name, DateTime birthday) : base(name, birthday)
        {
            this.Name = name;
        }

        
    }
}
