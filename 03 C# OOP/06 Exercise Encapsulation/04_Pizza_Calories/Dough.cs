namespace _04_Pizza_Calories
{
    using System;
    using System.Collections.Generic;

    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;
        private static readonly double MODIFIER = 2.0; 

        private static readonly Dictionary<string, double> DOUGH_TYPE = 
            new Dictionary<string, double>( new KeyValuePair<string, double>[] {
                new KeyValuePair<string, double>("WHITE", 1.5), 
                new KeyValuePair<string, double>("WHOLEGRAIN", 1.0) 
             } );

        private static readonly Dictionary<string, double> DOUGH_TECHNIQUE = 
            new Dictionary<string, double>( new KeyValuePair<string, double>[] {
                new KeyValuePair<string, double>("CRISPY", 0.9), 
                new KeyValuePair<string, double>("CHEWY", 1.1),
                new KeyValuePair<string, double>("HOMEMADE", 1.0)
            } );

        private string FlourType {
            get { return this.flourType; }
            set {
                string flour = value.ToUpper();
                if(!DOUGH_TYPE.ContainsKey(flour)){
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = flour;
            }
        }

        private string BakingTechnique {
            get { return this.bakingTechnique; }
            set {
                string baking = value.ToUpper();
                if(!DOUGH_TECHNIQUE.ContainsKey(baking)){
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = baking;
            }
        }

        private double Weight {
            get { return this.weight; }
            set {
                if(value < 1.0 || value > 200.0 ){
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double TotalCalories(){
            double ret = 0.0;

            ret = MODIFIER * this.Weight * DOUGH_TYPE[this.FlourType] * DOUGH_TECHNIQUE[this.BakingTechnique];

            return ret;
        }

        public double CaloriesPerGram {
            get {
                return TotalCalories() / this.Weight;
            }
        }

        public override string ToString()
        {
            return string.Format("{0:F2}", TotalCalories());
        }

        public Dough(string flourType, string bakingTechnique, double weight){
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

    }
}