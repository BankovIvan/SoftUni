namespace _06_Speed_Racing
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> dicCars = new Dictionary<string, Car>();
            int i, nRepeat = int.Parse(Console.ReadLine());

            for(i = 0; i < nRepeat; i++)
            {
                string[] arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                dicCars.Add(arrInput[0], new Car(arrInput[0], double.Parse(arrInput[1]), double.Parse(arrInput[2])));
            }

            while (true)
            {
                string[] arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (arrInput[0] == "End")
                {
                    break;
                }
                else if(arrInput[0] == "Drive")
                {
                    if (dicCars.ContainsKey(arrInput[1]))
                    {
                        dicCars[arrInput[1]].Drive(double.Parse(arrInput[2]));
                    }
                }


            }

            foreach(var v in dicCars)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("{0} {1:F2} {2}", v.Key, v.Value.FuelAmount, v.Value.DistanceTraveled);
                Console.ResetColor();
            }

        }
    }
}
