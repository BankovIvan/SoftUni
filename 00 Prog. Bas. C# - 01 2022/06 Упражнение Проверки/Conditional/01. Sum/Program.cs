using System;

namespace _01._Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime, secondTime, thirdTime, totalTime, totalMinutes, totalSeconds;

            firstTime = int.Parse(Console.ReadLine());
            secondTime = int.Parse(Console.ReadLine());
            thirdTime = int.Parse(Console.ReadLine());

            totalTime = firstTime + secondTime + thirdTime;
            totalMinutes = totalTime / 60;
            totalSeconds = totalTime % 60;

            if(totalSeconds < 10)
            {
                Console.WriteLine($"{totalMinutes}:0{totalSeconds}");
            }
            else
            {
                Console.WriteLine($"{totalMinutes}:{totalSeconds}");
            }

        }
    }
}
