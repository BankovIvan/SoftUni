using System;

namespace _11_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int nOrders, nDays, nCount;
            double dPrice, dTotalAll, dTotalDay;

            nOrders = int.Parse(Console.ReadLine());
            dTotalAll = 0.0;
            dTotalDay = 0.0;

            for ( ;nOrders > 0; nOrders--)
            {
                dPrice = double.Parse(Console.ReadLine());
                nDays = int.Parse(Console.ReadLine());
                nCount = int.Parse(Console.ReadLine());

                dTotalDay = dPrice * (double)(nDays * nCount);
                dTotalAll += dTotalDay;

                Console.WriteLine("The price for the coffee is: ${0:F2}", dTotalDay);

            }
            
            Console.WriteLine("Total: ${0:F2}", dTotalAll);

        }
    }
}
