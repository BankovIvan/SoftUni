using System;

namespace _12._Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {

            string sCityIn;
            double dSalesIn, dBrokerage;

            sCityIn = Console.ReadLine();
            dSalesIn = double.Parse(Console.ReadLine());
            dBrokerage = -1.0;

            if(sCityIn == "Sofia" && dSalesIn >= 0.0  && dSalesIn <= 500.0)
            {
                dBrokerage = 0.05;
            }
            else if (sCityIn == "Sofia" && dSalesIn > 500.0 && dSalesIn <= 1000.0)
            {
                dBrokerage = 0.07;
            }
            else if (sCityIn == "Sofia" && dSalesIn > 1000.0 && dSalesIn <= 10000.0)
            {
                dBrokerage = 0.08;
            }
            else if (sCityIn == "Sofia" && dSalesIn > 10000.0)
            {
                dBrokerage = 0.12;
            }
            else if (sCityIn == "Varna" && dSalesIn >= 0.0 && dSalesIn <= 500.0)
            {
                dBrokerage = 0.045;
            }
            else if (sCityIn == "Varna" && dSalesIn > 500.0 && dSalesIn <= 1000.0)
            {
                dBrokerage = 0.075;
            }
            else if (sCityIn == "Varna" && dSalesIn > 1000.0 && dSalesIn <= 10000.0)
            {
                dBrokerage = 0.10;
            }
            else if (sCityIn == "Varna" && dSalesIn > 10000.0)
            {
                dBrokerage = 0.13;
            }
            else if (sCityIn == "Plovdiv" && dSalesIn >= 0.0 && dSalesIn <= 500.0)
            {
                dBrokerage = 0.055;
            }
            else if (sCityIn == "Plovdiv" && dSalesIn > 500.0 && dSalesIn <= 1000.0)
            {
                dBrokerage = 0.08;
            }
            else if (sCityIn == "Plovdiv" && dSalesIn > 1000.0 && dSalesIn <= 10000.0)
            {
                dBrokerage = 0.12;
            }
            else if (sCityIn == "Plovdiv" && dSalesIn > 10000.0)
            {
                dBrokerage = 0.145;
            }

            if (dBrokerage >= 0.0)
            {
                dBrokerage = dSalesIn * dBrokerage;
                Console.WriteLine("{0:F2}", dBrokerage);
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}
