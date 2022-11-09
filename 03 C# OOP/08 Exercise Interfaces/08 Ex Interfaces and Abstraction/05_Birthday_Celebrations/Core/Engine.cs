namespace Birthday.Core
{
    using Birthday.Core.Interfaces;
    using Birthday.Models;
    using Birthday.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class Engine : IEngine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] arrInput;
            List<IBirthdate> listIdentities = new List<IBirthdate>();

            while((arrInput = Console.ReadLine().Split(' '))[0] != "End")
            {
                if(arrInput[0] == "Citizen")
                {
                    listIdentities.Add(
                        new Citizen(
                            arrInput[1], 
                            int.Parse(arrInput[2]), 
                            arrInput[3], 
                            DateTime.ParseExact(arrInput[4], "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                }
                else if(arrInput[0] == "Robot")
                {
                    //listIdentities.Add(new Robot(arrInput[1], arrInput[2]));
                }
                else if (arrInput[0] == "Pet")
                {
                    listIdentities.Add(new Pet(arrInput[1], DateTime.ParseExact(arrInput[2], "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                }
                else
                {
                    throw new ArgumentException("Unexpected input format!");
                }
            }

            int year = int.Parse(Console.ReadLine());

            foreach(var v in listIdentities)
            {
                if (v.IsBirthYear(year))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(v.Birthday.ToString("dd/MM/yyyy"));
                    Console.ResetColor();
                }
            }
        }
    }
}
