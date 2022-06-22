using System;

namespace Problem_2___The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {

            int i, nPeople, nSeats;
            int[] nLiftCabins;

            nPeople = int.Parse(Console.ReadLine());
            nLiftCabins = Array.ConvertAll(
                        Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                        new Converter<string, int>(int.Parse)
                        );

            for(i = 0; i < nLiftCabins.Length && nPeople > 0; i++)
            {
                if (nLiftCabins[i] < 4)
                {
                    nSeats = 4 - nLiftCabins[i];

                    if(nPeople >= nSeats)
                    {
                        nPeople -= nSeats;
                        nLiftCabins[i] += nSeats;
                    }
                    else
                    {
                        nLiftCabins[i] += nPeople;
                        nPeople = 0;
                    }
                }
            }

            if(nPeople == 0 && nLiftCabins[nLiftCabins.Length-1] < 4)
            {
                Console.WriteLine("The lift has empty spots!", nPeople);
                Console.WriteLine(string.Join(' ', nLiftCabins));
            }
            else if(nPeople > 0)
            {
                Console.WriteLine("There isn't enough space! {0} people in a queue!", nPeople);
                Console.WriteLine(string.Join(' ', nLiftCabins));
            }
            else
            {
                Console.WriteLine(string.Join(' ', nLiftCabins));
            }

        }
    }
}
