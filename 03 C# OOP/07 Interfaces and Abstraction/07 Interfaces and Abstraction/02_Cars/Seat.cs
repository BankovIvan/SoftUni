namespace Cars
{
    using System;

    public class Seat : ICar
    {
        public string Model { get; private set; }
        public string Color { get; private set; }

        public Seat (string model, string color)
        { 
            // TODO: Add Logic here 
            this.Model = model;
            this.Color = color;
        }

        public string Start(){
            return "Engine start";
        }

        public string Stop(){
            return "Breaaak!";
        }

        public override string ToString()
        {
            return string.Format("{0} Seat {1}", this.Color, this.Model);
        }

    }
}