using System;

namespace _07_Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nBatches, nQuantity, nTotal;

            nBatches = int.Parse(Console.ReadLine());
            nTotal = 0;

            for(i = 0; i < nBatches; i++)
            {
                nQuantity = int.Parse(Console.ReadLine());

                if((nTotal + nQuantity) > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    nTotal += nQuantity;
                }

            }

            Console.WriteLine(nTotal);

        }
    }
}
