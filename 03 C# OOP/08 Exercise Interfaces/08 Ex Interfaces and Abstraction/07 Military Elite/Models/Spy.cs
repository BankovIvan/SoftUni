namespace Military.Models
{
    using Military.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Spy : Soldier, ISpy
    {
        private int codeNumber;

        public int CodeNumber { get => this.codeNumber; set => this.codeNumber = value; }

        public Spy(long id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(
                String.Format(
                    "Name: {0} {1} Id: {2} \nCode Number: {3}",
                    this.FirstName, this.LastName, this.Id, this.CodeNumber
                    ));

            return ret.ToString().Trim();
        }

    }
}
