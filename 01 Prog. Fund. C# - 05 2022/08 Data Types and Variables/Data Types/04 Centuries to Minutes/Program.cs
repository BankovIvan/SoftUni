using System;

namespace _04_Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int nCenturies, nYears, nDays, nHours, nMinutes;

            nCenturies = int.Parse(Console.ReadLine());

            nYears = nCenturies * 100; //years
            nDays = (int)(nYears * 365.2422); //days
            nHours = nDays * 24; //Hours
            nMinutes = nHours * 60; //Minutes

            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes", nCenturies, nYears, nDays, nHours, nMinutes);

        }
    }
}