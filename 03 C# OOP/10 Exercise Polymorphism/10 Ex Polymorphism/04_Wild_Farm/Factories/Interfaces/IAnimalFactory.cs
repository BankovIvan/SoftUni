namespace WildFarm.Factories.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Models.Interfaces;

    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string[] arrInput);
    }
}
