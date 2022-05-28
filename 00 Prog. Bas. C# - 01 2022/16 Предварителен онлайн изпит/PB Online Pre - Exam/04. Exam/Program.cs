using System;

namespace _04._Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, nStudents = 0, nGrade3 = 0, nGrade4 = 0, nGrade5 = 0, nGrade6 = 0;
            double dGradeIn = 0.0, dGradesAmount = 0.0, dGradeAverage = 0.0;

            nStudents = int.Parse(Console.ReadLine());

            for(i = 0; i < nStudents; i++)
            {
                dGradeIn = double.Parse(Console.ReadLine());
                dGradeAverage += dGradeIn;

                if (dGradeIn < 3.00)
                {
                    nGrade3++;
                }
                else if (dGradeIn < 4.00)
                {
                    nGrade4++;
                }
                else if (dGradeIn < 5.00)
                {
                    nGrade5++;
                }
                else
                {
                    nGrade6++;
                }

            }

            dGradesAmount = (double)(nGrade3 + nGrade4 + nGrade5 + nGrade6);
            dGradeAverage = dGradeAverage / dGradesAmount;

            Console.WriteLine("Top students: {0:F2}%", (double)(nGrade6 * 100) / dGradesAmount);
            Console.WriteLine("Between 4.00 and 4.99: {0:F2}%", (double)(nGrade5 * 100) / dGradesAmount);
            Console.WriteLine("Between 3.00 and 3.99: {0:F2}%", (double)(nGrade4 * 100) / dGradesAmount);
            Console.WriteLine("Fail: {0:F2}%", (double)(nGrade3 * 100) / dGradesAmount);
            Console.WriteLine("Average: {0:F2}", dGradeAverage);


        }
    }
}
