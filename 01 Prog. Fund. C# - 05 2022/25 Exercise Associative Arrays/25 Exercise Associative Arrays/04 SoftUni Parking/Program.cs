namespace _04_SoftUni_Parking
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        class ParkingPlace
        {
            public string UserName { get; set; }
            public string PlateNumber { get; set; }

            public ParkingPlace(string UserName, string PlateNumber)
            {
                this.UserName = UserName;
                this.PlateNumber = PlateNumber;
            }

            public override string ToString()
            {
                return string.Format("{0} => {1}", this.UserName, this.PlateNumber);
            }

        }

        static void Main(string[] args)
        {

            Dictionary<string, ParkingPlace> dicParking = new Dictionary<string, ParkingPlace>();
            string[] arrInput;
            int i, nRepeat;

            nRepeat = int.Parse(Console.ReadLine());
            for (i = 0; i < nRepeat; i++)
            {
                arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (arrInput[0] == "register")
                {
                    RegisterVehicle(dicParking, arrInput[1], arrInput[2]);
                }
                else
                {
                    UnRegisterVehicle(dicParking, arrInput[1]);
                }

            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var v in dicParking)
            {
                Console.WriteLine(v.Value);
            }
            Console.ResetColor();

        }

        static void RegisterVehicle(Dictionary<string, ParkingPlace> dicParking, string UserName, string PlateNumber)
        {

            if (dicParking.ContainsKey(UserName))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ERROR: already registered with plate number {0}",
                                        dicParking[UserName].PlateNumber);
                Console.ResetColor();
                return;
            }

            dicParking.Add(UserName, new ParkingPlace(UserName, PlateNumber));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} registered {1} successfully", UserName, PlateNumber);
            Console.ResetColor();

            return;

        }

        static void UnRegisterVehicle(Dictionary<string, ParkingPlace> dicParking, string UserName)
        {

            if (!dicParking.ContainsKey(UserName))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ERROR: user {0} not found", UserName);
                Console.ResetColor();
                return;
            }

            dicParking.Remove(UserName);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} unregistered successfully", UserName);
            Console.ResetColor();

            return;

        }

    }
}