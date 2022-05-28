using System;

namespace _05._Journey
{
    class Program
    {
        static void Main(string[] args)
        {

            string sSeasonIn, sCountry, sDestination;
            double dBudgetIn;
            double dPrice;

            dBudgetIn = double.Parse(Console.ReadLine());
            sSeasonIn = Console.ReadLine();
            dPrice = 0.0;
            sCountry = "";
            sDestination = "";

            if (dBudgetIn <= 100)
            {

                if (sSeasonIn == "summer")
                {
                    dPrice = dBudgetIn * 0.3;
                    sDestination = "Camp";
                }
                else
                {
                    dPrice = dBudgetIn * 0.7;
                    sDestination = "Hotel";
                }

                sCountry = "Bulgaria";
            }
            else if (dBudgetIn <= 1000)
            {

                if (sSeasonIn == "summer")
                {
                    dPrice = dBudgetIn * 0.4;
                    sDestination = "Camp";
                }
                else
                {
                    dPrice = dBudgetIn * 0.8;
                    sDestination = "Hotel";
                }

                sCountry = "Balkans";
            }
            else 
            { 
                    dPrice = dBudgetIn * 0.9;
                    sDestination = "Hotel";
                    sCountry = "Europe";
            }


            Console.WriteLine("Somewhere in {0}", sCountry);
            Console.WriteLine("{0} - {1:F2}", sDestination, dPrice);

        }
    }
}
