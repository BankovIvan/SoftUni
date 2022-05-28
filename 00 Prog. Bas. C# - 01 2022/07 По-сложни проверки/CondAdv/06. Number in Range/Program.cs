using System;

namespace _06._Number_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {

            double dNumber;

            dNumber = double.Parse(Console.ReadLine());

            if(dNumber >= -100.0 && dNumber <= 100.0 && dNumber != 0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }



        }
    }
}
