using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        private string brand;
        private int cores;
        private double frequency;

        public string Brand { get { return brand; } set { brand = value; } }
        public int Cores { get { return cores; } set { cores = value; } }
        public double Frequency { get { return frequency; } set { frequency = value; } }

        public CPU(string brand, int cores, double frequency)
        {
            this.Brand = brand;
            this.Cores = cores;
            this.Frequency = frequency;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(string.Format("{0} CPU:", this.Brand));
            ret.AppendLine(string.Format("Cores: {0}", this.Cores));
            ret.AppendLine(string.Format("Frequency: {0:F1} GHz", this.Frequency));

            return ret.ToString().Trim();
        }

    }
}
