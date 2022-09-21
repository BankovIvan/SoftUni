using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> dicShops = new Dictionary<string, Dictionary<string, double>>();
            string[] arrInput;

            while (true)
            {
                arrInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if(arrInput[0] == "Revision")
                {
                    break;
                }

                if (!dicShops.ContainsKey(arrInput[0]))
                {
                    dicShops.Add(arrInput[0], new Dictionary<string, double>());
                }

                dicShops[arrInput[0]].Add(arrInput[1], double.Parse(arrInput[2]));

            }

            foreach(var v in dicShops.OrderBy(x => x.Key))
            {
                Console.WriteLine("{0}->", v.Key);
                foreach(var w in v.Value)
                {
                    Console.WriteLine("Product: {0}, Price: {1}", w.Key, w.Value);
                }
            }


        }
    }
}
