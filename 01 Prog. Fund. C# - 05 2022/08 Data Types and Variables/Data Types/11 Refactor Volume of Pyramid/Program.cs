using System;

namespace _11_Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Length: ");

            double dLength;
            dLength = double.Parse(Console.ReadLine());

            Console.Write("Width: ");

            double dWidth;
            dWidth = double.Parse(Console.ReadLine());

            Console.Write("Height: ");

            double dHeigh;
            dHeigh = double.Parse(Console.ReadLine());

            double dVolume;
            dVolume = (dLength * dWidth * dHeigh) / 3;

            Console.WriteLine($"Pyramid Volume: {dVolume:f2}");

        }
    }
}
