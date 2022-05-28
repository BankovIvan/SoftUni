using System;

namespace _07_Theatre_Promotions
{
    class Program
    {
        static void Main(string[] args)
        {
            string sDayType;
            int nAge;

            sDayType = Console.ReadLine();
            nAge = int.Parse(Console.ReadLine());

            if(nAge >= 0 && nAge <= 18)
            {
                if(sDayType == "Weekday")
                {
                    Console.WriteLine("12$");

                }
                else if(sDayType == "Weekend")
                {
                    Console.WriteLine("15$");

                }
                else if (sDayType == "Holiday")
                {
                    Console.WriteLine("5$");

                }

            }
            else if (nAge > 18 && nAge <= 64)
            {
                if (sDayType == "Weekday")
                {
                    Console.WriteLine("18$");

                }
                else if (sDayType == "Weekend")
                {
                    Console.WriteLine("20$");

                }
                else if (sDayType == "Holiday")
                {
                    Console.WriteLine("12$");

                }

            }
            else if (nAge > 64 && nAge <= 122)
            {
                if (sDayType == "Weekday")
                {
                    Console.WriteLine("12$");

                }
                else if (sDayType == "Weekend")
                {
                    Console.WriteLine("15$");

                }
                else if (sDayType == "Holiday")
                {
                    Console.WriteLine("10$");

                }

            }
            else
            {
                Console.WriteLine("Error!");
            }

        }
    }
}
