namespace Military.Core
{
    using Military.Core.Interfaces;
    using Military.Models;
    using Military.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Globalization;

    public class Engine : IEngine
    {
        public Engine()
        {

        }

        public void Run()
        {
            Dictionary<long, ISoldier> soldiers = new Dictionary<long, ISoldier>();
            string[] arrInput;

            while((arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries))[0] != "End")
            {
                switch (arrInput[0])
                {
                    case "Private":
                        AddPrivate(ref soldiers, arrInput);
                        break;
                    case "LieutenantGeneral":
                        AddLieutenantGeneral(ref soldiers, arrInput);
                        break;
                    case "Engineer":
                        AddEngineer(ref soldiers, arrInput);
                        break;
                    case "Commando":
                        AddCommando(ref soldiers, arrInput);
                        break;
                    case "Spy":
                        AddSpy(ref soldiers, arrInput);
                        break;
                    default:
                        break;
                }
            }

            foreach(var v in soldiers)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(v.Value.ToString());
                Console.ResetColor();
            }



        }

        private void AddSpy(ref Dictionary<long, ISoldier> soldiers, string[] arrInput)
        {
            Spy s = new Spy(
                long.Parse(arrInput[1]),
                arrInput[2],
                arrInput[3],
                int.Parse(arrInput[4]));

            soldiers.Add(s.Id, s);
        }

        private void AddCommando(ref Dictionary<long, ISoldier> soldiers, string[] arrInput)
        {
            try
            {
                Commando c = new Commando(
                    long.Parse(arrInput[1]),
                    arrInput[2],
                    arrInput[3],
                    decimal.Parse(arrInput[4]),
                    arrInput[5]);

                for (int i = 6; i < arrInput.Length; i += 2)
                {
                    try
                    {
                        c.AddMission(new Mission(arrInput[i], arrInput[i + 1]));
                    }
                    catch (Exception ey)
                    {

                    }
                    
                }

                soldiers.Add(c.Id, c);
            }
            catch (Exception ex)
            {

            }
        }

        private void AddEngineer(ref Dictionary<long, ISoldier> soldiers, string[] arrInput)
        {
            try
            {
                Engineer e = new Engineer(
                    long.Parse(arrInput[1]),
                    arrInput[2],
                    arrInput[3],
                    decimal.Parse(arrInput[4]), 
                    arrInput[5]);

                for(int i = 6; i < arrInput.Length; i += 2)
                {
                    e.AddRepair(new Repair(arrInput[i], int.Parse(arrInput[i + 1])));
                }

                soldiers.Add(e.Id, e);
            }
            catch (Exception ex)
            {

            }

        }

        private void AddLieutenantGeneral(ref Dictionary<long, ISoldier> soldiers, string[] arrInput)
        {
            LieutenantGeneral g = new LieutenantGeneral(
                long.Parse(arrInput[1]),
                arrInput[2],
                arrInput[3],
                decimal.Parse(arrInput[4]));

            for(int i = 5; i < arrInput.Length; i++)
            {
                long id = long.Parse(arrInput[i]);
                if (soldiers.ContainsKey(id))
                {
                    g.AddPrivate((IPrivate)soldiers[id]);
                }
            }

            soldiers.Add(g.Id, g);
        }

        private void AddPrivate(ref Dictionary<long, ISoldier> soldiers, string[] arrInput)
        {
            Private p = new Private(
                long.Parse(arrInput[1]),
                arrInput[2],
                arrInput[3],
                decimal.Parse(arrInput[4]));

            soldiers.Add(p.Id, p);
        }
    }
}
