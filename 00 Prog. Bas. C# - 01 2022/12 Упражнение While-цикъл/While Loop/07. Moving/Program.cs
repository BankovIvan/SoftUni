using System;

namespace _07._Moving
{
    class Program
    {
        static void Main(string[] args)
        {

            int nHouseVolume = 0;
            string sData = "";

            nHouseVolume = int.Parse(Console.ReadLine());
            nHouseVolume *= int.Parse(Console.ReadLine());
            nHouseVolume *= int.Parse(Console.ReadLine());

            while(nHouseVolume > 0)
            {

                sData = Console.ReadLine();
                if (sData == "Done")
                {
                    break;
                }

                nHouseVolume -= int.Parse(sData);

            }

            if(nHouseVolume >= 0)
            {
                Console.WriteLine("{0} Cubic meters left.", nHouseVolume);
            }
            else
            {
                nHouseVolume = nHouseVolume * -1;
                Console.WriteLine("No more free space! You need {0} Cubic meters more.", nHouseVolume);
            }

        }
    }
}
