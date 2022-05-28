using System;

namespace _08._Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            int nDogs, nCats;
            double dPrice;

            nDogs = int.Parse(Console.ReadLine());
            nCats = int.Parse(Console.ReadLine());

            dPrice = (double)nDogs * 2.50 + (double)nCats * 4.00;

            Console.WriteLine("{0} lv.", dPrice);
        }
    }
}
