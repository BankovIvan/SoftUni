using System;

namespace _08._Lunch
{
    class Program
    {
        static void Main(string[] args)
        {

            string sMovieName;
            int nMovieTime, nBreakTime;
            double dLunchTime, dSleepTime, dDeltaTime;

            sMovieName = Console.ReadLine();
            nMovieTime = int.Parse(Console.ReadLine());
            nBreakTime = int.Parse(Console.ReadLine());

            dLunchTime = (double)nBreakTime * 0.125;
            dSleepTime = (double)nBreakTime * 0.25;

            dDeltaTime = (double)nBreakTime - (dLunchTime + dSleepTime) - (double)nMovieTime;

            if(dDeltaTime >= 0)
            {
                Console.WriteLine("You have enough time to watch {0} and left with {1} minutes free time.",
                                    sMovieName, Math.Ceiling(dDeltaTime));
            }
            else
            {
                dDeltaTime = Math.Abs(dDeltaTime);
                Console.WriteLine("You don't have enough time to watch {0}, you need {1} more minutes.",
                                    sMovieName, Math.Ceiling(dDeltaTime));
            }

        }
    }
}
