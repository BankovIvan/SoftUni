using Raiding.Core.Interfaces;

namespace Raiding.Core
{
    using Raiding.Core.Interfaces;
    using Raiding.Factories.Interfaces;
    using Raiding.Models;
    using Raiding.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class Engine : IEngine
    {
        private IFactory factory;
        private List<IBaseHero> lstHeroes;

        public Engine(IFactory factory)
        {
            this.factory = factory;
            this.lstHeroes = new List<IBaseHero>();
        }

        public void Run()
        {
            int nRepeat = int.Parse(Console.ReadLine());

            while(nRepeat > 0)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    IBaseHero hero = this.factory.CreateHero(type, name);
                    this.lstHeroes.Add(hero);
                    nRepeat--;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
            }
            
            long bossPower = long.Parse(Console.ReadLine());
            long damagePower = 0;

            foreach(var v in lstHeroes)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(v.CastAbility());
                Console.ResetColor();
                damagePower += v.Power;
            }

            if(damagePower >= bossPower)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Victory!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Defeat...");
                Console.ResetColor();
            }


        }
    }
}
