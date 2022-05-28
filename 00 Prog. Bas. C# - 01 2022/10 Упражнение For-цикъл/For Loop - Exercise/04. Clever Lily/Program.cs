using System;

namespace _04._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, nAgeIn = 0, nToyPriceIn = 0;
            double dWashPriceIn = 0.0, dCashSum=0.0, dDelta=0.0;

            nAgeIn = int.Parse(Console.ReadLine());
            dWashPriceIn = double.Parse(Console.ReadLine());
            nToyPriceIn = int.Parse(Console.ReadLine());

            for(i=1; i<=nAgeIn; i++)
            {
                if((i & 1) == 1)
                {
                    dCashSum += (double)nToyPriceIn;
                }
                else
                {
                    dCashSum += (double)((i*5)-1);
                }
            }

            dDelta = dCashSum - dWashPriceIn;

            if (dDelta >= 0.0)
            {
                Console.WriteLine("Yes! {0:F2}", dDelta);
            }
            else
            {
                dDelta *= -1;
                Console.WriteLine("No! {0:F2}", dDelta);
            }


        }
    }
}
