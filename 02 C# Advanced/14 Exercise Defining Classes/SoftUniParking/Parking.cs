namespace SoftUniParking
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class Parking
    {
        private int capacity;

        public List<Car> Cars { get; set; }
        public int Count { get { return Cars.Count; } }

        public Parking(int capacity)
        {
            this.capacity = capacity;
            Cars = new List<Car>();
        }

        public string AddCar(Car Car)
        {
            string ret = "";

            if(this.Cars.Exists(x => x.RegistrationNumber == Car.RegistrationNumber))
            {
                ret = "Car with that registration number, already exists!";
                return ret;
            }

            if (this.Cars.Count >= this.capacity)
            {
                ret = "Parking is full!";
                return ret;
            }

            this.Cars.Add(Car);
            ret = String.Format("Successfully added new car {0} {1}", Car.Make, Car.RegistrationNumber);
            return ret;

        }

        public string RemoveCar(string RegistrationNumber)
        {
            string ret = "";

            if (!this.Cars.Exists(x => x.RegistrationNumber == RegistrationNumber))
            {
                ret = "Car with that registration number, doesn't exist!";
                return ret;
            }

            this.Cars.RemoveAt(this.Cars.FindIndex(x => x.RegistrationNumber == RegistrationNumber));
            ret = String.Format("Successfully removed {0}", RegistrationNumber);
            return ret;

        }

        public Car GetCar(string RegistrationNumber)
        {
            Car ret = this.Cars.Find(x => x.RegistrationNumber == RegistrationNumber);

            return ret;

        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            this.Cars.RemoveAll(x => RegistrationNumbers.Contains(x.RegistrationNumber));
        }
    }
}
