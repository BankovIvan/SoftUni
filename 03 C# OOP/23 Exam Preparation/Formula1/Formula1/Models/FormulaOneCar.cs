namespace Formula1.Models
{
    using Formula1.Core;
    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private const int MODEL_NAME_MIN_LENGTH = 3;
        private const int HORSEPOWER_NAME_MIN_VALUE = 900;
        private const int HORSEPOWER_NAME_MAX_VALUE = 1050;
        private const double ENGINE_NAME_MIN_VALUE = 1.6;
        private const double ENGINE_NAME_MAX_VALUE = 2.0;

        private string model;
        private int horsepower;
        private double engineDisplacement;

        public string Model 
        { 
            get { return this.model; } 
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MODEL_NAME_MIN_LENGTH)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1CarModel, value));
                }
                this.model = value; 
            } 
        }

        public int Horsepower 
        {
            get { return this.horsepower;}
            private set 
            { 
                if(value < HORSEPOWER_NAME_MIN_VALUE || value > HORSEPOWER_NAME_MAX_VALUE)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }
                this.horsepower = value; 
            }
        }

        public double EngineDisplacement
        {
            get { return this.engineDisplacement;}
            private set 
            {
                if (value < ENGINE_NAME_MIN_VALUE || value > ENGINE_NAME_MAX_VALUE)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }
                this.engineDisplacement = value; 
            }
        }

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.EngineDisplacement = engineDisplacement;
        }   

        public double RaceScoreCalculator(int laps)
        {
            return (this.EngineDisplacement / this.Horsepower) * laps;
        }
    }
}
