namespace _07_Raw_Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EngineClass
    {
        private int speed;
        private int power;

        public int Speed { get { return speed; } set { speed = value; } }
        public int Power { get { return power; } set { power = value; } }

        public EngineClass(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }   


    }
}
