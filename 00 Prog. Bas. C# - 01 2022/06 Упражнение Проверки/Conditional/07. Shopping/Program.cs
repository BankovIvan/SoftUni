using System;

namespace _07._Shopping
{
    class Program
    {
        static void Main(string[] args)
        {

            int nCPUs, nGPUs, nRAMs;
            double dCPUPrice, dGPUPrice, dRAMPrice, dBudget, dTotal, dDelta;

            dBudget = double.Parse(Console.ReadLine());
            nGPUs = int.Parse(Console.ReadLine());
            nCPUs = int.Parse(Console.ReadLine());
            nRAMs = int.Parse(Console.ReadLine());

            dGPUPrice = (double)nGPUs * 250.0;
            dCPUPrice = (double)nCPUs * dGPUPrice * 0.35;
            dRAMPrice = (double)nRAMs * dGPUPrice * 0.10;

            dTotal = dGPUPrice + dCPUPrice + dRAMPrice;

            if(nGPUs > nCPUs)
            {
                dTotal *= 0.85;
            }

            dDelta = dTotal - dBudget;

            if(dDelta > 0)
            {
                Console.WriteLine("Not enough money! You need {0:F2} leva more!", dDelta);
            }
            else
            {
                dDelta = Math.Abs(dDelta);
                Console.WriteLine("You have {0:F2} leva left!", dDelta);
            }

        }
    }
}
