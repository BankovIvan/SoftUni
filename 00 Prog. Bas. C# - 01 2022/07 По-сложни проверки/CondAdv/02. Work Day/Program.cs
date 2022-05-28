using System;

namespace _02._Work_Day
{
    class Program
    {
        static void Main(string[] args)
        {

                string sDayIn;

                sDayIn = Console.ReadLine();

                switch (sDayIn)
                {
                    case "Monday":

                    case "Tuesday":

                    case "Wednesday":

                    case "Thursday":

                    case "Friday":
                        Console.WriteLine("Working day");
                        break;

                    case "Saturday":

                    case "Sunday":
                        Console.WriteLine("Weekend");
                        break;

                    default:
                        Console.WriteLine("Error");
                        break;

                }

        }
    }

}
