using System;

namespace _08._Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, nTournaments = 0, nInitialPoints = 0, nWon = 0, nTotal = 0;
            string sResult = "";

            nTournaments = int.Parse(Console.ReadLine());
            nInitialPoints = int.Parse(Console.ReadLine());

            for(i=0; i<nTournaments; i++)
            {

                sResult = Console.ReadLine();

                if (sResult == "W")
                {
                    nWon++;
                    nTotal += 2000;
                }
                else if(sResult == "F")
                {
                    nTotal += 1200;
                }
                else if(sResult == "SF")
                {
                    nTotal += 720;
                }

            }

            Console.WriteLine("Final points: {0}", nTotal + nInitialPoints);
            Console.WriteLine("Average points: {0}", nTotal / nTournaments);
            Console.WriteLine("{0:F2}%", (double)(nWon * 100) / (double)(nTournaments));

        }
    }
}
