using System;

namespace _09._Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {

            double dArea, dPrice, dDiscount;

            dArea = double.Parse(Console.ReadLine());

            dPrice = dArea * 7.61;
            dDiscount = dPrice * 0.18;

            Console.WriteLine("The final price is: {0}.", dPrice - dDiscount);
            Console.WriteLine("The discount is: {0}.", dDiscount);
        }
    }
}
