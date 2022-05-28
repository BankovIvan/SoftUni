using System;

namespace _04._Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {

            string sSeasonIn;
            int nFishersNum, nBudgetIn;
            double dPrice;

            nBudgetIn = int.Parse(Console.ReadLine());
            sSeasonIn = Console.ReadLine();
            nFishersNum = int.Parse(Console.ReadLine());

            switch (sSeasonIn)
            {
                case "Spring":

                    dPrice = 3000.0;
                    break;

                case "Summer":
                case "Autumn":

                    dPrice = 4200.0;
                    break;

                case "Winter":

                    dPrice = 2600.0;
                    break;

                default:

                    dPrice = 0.0;
                    break;
            }

            if(nFishersNum <= 6)
            {
                dPrice *= 0.9;
            }
            else if (nFishersNum <= 11)
            {
                dPrice *= 0.85;
            }
            else if (nFishersNum > 11)
            {
                dPrice *= 0.75;
            }

            //dPrice *= nFishersNum;

            if(sSeasonIn != "Autumn" && nFishersNum % 2 == 0)
            {
                dPrice *= 0.95;
            }

            dPrice = (double)nBudgetIn - dPrice;

            if (dPrice >= 0)
            {
                Console.WriteLine("Yes! You have {0:F2} leva left.", dPrice);
            }
            else
            {
                dPrice = Math.Abs(dPrice);
                Console.WriteLine("Not enough money! You need {0:F2} leva.", dPrice);
            }

        }
    }
}
