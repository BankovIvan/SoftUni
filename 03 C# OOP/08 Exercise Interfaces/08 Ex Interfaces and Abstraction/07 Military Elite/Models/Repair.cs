namespace Military.Models
{
    using Military.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Repair : IRepair
    {
        private string partName;
        private int hoursWorked;

        public string PartName { get => this.partName; set => this.partName = value; }
        public int HoursWorked { get => this.hoursWorked; set => this.hoursWorked = value; }

        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hoursWorked;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("Part Name: {0} Hours Worked: {1}", this.PartName, this.HoursWorked));

            return ret.ToString().Trim();
        }
    }
}
