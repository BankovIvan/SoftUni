namespace _03_Shopping_Spree
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            string[] arrInput;
            Dictionary<string, Person> persons;
            Dictionary<string, Product> products; 

            try{
                persons = ReadPersons();
                products = ReadProducts();
            }
            catch(Exception e){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return;
            }

            while((arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries))[0] != "END"){
                string personName = arrInput[0];
                string productName = arrInput[1];

                if(!persons[personName].BuyProduct(products[productName])){
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("{0} can't afford {1}", personName, productName);
                    Console.ResetColor();
                }
                else{
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("{0} bought {1}", personName, productName);
                    Console.ResetColor();
                }

            }

            Console.ForegroundColor = ConsoleColor.Green;
            foreach(var v in persons){
                Console.WriteLine(v.Value.ToString());
            }
            Console.ResetColor();

        }

        public static Dictionary<string, Person> ReadPersons(){
            Dictionary<string, Person> persons = new Dictionary<string, Person>();

            string[] arrInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach(var v in arrInput){
                string[] arrData = v.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = arrData[0];
                decimal money = decimal.Parse(arrData[1]);

                persons.Add(name, new Person(name, money));
            }

            return persons;
        }

        public static Dictionary<string, Product> ReadProducts(){
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string[] arrInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach(var v in arrInput){
                string[] arrData = v.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = arrData[0];
                decimal cost = decimal.Parse(arrData[1]);

                products.Add(name, new Product(name, cost));
            }

            return products;
        }
    }
}
