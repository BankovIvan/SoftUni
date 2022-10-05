namespace _07_Raw_Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CargoClass
    {
        private string type;
        private int weight;

        public string Type { get { return type; } set { type = value; } }
        public int Weight { get { return weight; } set { weight = value; } }

        public CargoClass(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }   

    }
}
