namespace Raiding.Factories
{
    using Raiding.Factories.Interfaces;
    using Raiding.Models;
    using Raiding.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Linq;

    public class Factory : IFactory
    {
        public Factory()
        {

        }

        public IBaseHero CreateHero(string type, string name)
        {
            IBaseHero hero = null;

            switch (type)
            {
                case "Druid":
                    hero = new Druid(name);
                    break;
                case "Paladin":
                    hero = new Paladin(name);
                    break;
                case "Rogue":
                    hero = new Rogue(name);
                    break;
                case "Warrior":
                    hero = new Warrior(name);
                    break;
                default:
                    throw new ArgumentException("Invalid hero!");
                    break;

            }

            return hero;
        }
    }
}
