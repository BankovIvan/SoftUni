using System;

namespace _04_Back_in_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int nHoursIn, nMinutesIn, nHoursOut, nMinutesOut;

            nHoursIn = int.Parse(Console.ReadLine());
            nMinutesIn = int.Parse(Console.ReadLine());

            nMinutesOut = nMinutesIn + 30;
            nHoursOut = nHoursIn;

            if(nMinutesOut >= 60)
            {
                nHoursOut++;
                nMinutesOut -= 60;

            }

            if (nHoursOut >= 24)
            {
                nHoursOut -= 24;

            }

            Console.WriteLine("{0}:{1:D2}", nHoursOut, nMinutesOut);

        }
    }
}
