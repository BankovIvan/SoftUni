using System;
using System.Numerics;

namespace _11_Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, N, 
                nSnowballSnowCurrent, nSnowballSnowMax , 
                nSnowballTimeCurrent, nSnowballTimeMax, 
                nSnowballQualityCurrent, nSnowballQualityMax;

            BigInteger nSnowballValueCurrent, nSnowballValueMax;

            N = int.Parse(Console.ReadLine());
            nSnowballValueMax = 0;
            nSnowballSnowMax = 0;
            nSnowballTimeMax = 0;
            nSnowballQualityMax = 0;

            for (i = 0; i < N; i++)
            {
                nSnowballSnowCurrent = int.Parse(Console.ReadLine());
                nSnowballTimeCurrent = int.Parse(Console.ReadLine());
                nSnowballQualityCurrent = int.Parse(Console.ReadLine());

                //nSnowballValueCurrent = (nSnowballSnowCurrent / nSnowballTimeCurrent) ^ nSnowballQualityCurrent;

                nSnowballValueCurrent = BigInteger.Pow((nSnowballSnowCurrent / nSnowballTimeCurrent), nSnowballQualityCurrent);

                if(nSnowballValueCurrent > nSnowballValueMax)
                {
                    nSnowballValueMax = nSnowballValueCurrent;
                    nSnowballSnowMax = nSnowballSnowCurrent;
                    nSnowballTimeMax = nSnowballTimeCurrent;
                    nSnowballQualityMax = nSnowballQualityCurrent;

                }

            }

            Console.WriteLine("{0} : {1} = {2} ({3})", 
                                nSnowballSnowMax, nSnowballTimeMax, nSnowballValueMax, nSnowballQualityMax);

        }
    }
}
