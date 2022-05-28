using System;

namespace _07._Projects_Creation
{
    class Program
    {
        static void Main(string[] args)
        {

            int nProjects;
            string sName;

            sName = Console.ReadLine();
            nProjects = int.Parse(Console.ReadLine());


            Console.WriteLine("The architect {0} will need {1} hours to complete {2} project/s.", sName, nProjects*3, nProjects);
        }
    }
}
