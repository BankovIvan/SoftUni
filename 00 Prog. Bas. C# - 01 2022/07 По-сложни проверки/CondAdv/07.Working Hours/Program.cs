using System;

namespace _07.Working_Hours
{
    class Program
    {
        static void Main(string[] args)
        {

            int nWorkHour;
            string sWeekDay;

            nWorkHour = int.Parse(Console.ReadLine());
            sWeekDay = Console.ReadLine();


            if(nWorkHour >= 10 && nWorkHour<= 18 && sWeekDay != "Sunday")
            {
                Console.WriteLine("open");
            }
            else
            {
                Console.WriteLine("closed");
            }


        }
    }
}
