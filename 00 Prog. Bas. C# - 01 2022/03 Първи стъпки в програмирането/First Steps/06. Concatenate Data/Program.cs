using System;

namespace _06._Concatenate_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string sFirstName, sLastName, sAge, sTown;

            sFirstName = Console.ReadLine();
            sLastName = Console.ReadLine();
            sAge = Console.ReadLine();
            sTown = Console.ReadLine();

            Console.WriteLine($"You are {sFirstName} {sLastName}, a {sAge}-years old person from {sTown}.");
        }
    }
}
