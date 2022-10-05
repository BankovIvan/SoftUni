namespace _07_Raw_Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TireClass
    {
        private int age;
        private double pressure;

        public int Age { get { return age; } set { age = value; } }
        public double Pressure { get { return pressure; } set { pressure = value; } }   

        public TireClass()
        {
            this.Age = 0;
            this.Pressure = 0.0;
        }

        public TireClass(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }   
    }
}
