using System;

namespace _05._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {

            double nSpending = 0, nBudget = 0;
            string sDestination = "";

            sDestination = Console.ReadLine();

            while (sDestination != "End")
            {

                nBudget = double.Parse(Console.ReadLine());
                nSpending = 0;

                while (nSpending < nBudget)
                {
                    nSpending += double.Parse(Console.ReadLine());
                }

                Console.WriteLine($"Going to {sDestination}!");

                sDestination = Console.ReadLine();

            }

        }
    }
}
