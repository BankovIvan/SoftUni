using System;

namespace _05._Coins
{
    class Program
    {
        static void Main(string[] args)
        {

            double dAmmount = 0.0;
            int nCoins = 0;

            dAmmount = double.Parse(Console.ReadLine());

            while(dAmmount > 0.0)
            {
                if(dAmmount >= 2.00)
                {
                    dAmmount -= 2.00;
                }
                else if (dAmmount >= 1.00)
                {
                    dAmmount -= 1.00;
                }
                else if (dAmmount >= 0.50)
                {
                    dAmmount = dAmmount - 0.50;
                }
                else if (dAmmount >= 0.20)
                {
                    dAmmount -= 0.20;
                }
                else if (dAmmount >= 0.10)
                {
                    dAmmount -= 0.10;
                }
                else if (dAmmount >= 0.05)
                {
                    dAmmount -= 0.05;
                }
                else if (dAmmount >= 0.02)
                {
                    dAmmount -= 0.02;
                }
                else
                {
                    dAmmount -= 0.01;
                }

                dAmmount = Math.Round(dAmmount, 2);
                nCoins++;

            }

            Console.WriteLine(nCoins);

        }
    }
}
