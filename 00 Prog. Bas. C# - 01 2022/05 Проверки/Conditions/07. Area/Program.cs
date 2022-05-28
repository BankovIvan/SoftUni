using System;

namespace _07._Area
{
    class Program
    {
        static void Main(string[] args)
        {
            string sFigure;
            double dArea;

            sFigure = Console.ReadLine();
            dArea = 0.0;

            if(sFigure== "square")
            {
                double dSide;

                dSide = double.Parse(Console.ReadLine());

                dArea = dSide * dSide;

            }
            else if(sFigure == "rectangle")
            {
                double dSide1, dSide2;

                dSide1 = double.Parse(Console.ReadLine());
                dSide2 = double.Parse(Console.ReadLine());

                dArea = dSide1 * dSide2;
            }
            else if (sFigure == "circle")
            {
                double dRadius;

                dRadius = double.Parse(Console.ReadLine());

                dArea = Math.PI * dRadius * dRadius;
            }
            else if (sFigure == "triangle")
            {
                double dSide, dHeight;

                dSide = double.Parse(Console.ReadLine());
                dHeight = double.Parse(Console.ReadLine());

                dArea = dSide * dHeight / 2.0;
            }

            //dArea = Math.Round(dArea, 3);
            Console.WriteLine("{0:F3}", dArea);

        }
    }
}
