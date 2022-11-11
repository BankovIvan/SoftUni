namespace Raiding.Factories.Interfaces
{
    using Raiding.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IFactory
    {
        IBaseHero CreateHero(string type, string name);
    }
}
