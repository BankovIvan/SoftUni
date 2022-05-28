using System;

namespace _06._Speed
{
    class Program
    {
        static void Main(string[] args)
        {

            double dSpeed;

            dSpeed = double.Parse(Console.ReadLine());

            if(dSpeed <= 10.0)
            {
                Console.WriteLine("slow");
            }
            else if (dSpeed <= 50.0)
            {
                Console.WriteLine("average");
            }
            else if (dSpeed <= 150.0)
            {
                Console.WriteLine("fast");
            }
            else if (dSpeed <= 1000.0)
            {
                Console.WriteLine("ultra fast");
            }
            else 
            {
                Console.WriteLine("extremely fast");
            }

            /*
            switch (dSpeed)
            {
                case <= 10.0:
                    Console.WriteLine("slow");
                    break;
                
                case <= 50.0:
                    Console.WriteLine("average");
                    break;

                case <= 150.0:
                    Console.WriteLine("fast");
                    break;

                case <= 1000.0:
                    Console.WriteLine("ultra fast");
                    break;

                default:
                    Console.WriteLine("extremely fast");
                    break;

            }
            */

        }
    }
}
