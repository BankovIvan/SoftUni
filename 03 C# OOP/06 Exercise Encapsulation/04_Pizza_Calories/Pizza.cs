namespace _04_Pizza_Calories
{
    using System;
    using System.Collections.Generic;

    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public string Name {
            get { return this.name; }
            private set {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15){
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough {
            get { return this.dough; }
            set {
                dough  = value;
            }
        }

        private List<Topping> Toppings {
            get { return this.toppings; }
            set { this.toppings = value; }
        }

        public double TotalCalories {
            get {
                double ret = this.Dough.TotalCalories();

                foreach(var v in this.Toppings){
                    ret += v.TotalCalories();
                }

                return ret;
            }
        }

        public Pizza(string name){
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

        public Pizza(string name, Dough dough){
            this.Name = name;
            this.Dough = dough;
            this.Toppings = new List<Topping>();
        }

        public void AddTopping(Topping topping){
            if(this.Toppings.Count >= 10){
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.Toppings.Add(topping);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1:F2} Calories.", this.Name, this.TotalCalories);
        }

    }
}