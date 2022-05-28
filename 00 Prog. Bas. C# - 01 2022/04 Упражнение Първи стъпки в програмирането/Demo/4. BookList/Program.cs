using System;

namespace _4._BookList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            int nBookPages, nPagesPerHour, nReadingDays, nHoursPerDay;

            nBookPages = int.Parse(Console.ReadLine());
            nPagesPerHour = int.Parse(Console.ReadLine());
            nReadingDays = int.Parse(Console.ReadLine());

            nHoursPerDay = (nBookPages / nPagesPerHour) / nReadingDays;

            Console.WriteLine(nHoursPerDay);

        }
    }
}
