using System;

namespace _06._Repainting
{
    class Program
    {
        static void Main(string[] args)
        {

            double dNylon, dPaint, dSolvent, dHours, dExpences;

            dNylon = (double) int.Parse(Console.ReadLine());
            dPaint = (double) int.Parse(Console.ReadLine());
            dSolvent = (double) int.Parse(Console.ReadLine());
            dHours = (double) int.Parse(Console.ReadLine());

            //Price:
            dNylon = (dNylon + 2) * 1.50;
            dPaint = ((dPaint * 0.1) + dPaint) * 14.50;
            dSolvent = dSolvent * 5.00;

            dExpences = dNylon + dPaint + dSolvent + 0.40;

            dHours = dExpences * 0.3 * 8;

            dExpences = dExpences + dHours;

            Console.WriteLine(dExpences);

        }
    }
}
