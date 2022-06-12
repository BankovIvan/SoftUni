using System;

namespace _06_Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double dWidth, dHeight, dArea;

            dWidth = double.Parse(Console.ReadLine());
            dHeight = double.Parse(Console.ReadLine());

            dArea = MyCalcRectArea(dWidth, dHeight);

            Console.WriteLine(dArea);

        }

        private static double MyCalcRectArea(double dWidth, double dHeight)
        {
            return dWidth * dHeight;
        }
    }
}
