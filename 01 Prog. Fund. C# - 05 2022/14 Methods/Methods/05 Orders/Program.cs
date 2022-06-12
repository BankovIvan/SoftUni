using System;

namespace _05_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string sProduct;
            int nQuantity;

            sProduct = Console.ReadLine();
            nQuantity = int.Parse(Console.ReadLine());

            Console.WriteLine("{0:F2}", MyPrintOrderPrice(sProduct, nQuantity));

        }

        private static double MyPrintOrderPrice(string sProduct, int nQuantity)
        {
            double dRet = 0.0;

            if(sProduct == "coffee")
            {
                dRet = (double)nQuantity * 1.50;
            }
            else if (sProduct == "water")
            {
                dRet = (double)nQuantity * 1.00;
            }
            else if (sProduct == "coke")
            {
                dRet = (double)nQuantity * 1.40;
            }
            else if (sProduct == "snacks")
            {
                dRet = (double)nQuantity * 2.00;
            }

            return dRet;

        }
    }
}
