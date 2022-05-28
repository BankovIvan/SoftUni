using System;

namespace _01._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {

            string sMovieTypeIn;
            int nRowsIn, nColsIn;
            double dRevenue;

            sMovieTypeIn = Console.ReadLine();
            nRowsIn = int.Parse(Console.ReadLine());
            nColsIn = int.Parse(Console.ReadLine());
            dRevenue = 0.0;

            if (sMovieTypeIn== "Premiere")
            {
                dRevenue = 12.0;
            }
            else if (sMovieTypeIn == "Normal")
            {
                dRevenue = 7.50;
            }
            else if (sMovieTypeIn == "Discount")
            {
                dRevenue = 5.00;
            }

            dRevenue *= (double)(nRowsIn * nColsIn);

            Console.WriteLine("{0:F2} leva", dRevenue);


        }
    }
}
