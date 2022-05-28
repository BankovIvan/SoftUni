using System;

namespace _07_Concat_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string sFirstName, sSecondName, sDelimiter;

            sFirstName = Console.ReadLine();
            sSecondName = Console.ReadLine();
            sDelimiter = Console.ReadLine();

            Console.WriteLine(sFirstName + sDelimiter + sSecondName);

        }
    }
}
