using System;

namespace _05_Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string sUsename, sPassword, sInput;
            int i, j;

            sUsename = Console.ReadLine();
            sPassword = "";

            for (i = sUsename.Length - 1; i >= 0; i--)
            {
                sPassword = sPassword + sUsename[i];
            }

            for(i = 0; i < 4; i++)
            {
                sInput = Console.ReadLine();

                if (sInput == sPassword)
                {
                    Console.WriteLine("User {0} logged in.", sUsename);
                    break;
                }
                else
                {
                    if(i < 3)
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                    }
                    else
                    {
                        Console.WriteLine("User {0} blocked!", sUsename);
                    }
                    
                }
            }


        }
    }
}
