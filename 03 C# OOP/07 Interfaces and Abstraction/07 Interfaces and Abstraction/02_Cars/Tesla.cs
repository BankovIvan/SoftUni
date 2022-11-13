namespace Cars
{
    using System;

    public class Tesla : ICar, IElectricCar
    {
        public string Model { get; private set; }
        public string Color { get; private set; }
        public int Battery { get; private set; }

        public Tesla (string model, string color, int batteries)
        { 
            // TODO: Add Logic here 
            this.Model = model;
            this.Color = color;
            this.Battery = batteries;
        }

        public string Start(){
            return "Engine start";
        }

        public string Stop(){
            return "Breaaak!";
        }

        public override string ToString()
        {
            return string.Format("{0} Tesla {1} with {2} Batteries", this.Color, this.Model, this.Battery);
        }

    }
}