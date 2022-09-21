using System;
using System.Collections.Generic;

namespace _07_Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> setCars = new HashSet<string>();
            string[] arrInput;

            while (true)
            {
                arrInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if(arrInput[0] == "END")
                {
                    break;
                }
                else if(arrInput[0] == "IN")
                {
                    setCars.Add(arrInput[1]);
                }
                else if(arrInput[0] == "OUT")
                {
                    setCars.Remove(arrInput[1]);
                }

            }

            if(setCars.Count > 0)
            {
                Console.WriteLine(string.Join('\n', setCars));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }

        }
    }
}
