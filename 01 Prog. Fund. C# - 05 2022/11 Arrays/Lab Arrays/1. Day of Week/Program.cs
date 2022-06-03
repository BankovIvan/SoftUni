using System;

namespace _1._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrWeekDays = new string[] {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

            int nCurrentDay;

            nCurrentDay = int.Parse(Console.ReadLine());

            if(nCurrentDay >= 1 && nCurrentDay <= 7)
            {
                Console.WriteLine(arrWeekDays[nCurrentDay - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
