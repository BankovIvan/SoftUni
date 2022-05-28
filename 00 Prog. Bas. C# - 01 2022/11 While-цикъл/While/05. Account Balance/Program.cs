using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {

            double dTotal = 0.0, dMoneyIn = 0.0;
            string sMoney = "";

            sMoney = Console.ReadLine();

            while (sMoney!= "NoMoreMoney")
            {
                dMoneyIn = double.Parse(sMoney);

                if(dMoneyIn < 0.0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                Console.WriteLine("Increase: {0:F2}", dMoneyIn);
                dTotal += dMoneyIn;
                sMoney = Console.ReadLine();

            }

            Console.WriteLine("Total: {0:F2}", dTotal);

        }
    }
}
