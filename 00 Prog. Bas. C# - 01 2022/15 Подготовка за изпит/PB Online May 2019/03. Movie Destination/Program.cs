using System;

namespace _03._Movie_Destination
{
    class Program
    {
        static void Main(string[] args)
        {

            double dMovieBudget = 0.0, dTotalSpent = 0.0;
            string sMovieDestination = "", sMovieSeason = "";
            int nMovieDays = 0;

            dMovieBudget = double.Parse(Console.ReadLine());
            sMovieDestination = Console.ReadLine();
            sMovieSeason = Console.ReadLine();
            nMovieDays = int.Parse(Console.ReadLine());

            switch (sMovieDestination)
            {
                case "Dubai":
                    
                    if(sMovieSeason == "Winter")
                    {
                        dTotalSpent = (double)nMovieDays * 45000.0;
                    }
                    else
                    {
                        dTotalSpent = (double)nMovieDays * 40000.0;
                    }

                    dTotalSpent *= 0.70;

                    break;

                case "Sofia":

                    if (sMovieSeason == "Winter")
                    {
                        dTotalSpent = (double)nMovieDays * 17000.0;
                    }
                    else
                    {
                        dTotalSpent = (double)nMovieDays * 12500.0;
                    }

                    dTotalSpent *= 1.25;

                    break;

                case "London":

                    if (sMovieSeason == "Winter")
                    {
                        dTotalSpent = (double)nMovieDays * 24000.0;
                    }
                    else
                    {
                        dTotalSpent = (double)nMovieDays * 20250.0;
                    }

                    break;
            }

            dMovieBudget = dMovieBudget - dTotalSpent;

            if(dMovieBudget >= 0)
            {
                Console.WriteLine("The budget for the movie is enough! We have {0:F2} leva left!", dMovieBudget);
            }
            else
            {
                dMovieBudget *= -1.0;
                Console.WriteLine("The director needs {0:F2} leva more!", dMovieBudget);
            }

        }
    }
}
