namespace _Explicit.Core
{
    using _Explicit.Core.Interfaces;
    using _Explicit.Models;
    using _Explicit.Models.Interfaces;
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
            string[] arrInput; //  = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<IPerson> persons = new List<IPerson>();
            List<IResident> residents = new List<IResident>();

            while((arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries))[0] != "End")
            {
                Citizen citizen = new Citizen(arrInput[0], int.Parse(arrInput[2]), arrInput[1]);
                persons.Add(citizen);
                residents.Add(citizen);
            }

            for(int i = 0; i < persons.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(persons[i].GetName());
                Console.WriteLine(residents[i].GetName());
                Console.ResetColor();
            }

        }
    }
}
