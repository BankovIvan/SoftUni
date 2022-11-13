namespace _04_Pizza_Calories
{
    using System;
    using System.Collections.Generic;

    public class Topping
    {
        private static readonly Dictionary<string, double> TOPPING_TYPES = 
            new Dictionary<string, double>( new KeyValuePair<string, double>[] {
                new KeyValuePair<string, double>("MEAT", 1.2), 
                new KeyValuePair<string, double>("VEGGIES", 0.8), 
                new KeyValuePair<string, double>("CHEESE", 1.1),
                new KeyValuePair<string, double>("SAUCE", 0.9)
             } );

        private string toppingType;
        private static readonly double BaseCalories = 2.0;
        private double modifier;
        private double weight;

        private string ToppingType {
            get { return this.toppingType; }
            set {
                string topp = value.ToUpper();
                if(!TOPPING_TYPES.ContainsKey(topp)){
                    throw new ArgumentException(
                        String.Format("Cannot place {0} on top of your pizza.", value));
                }
                this.toppingType = value;
                this.Modifier = TOPPING_TYPES[topp];
            }
        }

        private double Modifier {
            get { return this.modifier; }
            set { this.modifier = value; }
        }

        private double Weight {
            get { return this.weight; }
            set{
                if(value < 1.0 || value > 50.0){
                    throw new ArgumentException(
                        String.Format("{0} weight should be in the range [1..50].", this.ToppingType));
                }
                this.weight = value;
            }
        }

        public double TotalCalories(){
            double ret = 0.0;

            ret = BaseCalories * this.Weight * this.Modifier;

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

        public Topping(string toppingType, double weight){
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

    }
}