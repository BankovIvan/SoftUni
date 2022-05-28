using System;

namespace _06._Building
{
    class Program
    {
        static void Main(string[] args)
        {

            int nFloors = 0, nApartments = 0, i = 1, j = 1;
            string sText = "";

            nFloors = int.Parse(Console.ReadLine());
            nApartments = int.Parse(Console.ReadLine());

            if(nFloors > 0)
            {

                sText = "";

                for (j = 0; j < nApartments; j++)
                {
                    if(sText != "")
                    {
                        sText = sText + " ";
                    }

                    sText = sText + $"L{nFloors}{j}";

                }

                Console.WriteLine(sText);

            }

            nFloors--;


            for (i = nFloors; i > 0; i--)
            {

                sText = "";

                for (j = 0; j < nApartments; j++)
                {
                    if (sText != "")
                    {
                        sText = sText + " ";
                    }

                    if((i & 1) == 1)
                    {
                        sText = sText + $"A{i}{j}";
                    }
                    else
                    {
                        sText = sText + $"O{i}{j}";
                    }

                }

                Console.WriteLine(sText);

            }



        }
    }
}
