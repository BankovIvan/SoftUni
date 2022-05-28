using System;

namespace _2_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            double radians, degrees;

            radians = double.Parse(Console.ReadLine());
            degrees = radians * 180.0 / Math.PI;

            Console.WriteLine(degrees);


        }
    }
}
