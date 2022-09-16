namespace _03_Orders
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Product{
        public string Name {get; set;}
        public double Price {get; set;}
        public int Quantity {get; set;}

        public Product(string Name, double Price, int Quantity){
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1:F2}", this.Name, (this.Price * this.Quantity));
        }

        public void UpdateProduct(double Price, int Quantity){
            this.Price = Price;
            this.Quantity += Quantity;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Product> dicProducts = new Dictionary<string, Product>();
            string[] arrInput;

            while(true){
                arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if(arrInput[0] == "buy"){
                    break;
                }

                if(! dicProducts.ContainsKey(arrInput[0])){
                    dicProducts.Add(arrInput[0], new Product(
                                                        arrInput[0], 
                                                        double.Parse(arrInput[1]), 
                                                        int.Parse(arrInput[2])
                                                        ));
                }else{
                    dicProducts[arrInput[0]].UpdateProduct(
                                                        double.Parse(arrInput[1]), 
                                                        int.Parse(arrInput[2])
                    );
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach(var v in dicProducts){
                Console.WriteLine(v.Value);
            }          
            Console.ResetColor();

        }
    }
}