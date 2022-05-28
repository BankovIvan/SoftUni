using System;

namespace _05._Salary
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, nTabCountIn = 0;
            double dSalaryIn = 0.0;
            string sTabSiteIn = "";

            nTabCountIn = int.Parse(Console.ReadLine());
            dSalaryIn = double.Parse(Console.ReadLine());

            for(i=0; i<nTabCountIn; i++)
            {
                sTabSiteIn = Console.ReadLine();
                if(sTabSiteIn == "Facebook")
                {
                    dSalaryIn -= 150.0;
                }
                else if (sTabSiteIn == "Instagram")
                {
                    dSalaryIn -= 100.0;
                }
                else if (sTabSiteIn == "Reddit")
                {
                    dSalaryIn -= 50.0;
                }

                if (dSalaryIn <= 0.0)
                {
                    Console.WriteLine("You have lost your salary.");
                    return;
                }

            }

            Console.WriteLine("{0:F0}", dSalaryIn);

        }
    }
}
