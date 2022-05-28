using System;

namespace _03._Time
{
    class Program
    {
        static void Main(string[] args)
        {

            int nHour, nMinute;

            nHour = int.Parse(Console.ReadLine());
            nMinute = int.Parse(Console.ReadLine());

            nMinute = nMinute + 15;

            if(nMinute > 59)
            {
                nMinute -= 60;
                nHour += 1;
            }

            if(nHour > 23)
            {
                nHour -= 24;
            }


            if(nMinute < 10)
            {
                Console.WriteLine($"{nHour}:0{nMinute}");
            }
            else
            {
                Console.WriteLine($"{nHour}:{nMinute}");
            }

        }
    }
}
