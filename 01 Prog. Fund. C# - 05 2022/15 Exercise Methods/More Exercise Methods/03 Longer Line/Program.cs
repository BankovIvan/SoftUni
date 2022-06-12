using System;

namespace _03_Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            double dX11, dY11, dX12, dY12, dX21, dY21, dX22, dY22, dDistance1, dDistance2, dLength1, dLength2;

            dX11 = double.Parse(Console.ReadLine());
            dY11 = double.Parse(Console.ReadLine());
            dX12 = double.Parse(Console.ReadLine());
            dY12 = double.Parse(Console.ReadLine());
            dX21 = double.Parse(Console.ReadLine());
            dY21 = double.Parse(Console.ReadLine());
            dX22 = double.Parse(Console.ReadLine());
            dY22 = double.Parse(Console.ReadLine());

            dLength1 = GetCartesianLineLength(dX11, dY11, dX12, dY12);
            dLength2 = GetCartesianLineLength(dX21, dY21, dX22, dY22);

            if(dLength1 >= dLength2)
            {
                dDistance1 = GetCartesianLineLength(dX11, dY11, 0, 0);
                dDistance2 = GetCartesianLineLength(0, 0, dX12, dY12);

                if(dDistance1 <= dDistance2)
                {
                    Console.WriteLine("({0}, {1})({2}, {3})", dX11, dX11, dX12, dY12);
                }
                else
                {
                    Console.WriteLine("({2}, {3})({0}, {1})", dX11, dX11, dX12, dY12);
                }

            }
            else
            {
                dDistance1 = GetCartesianLineLength(dX21, dY21, 0, 0);
                dDistance2 = GetCartesianLineLength(0, 0, dX22, dY22);

                if (dDistance1 <= dDistance2)
                {
                    Console.WriteLine("({0}, {1})({2}, {3})", dX21, dX21, dX22, dY22);
                }
                else
                {
                    Console.WriteLine("({2}, {3})({0}, {1})", dX21, dX21, dX22, dY22);
                }
            }


        }

        private static double GetCartesianLineLength(double dX11, double dY11, double dX12, double dY12)
        {
            double dRet = 0.00, ddX, ddY;

            ddX = dX12 - dX11;
            ddY = dY12 - dY11;

            dRet = Math.Sqrt(ddX * ddX + ddY * ddY);

            return dRet;

        }

    }
}
