using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private string name;
        private int neededRenovators;
        private string project;

        public Dictionary<string, Renovator> renovators { get; set; }
        public string Name { get { return this.name; } set { this.name = value;  } }
        public int NeededRenovators { get { return this.neededRenovators; } set { this.neededRenovators = value; } }
        public string Project { get { return this.project; } set { this.project = value; } }

        public int Count { get { return renovators.Count; } }

        public Catalog(string name, int neededRenovators, string project)
        {
            this.renovators = new Dictionary<string, Renovator>();
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
        }

        public string AddRenovator(Renovator renovator)
        {
            string ret = "";

            if(string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                //throw new NullReferenceException("Invalid renovator's information.");
                ret = "Invalid renovator's information.";
            }
            else if(this.Count >= this.NeededRenovators)
            {
                ret = "Renovators are no more needed.";
            }
            else if(renovator.Rate > 350.0)
            {
                ret = "Invalid renovator's rate.";
            }
            else
            {
                this.renovators.Add(renovator.Name, renovator);
                ret = String.Format("Successfully added {0} to the catalog.", renovator.Name);
            }

            return ret;
        }

        public bool RemoveRenovator(string name)
        {
            bool ret = false;

            if (this.renovators.ContainsKey(name))
            {
                ret = true;
                this.renovators.Remove(name);
            }

            return ret;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int ret = 0;

            List<string> lstRenovators = new List<string>();

            foreach (var v in this.renovators)
            {
                if(v.Value.Type == type)
                {
                    lstRenovators.Add(v.Key);
                }
            }

            ret = lstRenovators.Count;

            foreach(var v in lstRenovators)
            {
                this.renovators.Remove(v);
            }

            return ret;
        }

        public Renovator HireRenovator(string name)
        {
            Renovator ret = null;

            if (this.renovators.ContainsKey(name))
            {
                this.renovators[name].Hired = true;
                ret = this.renovators[name];
            }

            return ret;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> ret = new List<Renovator>();

            foreach(var v in this.renovators)
            {
                if(v.Value.Days >= days)
                {
                    ret.Add(v.Value);
                }
            }

            return ret;

        }

        public string Report()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("Renovators available for Project {0}:", this.Project));
            foreach(var v in this.renovators)
            {
                if(v.Value.Hired == false)
                {
                    ret.AppendLine(v.Value.ToString());
                }
            }

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
