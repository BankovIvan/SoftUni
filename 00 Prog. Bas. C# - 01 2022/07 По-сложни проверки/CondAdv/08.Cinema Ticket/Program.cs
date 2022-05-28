using System;

namespace _08.Cinema_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string sWeekDay;

            sWeekDay = Console.ReadLine();


            if (sWeekDay == "Monday")
            {
                Console.WriteLine("12");
            }
            else if (sWeekDay == "Tuesday")
            {
                Console.WriteLine("12");
            }
            else if (sWeekDay == "Wednesday")
            {
                Console.WriteLine("14");
            }
            else if (sWeekDay == "Thursday")
            {
                Console.WriteLine("14");
            }
            else if (sWeekDay == "Friday")
            {
                Console.WriteLine("12");
            }
            else if (sWeekDay == "Saturday")
            {
                Console.WriteLine("16");
            }
            else
            {
                Console.WriteLine("16");
            }
        }
    }
}
