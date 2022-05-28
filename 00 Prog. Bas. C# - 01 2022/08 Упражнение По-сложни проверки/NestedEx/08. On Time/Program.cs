using System;

namespace _08._On_Time
{
    class Program
    {
        static void Main(string[] args)
        {

            int nExamHours, nExamMinutes, nArrivalHours, nArrivalMinutes, nExamTime, nArrivalTime, nDeltaTime, nDeltaHours, nDeltaMinutes;

            nExamHours = int.Parse(Console.ReadLine());
            nExamMinutes = int.Parse(Console.ReadLine());
            nArrivalHours = int.Parse(Console.ReadLine());
            nArrivalMinutes = int.Parse(Console.ReadLine());

            nExamTime = nExamHours * 60 + nExamMinutes;
            nArrivalTime = nArrivalHours * 60 + nArrivalMinutes;
            nDeltaTime = nExamTime - nArrivalTime;
            nDeltaHours = nDeltaTime / 60;
            nDeltaMinutes = nDeltaTime % 60;

            if(nDeltaTime < 0)
            {
                //Late

                nDeltaHours *= -1;
                nDeltaMinutes *= -1;

                Console.WriteLine("Late");

                if (nDeltaHours > 0)
                {
                    Console.WriteLine("{0}:{1:D2} hours after the start", nDeltaHours, nDeltaMinutes);
                }
                else
                {
                    Console.WriteLine("{0} minutes after the start", nDeltaMinutes);
                }

            }
            else if(nDeltaTime > 30)
            {
                //Early

                Console.WriteLine("Early");

                if(nDeltaHours > 0)
                {
                    Console.WriteLine("{0}:{1:D2} hours before the start", nDeltaHours, nDeltaMinutes);
                }
                else
                {
                    Console.WriteLine("{0} minutes before the start", nDeltaMinutes);
                }
                

            }
            else if (nDeltaTime == 0)
            {
                //Exact
                Console.WriteLine("On time");

            }
            else
            {
                //On time
                Console.WriteLine("On time");
                Console.WriteLine("{0} minutes before the start", nDeltaMinutes);

            }


        }
    }
}
