using System;

namespace _02._Password
{
    class Program
    {
        static void Main(string[] args)
        {

            string sName = "", sPass = "", sInput = "";

            sName = Console.ReadLine();
            sPass = Console.ReadLine();

            sInput = Console.ReadLine();

            while (sInput != sPass)
            {

                sInput = Console.ReadLine();

            }

            Console.WriteLine("Welcome {0}!", sName);

        }
    }
}
