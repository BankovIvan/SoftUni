using System;

namespace _03_Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double dCurrentBalance, dStartBalance, dGamePrice;
            string sCommandIn;

            dCurrentBalance = double.Parse(Console.ReadLine());
            dStartBalance = dCurrentBalance;
            dGamePrice = 0.0;

            sCommandIn = Console.ReadLine();

            while(sCommandIn != "Game Time")
            {
                if (sCommandIn == "OutFall 4")
                {
                    dGamePrice = 39.99;
                }
                else if (sCommandIn == "CS: OG")
                {
                    dGamePrice = 15.99;
                }
                else if (sCommandIn == "Zplinter Zell")
                {
                    dGamePrice = 19.99;
                }
                else if (sCommandIn == "Honored 2")
                {
                    dGamePrice = 59.99;
                }
                else if (sCommandIn == "RoverWatch")
                {
                    dGamePrice = 29.99;
                }
                else if (sCommandIn == "RoverWatch Origins Edition")
                {
                    dGamePrice = 39.99;
                }
                else
                {
                    Console.WriteLine("Not Found");
                    sCommandIn = Console.ReadLine();
                    continue;
                }

                if (dCurrentBalance < dGamePrice)
                {
                    Console.WriteLine("Too Expensive");
                    //continue;
                }
                else
                {
                    dCurrentBalance -= dGamePrice;
                    Console.WriteLine("Bought " + sCommandIn);

                    if (dCurrentBalance <= 0.0)
                    {
                        Console.WriteLine("Out of money!");
                        return;
                    }

                }

                sCommandIn = Console.ReadLine();

            }

            Console.WriteLine("Total spent: ${0:F2}. Remaining: ${1:F2}", (dStartBalance - dCurrentBalance), dCurrentBalance);

        }
    }
}
