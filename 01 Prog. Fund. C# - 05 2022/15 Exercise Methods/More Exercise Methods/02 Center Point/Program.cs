using System;

namespace _02_Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            double dX1, dY1, dX2, dY2, dDistance1, dDistance2;

            dX1 = double.Parse(Console.ReadLine());
            dY1 = double.Parse(Console.ReadLine());
            dX2 = double.Parse(Console.ReadLine());
            dY2 = double.Parse(Console.ReadLine());

            dDistance1 = GetCartesianDistanceFromCenter(dX1, dY1);
            dDistance2 = GetCartesianDistanceFromCenter(dX2, dY2);

            if (dDistance1 > dDistance2)
            {
                Console.WriteLine("({0}, {1})", dX2, dY2);
            }
            else
            {
                Console.WriteLine("({0}, {1})", dX1, dY1);
            }

        }

        private static double GetCartesianDistanceFromCenter(double dX1, double dY1)
        {
            double dRet = 0.00;

            dRet = Math.Sqrt(dX1* dX1 + dY1* dY1);

            return dRet;
        }
    }
}
