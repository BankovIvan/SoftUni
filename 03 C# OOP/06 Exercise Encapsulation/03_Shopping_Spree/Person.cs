namespace _03_Shopping_Spree
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public string Name {
            get {return name;}
            private set{
                if(string.IsNullOrWhiteSpace(value)){
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money {
            get { return this.money; }
            set {
                if(value < 0.0M){
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag { 
            get { return this.bag.AsReadOnly(); }
        }

        public Person(string name, decimal money){
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        private void AddProduct(Product product){
            this.bag.Add(product);
        }

        public bool BuyProduct(Product product){
            bool ret = false;

            decimal newMoney = this.Money - product.Cost;

            if(newMoney >= 0.0M){
                this.AddProduct(product);
                this.Money = newMoney;
                ret = true;
            }

            return ret;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            if(this.Bag.Count > 0){
                ret.AppendLine(String.Format("{0} - {1}", this.Name, string.Join(", ", this.Bag)));
            }
            else{
                ret.AppendLine(String.Format("{0} - {1}", this.Name, "Nothing bought"));
            }

            return ret.ToString().Trim();
        }

    }
}