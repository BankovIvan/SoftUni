using System;

namespace _09_Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
           
            long nDays, nSpices, nTotal;

            nSpices = long.Parse(Console.ReadLine());
            nDays = 0;
            nTotal = 0;

            for(; nSpices >= 100; nSpices -= 10)
            {
                nTotal += nSpices;
                nDays++;
            }

            if(nDays > 0) nTotal -= 26 * (nDays + 1);
            //if (nTotal < 0) nTotal = 0;
            //if (nDays == 0) nDays ++;
            // 230584296196905079
            // 230584296196905079



            Console.WriteLine(nDays);
            Console.WriteLine(nTotal);

        }
    }
}
