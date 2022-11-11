namespace Raiding.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IBaseHero
    {
        string Name { get; }
        int Power { get; }

        string CastAbility();
    }
}
