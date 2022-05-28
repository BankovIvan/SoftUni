// 8. Завършване

using System;

namespace _08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {

            int nClass = 1;
            double dGrade = 0.0, dTotal = 0.0;
            string sName = "";
            bool bRepeat = false;

            sName = Console.ReadLine();

            while (nClass <= 12)
            {

                dGrade = double.Parse(Console.ReadLine());

                if (dGrade < 4.00)
                {
                    if (bRepeat)
                    {
                        Console.WriteLine("{0} has been excluded at {1} grade", sName, nClass);
                        return;

                    }
                    else
                    {
                        bRepeat = true;
                        continue;
                    }
                }

                dTotal += dGrade;
                nClass++;
                bRepeat = false;

            }

            --nClass;
            dTotal = dTotal / (double)nClass;
            Console.WriteLine("{0} graduated. Average grade: {1:F2}", sName, dTotal);

        }
    }
}
