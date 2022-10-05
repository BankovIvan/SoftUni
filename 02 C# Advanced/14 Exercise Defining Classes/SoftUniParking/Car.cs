namespace SoftUniParking
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        public string Make { get { return make; } set { make = value; } }   
        public string Model { get { return model; } set { model = value; } }    
        public int HorsePower { get { return horsePower; } set { horsePower = value; } }
        public string RegistrationNumber { get { return registrationNumber; } set { registrationNumber = value; } } 

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;

        }

        public override string ToString()
        {
            string ret = string.Format("Make: {0}\n", this.Make);

            ret += string.Format("Model: {0}\n", this.Model);

            ret += string.Format("HorsePower: {0}\n", this.HorsePower);

            ret += string.Format("RegistrationNumber: {0}", this.RegistrationNumber);

            return ret;

        }
    }
}
