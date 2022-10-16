using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {
        private string name;
        private string type;
        private double rate;
        private int days;
        private bool hired;

        public string Name { get { return this.name; } set { this.name = value; } }
        public string Type { get { return this.type; } set { this.type = value; } }
        public double Rate { get { return this.rate; } set { this.rate = value; } }
        public int Days { get { return this.days; } set { this.days = value; } }
        public bool Hired { get { return this.hired; } set { this.hired = value; } }

        public Renovator(string name, string type, double rate, int days)
        {
            this.Name = name;
            this.Type = type;
            this.Rate = rate;
            this.Days = days;
            this.Hired = false;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("-Renovator: {0}", this.Name));
            ret.AppendLine(String.Format("--Specialty: {0}", this.Type));
            ret.AppendLine(String.Format("--Rate per day: {0} BGN", this.Rate));

            ////////////////////////////////////////////////////////////////////////
            ///
            ///   !!!   ТЕ ТАКА СЕ ПРАВИ У ДЖЪДЖО   !!!
            ///   
            ///   !!!   ТРЕБЕ СИ StringBuilder.ToString().Trim()   !!!
            ///
            ////////////////////////////////////////////////////////////////////////
            
            return ret.ToString().Trim();
        }


    }
}
