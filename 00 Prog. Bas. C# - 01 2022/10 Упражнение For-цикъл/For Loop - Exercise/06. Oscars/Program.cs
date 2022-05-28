using System;

namespace _06._Oscars
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, nVoters = 0;
            string sActor = "", sVoter = "";
            double dPoints = 0.0, dTotal = 0.0;

            sActor = Console.ReadLine();
            dTotal = double.Parse(Console.ReadLine());
            nVoters = int.Parse(Console.ReadLine());

            nVoters *= 2;

            for (i=0; i<nVoters; i++)
            {
                if((i & 1) == 0)
                {
                    sVoter = Console.ReadLine();
                }
                else
                {
                    dPoints = double.Parse(Console.ReadLine());

                    dTotal += (double)sVoter.Length * dPoints / 2;

                    if (dTotal > 1250.5)
                    {
                        Console.WriteLine("Congratulations, {0} got a nominee for leading role with {1:F1}!", sActor, dTotal);

                        return;

                    }
                }
            }

            Console.WriteLine("Sorry, {0} you need {1:F1} more!", sActor, 1250.5 - dTotal);

        }
    }
}
