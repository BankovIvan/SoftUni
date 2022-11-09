namespace Military.Models
{
    using Military.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Private : Soldier, IPrivate
    {
        private decimal salary;

        public decimal Salary { get => this.salary; set => this.salary = value; }

        public Private(long id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(
                String.Format(
                    "Name: {0} {1} Id: {2} Salary: {3:F2}", 
                    this.FirstName, this.LastName, this.Id, this.Salary
                    ));

            return ret.ToString().Trim();
        }
    }
}
