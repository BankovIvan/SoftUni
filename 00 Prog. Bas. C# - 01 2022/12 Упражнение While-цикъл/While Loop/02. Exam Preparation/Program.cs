using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {

            double dTotalGrade = 0.0;
            int nNextGrade = 0, nGradeCount = 0, nBadGardesCount = 0, nBadGradesMax = 0;
            string sExamName = "", sLastProblem = "";

            nBadGradesMax = int.Parse(Console.ReadLine());
            sExamName = Console.ReadLine();

            while (sExamName != "Enough")
            {
                nNextGrade = int.Parse(Console.ReadLine());

                if (nNextGrade <= 4)
                {
                    nBadGardesCount++;

                    if (nBadGardesCount >= nBadGradesMax)
                    {
                        Console.WriteLine("You need a break, {0} poor grades.", nBadGradesMax);
                        return;
                    }
                }

                dTotalGrade += (double)nNextGrade;
                nGradeCount++;
                sLastProblem = sExamName;
                sExamName = Console.ReadLine();

            }

            dTotalGrade = dTotalGrade / (double)nGradeCount;

            Console.WriteLine("Average score: {0:F2}", dTotalGrade);
            Console.WriteLine("Number of problems: {0}", nGradeCount);
            Console.WriteLine("Last problem: {0}", sLastProblem);

        }
    }
}
