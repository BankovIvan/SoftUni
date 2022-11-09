namespace Military.Models
{
    using Military.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Soldier : ISoldier
    {
        private long id;
        private string firstName;
        private string lastName;

        public long Id { get => this.id; set => this.id = value; }
        public string FirstName { get => this.firstName; set => this.firstName = value; }
        public string LastName { get => this.lastName; set => this.lastName = value; }

        protected Soldier(long id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("Name: {0} {1} Id: {2}", this.FirstName, this.LastName, this.Id));

            return ret.ToString().Trim();
        }

    }
}
