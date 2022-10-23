using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private string model;
        private int capacity;

        public string Model { get { return model; } set { model = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }

        public Dictionary<string, CPU> Multiprocessor { get; set; }
        public int Count { get { return this.Multiprocessor.Count; } }

        public Computer(string model, int capacity)
        {
            this.Model = model;
            this.Capacity = capacity;
            Multiprocessor = new Dictionary<string, CPU>();
        }

        public void Add(CPU cpu)
        {
            if(this.Count < this.Capacity)
            {
                this.Multiprocessor.Add(cpu.Brand, cpu);
            }
        }

        public bool Remove(string brand)
        {
            bool ret = this.Multiprocessor.ContainsKey(brand);

            if(ret == true) this.Multiprocessor.Remove(brand);

            return ret;
        }

        public CPU MostPowerful()
        {
            CPU ret = null;

            foreach(var v in this.Multiprocessor)
            {
                if(ret == null)
                {
                    ret = v.Value;
                }
                else
                {
                    if(v.Value.Frequency > ret.Frequency)
                    {
                        ret = v.Value;
                    }
                }
            }

            return ret;
        }

        public CPU GetCPU(string brand)
        {
            CPU ret = this.Multiprocessor.GetValueOrDefault(brand, null);

            return ret;
        }

        public string Report()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(string.Format("CPUs in the Computer {0}:", this.Model));
            foreach(var v in this.Multiprocessor)
            {
                ret.AppendLine(v.Value.ToString());
            }

            return ret.ToString().Trim();
        }

    }
}
