using Vehicles.Core.Interfaces;

namespace Vehicles.Core
{
    using Vehicles.Core.Interfaces;
    using Vehicles.Models;
    using Vehicles.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine : IEngine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(arrInput[1]), double.Parse(arrInput[2]), double.Parse(arrInput[3]));

            arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(double.Parse(arrInput[1]), double.Parse(arrInput[2]), double.Parse(arrInput[3]));

            arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle bus = new Bus(double.Parse(arrInput[1]), double.Parse(arrInput[2]), double.Parse(arrInput[3]));

            int nRepeat = int.Parse(Console.ReadLine());
            for (int i = 0; i < nRepeat; i++)
            {
                arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (arrInput[0] == "Drive")
                {
                    if (arrInput[1] == "Car")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(car.Drive(double.Parse(arrInput[2])));
                        Console.ResetColor();
                    }
                    else if (arrInput[1] == "Truck")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(truck.Drive(double.Parse(arrInput[2])));
                        Console.ResetColor();
                    }
                    else if (arrInput[1] == "Bus")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(bus.Drive(double.Parse(arrInput[2])));
                        Console.ResetColor();
                    }
                }
                else if (arrInput[0] == "DriveEmpty")
                {
                    if (arrInput[1] == "Bus")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(bus.DriveEmpty(double.Parse(arrInput[2])));
                        Console.ResetColor();
                    }
                }
                else if (arrInput[0] == "Refuel")
                {
                    try
                    {
                        if (arrInput[1] == "Car")
                        {
                            car.Refuel(double.Parse(arrInput[2]));
                        }
                        else if (arrInput[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(arrInput[2]));
                        }
                        else if (arrInput[1] == "Bus")
                        {
                            bus.Refuel(double.Parse(arrInput[2]));
                        }
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ResetColor();
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
            Console.ResetColor();

        }
    }
}
