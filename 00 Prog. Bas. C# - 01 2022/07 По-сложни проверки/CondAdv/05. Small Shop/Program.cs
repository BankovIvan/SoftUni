using System;

namespace _05._Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            string sProduct, sCity;
            double dQuantity, dPrice;

            sProduct = Console.ReadLine();
            sCity = Console.ReadLine();
            dQuantity = double.Parse(Console.ReadLine());

            switch (sProduct)
            {
                case "coffee":

                    if(sCity == "Sofia")
                    {
                        dPrice = 0.50 ;
                    }
                    else if(sCity == "Plovdiv")
                    {
                        dPrice = 0.40;
                    }
                    else
                    {
                        dPrice = 0.45;
                    }

                    break;

                case "water":

                    if (sCity == "Sofia")
                    {
                        dPrice = 0.80;
                    }
                    else if (sCity == "Plovdiv")
                    {
                        dPrice = 0.70;
                    }
                    else
                    {
                        dPrice = 0.70;
                    }

                    break;

                case "beer":

                    if (sCity == "Sofia")
                    {
                        dPrice = 1.20;
                    }
                    else if (sCity == "Plovdiv")
                    {
                        dPrice = 1.15;
                    }
                    else
                    {
                        dPrice = 1.10;
                    }

                    break;

                case "sweets" :

                    if (sCity == "Sofia")
                    {
                        dPrice = 1.45;
                    }
                    else if (sCity == "Plovdiv")
                    {
                        dPrice = 1.30;
                    }
                    else
                    {
                        dPrice = 1.35;
                    }

                    break;

                case "peanuts":

                    if (sCity == "Sofia")
                    {
                        dPrice = 1.60;
                    }
                    else if (sCity == "Plovdiv")
                    {
                        dPrice = 1.50;
                    }
                    else
                    {
                        dPrice = 1.55;
                    }

                    break;

                default:

                    dPrice = 0.0;
                    break;

            }

            Console.WriteLine(dQuantity * dPrice);
        }
    }
}
