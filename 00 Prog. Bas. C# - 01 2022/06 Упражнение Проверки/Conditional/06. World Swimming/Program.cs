using System;

namespace _06._World_Swimming
{
    class Program
    {
        static void Main(string[] args)
        {

            double dWorldRecord, dTotalDistance, dTimePerMetre, dDelayTime, dTotalTime;

            dWorldRecord = double.Parse(Console.ReadLine());
            dTotalDistance = double.Parse(Console.ReadLine());
            dTimePerMetre = double.Parse(Console.ReadLine());

            dDelayTime = Math.Floor(dTotalDistance / 15.0) * 12.5;

            dTotalTime = dTotalDistance * dTimePerMetre + dDelayTime;

            if(dTotalTime < dWorldRecord)
            {
                Console.WriteLine(" Yes, he succeeded! The new world record is {0:F2} seconds.", dTotalTime);
            }
            else
            {
                Console.WriteLine("No, he failed! He was {0:F2} seconds slower.", dTotalTime - dWorldRecord);
            }

        }
    }
}
