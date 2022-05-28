using System;

namespace _04._Password
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string sPass;

            sPass = Console.ReadLine();

            if(sPass == "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }

        }
    }
}
