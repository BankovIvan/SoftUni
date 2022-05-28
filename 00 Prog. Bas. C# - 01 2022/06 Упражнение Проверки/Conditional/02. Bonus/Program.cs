using System;

namespace _02._Bonus
{
    class Program
    {
        static void Main(string[] args)
        {

            int nPoints;
            double dBonus;

            nPoints = int.Parse(Console.ReadLine());

            if(nPoints <= 100)
            {
                dBonus = 5.0;
            }
            else if(nPoints <= 1000)
            {
                dBonus = ((double)nPoints) * 0.2;
            }
            else
            {
                dBonus = ((double)nPoints) * 0.1;
            }

            if(nPoints % 2 == 0)
            {
                dBonus += 1.0;
            }
            else if (nPoints % 5 == 0)
            {
                dBonus += 2.0;
            }

            Console.WriteLine(dBonus);
            Console.WriteLine(dBonus + nPoints);


        }
    }
}
