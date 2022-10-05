namespace _08_Car_Salesman
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EngineClass
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public string Model { get { return model; } set { model = value; } }
        public int Power { get { return power; } set { power = value; } }
        public int Displacement { get { return displacement; } set { displacement = value; } }  
        public string Efficiency { get { return efficiency; } set { efficiency = value; } }

        public EngineClass()
        {
            Displacement = -1;
            Efficiency = "n/a";
            Model = null;
            Power = -1;
        }

        public EngineClass(string model, int power) : this()
        {
            Model = model;
            Power = power;
        }
        
        public EngineClass(string model, int power, int displacement, string efficiency) : this(model, power)
        {
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public EngineClass(string model, int power, string displacement, string efficiency) : this(model, power)
        {
            Displacement = int.Parse(displacement);
            Efficiency = efficiency;
        }

        public EngineClass(string model, int power, string param3) : this(model, power)
        {
            int displ = 0;
            if (int.TryParse(param3, out displ))
            {
                Displacement = displ;
            }
            else
            {
                Efficiency = param3;
            }
            
        }

        public override string ToString()
        {
            string ret = string.Format("  {0}:\n", this.Model);

            ret += string.Format("    Power: {0}\n", this.Power);

            if(Displacement >= 0)
            {
                ret += string.Format("    Displacement: {0}\n", this.Displacement);
            }
            else
            {
                ret += string.Format("    Displacement: n/a\n");
            }

            ret += string.Format("    Efficiency: {0}", this.Efficiency);

            return ret;

        }

    }
}
