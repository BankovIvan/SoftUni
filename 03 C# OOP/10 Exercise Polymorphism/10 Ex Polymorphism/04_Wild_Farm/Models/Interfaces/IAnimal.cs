namespace WildFarm.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        string ProduceSound();

        void Eat(IFood food);

    }
}
