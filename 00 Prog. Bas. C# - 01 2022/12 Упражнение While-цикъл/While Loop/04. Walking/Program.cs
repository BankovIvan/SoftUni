using System;

namespace _04._Walking
{
    class Program
    {
        static void Main(string[] args)
        {

            int nStepsTotal = 0, nStepsLast = 0;
            string sData = "";

            while (nStepsTotal < 10000)
            {
                sData = Console.ReadLine();

                if(sData == "Going home")
                {
                    nStepsLast = int.Parse(Console.ReadLine());
                    nStepsTotal += nStepsLast;
                    break;

                }

                nStepsLast = int.Parse(sData);
                nStepsTotal += nStepsLast;

            }

            if(nStepsTotal >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine("{0} steps over the goal!", nStepsTotal - 10000);
            }
            else
            {
                Console.WriteLine("{0} more steps to reach goal.", 10000 - nStepsTotal);
            }

        }
    }
}
