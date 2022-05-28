using System;

namespace _03._New_House
{
    class Program
    {
        static void Main(string[] args)
        {

            string sFlowersIn;
            int nFlowersNum, nBudgetIn;
            double dPrice;

            sFlowersIn = Console.ReadLine();
            nFlowersNum = int.Parse(Console.ReadLine());
            nBudgetIn = int.Parse(Console.ReadLine());

            switch (sFlowersIn)
            {
                case "Roses":

                    dPrice = 5.0;
                    if (nFlowersNum > 80)
                    {
                        dPrice *= 0.9;
                    }

                    break;

                case "Dahlias":

                    dPrice = 3.8;
                    if (nFlowersNum > 90)
                    {
                        dPrice *= 0.85;
                    }

                    break;

                case "Tulips":

                    dPrice = 2.8;
                    if (nFlowersNum > 80)
                    {
                        dPrice *= 0.85;
                    }

                    break;

                case "Narcissus":

                    dPrice = 3.0;
                    if (nFlowersNum < 120)
                    {
                        dPrice *= 1.15;
                    }

                    break;

                case "Gladiolus":

                    dPrice = 2.5;
                    if (nFlowersNum < 80)
                    {
                        dPrice *= 1.20;
                    }

                    break;

                default:

                    dPrice = 0.0;
                    break;
            }

            dPrice *= nFlowersNum;

            dPrice = (double)nBudgetIn - dPrice;

            if(dPrice >= 0)
            {
                Console.WriteLine("Hey, you have a great garden with {0} {1} and {2:F2} leva left.", nFlowersNum, sFlowersIn, dPrice);
            }
            else
            {
                dPrice = Math.Abs(dPrice);
                Console.WriteLine("Not enough money, you need {0:F2} leva more.", dPrice);
            }

        }
    }
}
