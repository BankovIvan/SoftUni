using System;

namespace _05._Everest
{
    class Program
    {
        static void Main(string[] args)
        {

            string sCampStay = "";
            int nMetersClimbed = 5364, nDaysClimbed = 1;

            sCampStay = Console.ReadLine();

            while (nDaysClimbed <= 5)
            {
                sCampStay = Console.ReadLine();

                if(sCampStay == "END")
                {
                    break;
                }
                else if(sCampStay == "Yes")
                {
                    nDaysClimbed++;
                    if(nDaysClimbed > 5)
                    {
                        break;
                    }

                }

                nMetersClimbed += int.Parse(Console.ReadLine());
                
                if(nMetersClimbed >= 8848)
                {
                    Console.WriteLine("Goal reached for {0} days!", nDaysClimbed);
                    return;
                }

            }

            Console.WriteLine("Failed!");
            Console.WriteLine(nMetersClimbed);

        }
    }
}
