namespace Formula1.Models
{
    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Pilot : IPilot
    {
        private const int PILOT_NAME_MIN_LENGTH = 5;

        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins;
        private bool canRace;

        public string FullName
        {
            get { return fullName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < PILOT_NAME_MIN_LENGTH)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPilot, value));
                }
                this.fullName = value; 
            }
        }

        public IFormulaOneCar Car
        {
            get { return car; }
            private set 
            { 
                if(value == null)
                {
                    throw new NullReferenceException(String.Format(ExceptionMessages.InvalidCarForPilot, value));
                }
                this.car = value; 
            }
        }

        public int NumberOfWins
        {
            get { return numberOfWins; }
            private set
            {
                this.numberOfWins = value;
            }
        }

        public bool CanRace
        {
            get { return canRace; }
            private set
            {
                this.canRace = value;
            }
        }

        private Pilot()
        {
            this.CanRace = false;
            this.car = null;
        }

        public Pilot(string fullName) : this()
        {
            this.FullName = fullName;
            this.NumberOfWins = 0;
        }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("Pilot {0} has {1} wins.", this.FullName, this.NumberOfWins));

            return ret.ToString().Trim();
        }
    }
}
