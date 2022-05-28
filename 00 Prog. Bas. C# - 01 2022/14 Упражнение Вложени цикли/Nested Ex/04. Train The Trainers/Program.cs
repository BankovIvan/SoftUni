using System;

namespace _04._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, nJury = 0, nCount = 0;
            double dTotal = 0.0, dFinal = 0.0;
            string sExam = "";

            nJury = int.Parse(Console.ReadLine());
            sExam = Console.ReadLine();

            while(sExam != "Finish")
            {

                dTotal = 0.0;

                for (i = 0; i < nJury; i++)
                {
                    dTotal += double.Parse(Console.ReadLine());
                    nCount++;

                }

                Console.WriteLine("{0} - {1:F2}.", sExam, dTotal / (double)nJury);

                dFinal += dTotal;
                
                sExam = Console.ReadLine();

            }

            Console.WriteLine("Student's final assessment is {0:F2}.", dFinal / (double)nCount);

        }
    }
}
