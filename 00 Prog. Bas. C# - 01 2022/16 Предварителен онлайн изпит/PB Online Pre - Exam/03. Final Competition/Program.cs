using System;

namespace _03._Final_Competition
{
    class Program
    {
        static void Main(string[] args)
        {

            int nDancersAmount = 0;
            double dPointsAmount = 0.0, dMoneyAmount = 0.0;
            string sSeasonName = "", sPlaceName = "";

            nDancersAmount = int.Parse(Console.ReadLine());
            dPointsAmount = double.Parse(Console.ReadLine());
            sSeasonName = Console.ReadLine();
            sPlaceName = Console.ReadLine();

            dMoneyAmount = (double)nDancersAmount * dPointsAmount;

            if (sPlaceName == "Bulgaria")
            {
                if (sSeasonName == "summer")
                {
                    dMoneyAmount -= dMoneyAmount * 0.05;
                }
                else
                {
                    dMoneyAmount -= dMoneyAmount * 0.08;
                }

            }
            else
            {
                dMoneyAmount += dMoneyAmount * 0.50;

                if (sSeasonName == "summer")
                {
                    dMoneyAmount -= dMoneyAmount * 0.10;
                }
                else
                {
                    dMoneyAmount -= dMoneyAmount * 0.15;
                }

            }

            Console.WriteLine("Charity - {0:F2}", dMoneyAmount * 0.75);
            Console.WriteLine("Money per dancer - {0:F2}", dMoneyAmount * 0.25 / (double)nDancersAmount);

        }
    }
}
