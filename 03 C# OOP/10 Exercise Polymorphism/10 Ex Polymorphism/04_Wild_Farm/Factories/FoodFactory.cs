namespace WildFarm.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Exceptions;
    using WildFarm.Factories.Interfaces;
    using WildFarm.Models.Foods;
    using WildFarm.Models.Interfaces;

    public class FoodFactory : IFoodFactory
    {
        public FoodFactory()
        {

        }

        public IFood CreateFood(string type, int quantity)
        {
            IFood food = null;
            if(type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if(type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if(type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if(type == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else
            {
                throw new InvalidFoodException();
            }

            return food;
        }
    }
}
