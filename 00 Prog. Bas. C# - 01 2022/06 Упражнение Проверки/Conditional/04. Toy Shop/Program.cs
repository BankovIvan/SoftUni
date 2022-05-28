using System;

namespace _04._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            double dTripPrice, dOrderPrice, dDifference;
            int nPuzles, nDolls, nTedys, nMinions, nTrucks;

            dTripPrice = double.Parse(Console.ReadLine());

            nPuzles = int.Parse(Console.ReadLine());
            nDolls = int.Parse(Console.ReadLine());
            nTedys = int.Parse(Console.ReadLine());
            nMinions = int.Parse(Console.ReadLine());
            nTrucks = int.Parse(Console.ReadLine());

            dOrderPrice = 0;
            dDifference = 0;

            dOrderPrice += ((double) nPuzles) * 2.60;
            dOrderPrice += ((double) nDolls) * 3.00;
            dOrderPrice += ((double) nTedys) * 4.10;
            dOrderPrice += ((double) nMinions) * 8.20;
            dOrderPrice += ((double) nTrucks) * 2.00;

            if(nPuzles + nDolls + nTedys + nMinions + nTrucks >= 50)
            {
                dOrderPrice = dOrderPrice * 0.75;
            }

            dOrderPrice = dOrderPrice * 0.90;

            dDifference = dOrderPrice - dTripPrice;

            if(dDifference >= 0)
            {
                Console.WriteLine("Yes! {0:F2} lv left.", dDifference);
            }
            else
            {
                dDifference *= -1;
                Console.WriteLine("Not enough money! {0:F2} lv needed.", dDifference);
            }

        }
    }
}
