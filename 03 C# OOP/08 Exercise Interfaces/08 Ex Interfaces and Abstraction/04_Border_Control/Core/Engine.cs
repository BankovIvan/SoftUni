namespace _04_Border_Control.Core
{
    using _04_Border_Control.Core.Interfaces;
    using _04_Border_Control.Models;
    using _04_Border_Control.Models.Interfaces;
    using System;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] arrInput;
            List<IIdentity> listIdentities = new List<IIdentity>();

            while((arrInput = Console.ReadLine().Split(' '))[0] != "End")
            {
                if(arrInput.Length == 3)
                {
                    listIdentities.Add(new Citizen(arrInput[2], arrInput[0], int.Parse(arrInput[1])));
                }
                else if(arrInput.Length == 2)
                {
                    listIdentities.Add(new Robot(arrInput[1], arrInput[0]));
                }
                else
                {
                    throw new ArgumentException("Unexpected input format!");
                }
            }

            string fakeId = Console.ReadLine().Trim();

            foreach(var v in listIdentities)
            {
                if (v.IsFakeId(fakeId))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(v.Id);
                    Console.ResetColor();
                }
            }
        }
    }
}
