using System;

namespace _01._Fruit_Market
{
    class Program
    {
        static void Main(string[] args)
        {

            double dStrawberriesPrice = 0.0;
            double dTotalPrice = 0.0;
            //double dBananaPrice = 0.0;
            //double dOrangeAmount = 0.0;
            //double dRaspberriesAmount = 0.0;
            //double dStrawberriesAmount = 0.0;

            dStrawberriesPrice = double.Parse(Console.ReadLine());
            dTotalPrice = double.Parse(Console.ReadLine()) * (dStrawberriesPrice * 0.5) * 0.2; //Bananas
            dTotalPrice += double.Parse(Console.ReadLine()) * (dStrawberriesPrice * 0.5) * 0.6; //Oranges
            dTotalPrice += double.Parse(Console.ReadLine()) * dStrawberriesPrice * 0.5; //Raspberries
            dTotalPrice += double.Parse(Console.ReadLine()) * dStrawberriesPrice; //Strawberries

            Console.WriteLine("{0:F2}", dTotalPrice);

        }
    }
}
