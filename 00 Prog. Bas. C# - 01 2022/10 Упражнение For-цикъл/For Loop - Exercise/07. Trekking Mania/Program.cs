using System;

namespace _07._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, nGroups = 0, nTourists = 0 ,nK1 = 0, nK2 = 0, nK3 = 0, nK4 = 0, nK5 = 0;
            double  dTotal = 0.0;

            nGroups = int.Parse(Console.ReadLine());

            for(i=0; i<nGroups; i++)
            {
                nTourists = int.Parse(Console.ReadLine());

                if(nTourists <= 5)
                {
                    nK1 += nTourists;
                }
                else if (nTourists <= 12)
                {
                    nK2 += nTourists;
                }
                else if (nTourists <= 25)
                {
                    nK3 += nTourists;
                }
                else if (nTourists <= 40)
                {
                    nK4 += nTourists;
                }
                else
                {
                    nK5 += nTourists;
                }

            }

            dTotal = (double)(nK1 + nK2 + nK3 + nK4 + nK5);

            Console.WriteLine("{0:F2}%", (double)(nK1 * 100) / dTotal);
            Console.WriteLine("{0:F2}%", (double)(nK2 * 100) / dTotal);
            Console.WriteLine("{0:F2}%", (double)(nK3 * 100) / dTotal);
            Console.WriteLine("{0:F2}%", (double)(nK4 * 100) / dTotal);
            Console.WriteLine("{0:F2}%", (double)(nK5 * 100) / dTotal);

        }
    }
}
