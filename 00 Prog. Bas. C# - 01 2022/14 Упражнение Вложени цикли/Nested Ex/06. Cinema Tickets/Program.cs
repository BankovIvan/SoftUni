using System;

namespace _06._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {

            string sMovie = "", sTicket = "";
            int i = 0, nSeats = 0, nStandard = 0, nStudent = 0, nKids = 0, nTotalAll = 0, nTotalStandard = 0, nTotalStudent = 0, nTotalKids = 0;
            double dTotalFull = 0.0;

            sMovie = Console.ReadLine();

            while (sMovie != "Finish")
            {

                //sMovie = Console.ReadLine();
                nSeats = int.Parse(Console.ReadLine());

                nStandard = 0;
                nStudent = 0;
                nKids = 0;

                for (i = 0; i < nSeats; i++)
                {
                    sTicket = Console.ReadLine();

                    if (sTicket == "standard")
                    {
                        nStandard++;
                    }
                    else if (sTicket == "student")
                    {
                        nStudent++;
                    }
                    else if (sTicket == "kid")
                    {
                        nKids++;
                    }
                    else
                    {
                        break;
                    }

                }

                dTotalFull = (double)((nStandard + nStudent + nKids) * 100);
                dTotalFull = dTotalFull / (double)nSeats;

                nTotalStandard += nStandard;
                nTotalStudent += nStudent;
                nTotalKids += nKids;

                //Console.WriteLine($"{sMovie} - {dTotalFull:F2}% full.");
                Console.WriteLine("{0} - {1:F2}% full.", sMovie, dTotalFull);

                //if (i == nSeats)
                //{
                sMovie = Console.ReadLine();
                //}

            }

            nTotalAll = nTotalStandard + nTotalStudent + nTotalKids;

            Console.WriteLine("Total tickets: {0}", nTotalAll);

            dTotalFull = (double)(nTotalStudent * 100);
            dTotalFull = dTotalFull / (double)nTotalAll;

            Console.WriteLine("{0:F2}% student tickets.", dTotalFull);

            dTotalFull = (double)(nTotalStandard * 100);
            dTotalFull = dTotalFull / (double)nTotalAll;

            Console.WriteLine("{0:F2}% standard tickets.", dTotalFull);

            dTotalFull = (double)(nTotalKids * 100);
            dTotalFull = dTotalFull / (double)nTotalAll;

            Console.WriteLine("{0:F2}% kids tickets.", dTotalFull);

        }
    }
}
