namespace _08_Car_Salesman
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    public class CarClass
    {
        private string model;
        private int weight;
        private string color;

        public string Model { get { return model; } set { model = value; } }
        public int Weight { get { return weight; } set { weight = value; } }
        public string Color { get { return color; } set { color = value; } }

        public EngineClass Engine { get; set; }

        public CarClass()
        {
            Weight = -1;
            Color = "n/a";
            Model = null;
            Engine = null;
        }

        public CarClass(string model, EngineClass engine) : this()
        {
            Model = model;
            Engine = engine;
        }

        public CarClass(string model, EngineClass engine, int weight, string color) : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }

        public CarClass(string model, EngineClass engine, string weight, string color) : this(model, engine)
        {
            Weight = int.Parse(weight);
            Color = color;
        }

        public CarClass(string model, EngineClass engine, string param3) : this(model, engine)
        {
            int wght = 0;

            if(int.TryParse(param3, out wght))
            {
                Weight = wght;
            }
            else
            {
                Color = param3;
            }
        }


        public override string ToString()
        {
            string ret = string.Format("{0}:\n", this.Model);

            ret += string.Format("{0}\n", this.Engine.ToString());

            if(this.Weight >= 0)
            {
                ret += string.Format("  Weight: {0}\n", this.Weight);
            }
            else
            {
                ret += string.Format("  Weight: n/a\n");
            }

            ret += string.Format("  Color: {0}", this.Color);

            return ret;
        }

    }
}
