using System;

namespace _08._Aquarium
{
    class Program
    {
        static void Main(string[] args)
        {

            double dLength, dWidth, dHeight, dFill, dTotal;

            dLength = (double)int.Parse(Console.ReadLine());
            dWidth = (double)int.Parse(Console.ReadLine());
            dHeight = (double)int.Parse(Console.ReadLine());
            dFill = double.Parse(Console.ReadLine());

            dLength *= 0.1;
            dWidth *= 0.1;
            dHeight *= 0.1;
            dFill = 1 - (dFill / 100.0);

            dTotal = dLength * dWidth * dHeight * dFill;

            Console.WriteLine(dTotal);

        }
    }
}
