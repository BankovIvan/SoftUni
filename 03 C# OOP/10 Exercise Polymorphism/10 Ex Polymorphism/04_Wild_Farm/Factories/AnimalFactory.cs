namespace WildFarm.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Exceptions;
    using WildFarm.Factories.Interfaces;
    using WildFarm.Models.Animals;
    using WildFarm.Models.Interfaces;

    internal class AnimalFactory : IAnimalFactory
    {
        public AnimalFactory()
        {

        }

        public IAnimal CreateAnimal(string[] arrInput)
        {
            string type = arrInput[0];
            string name = arrInput[1];
            double weight = double.Parse(arrInput[2]);

            IAnimal animal;
            if (type == "Owl")
            {
                double wingSize = double.Parse(arrInput[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if(type == "Hen")
            {
                double wingSize = double.Parse(arrInput[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (type == "Mouse")
            {
                string livingRegion = arrInput[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == "Dog")
            {
                string livingRegion = arrInput[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (type == "Cat")
            {
                string livingRegion = arrInput[3];
                string breed = arrInput[4];
                animal = new Cat(name, weight, livingRegion,breed);
            }
            else if (type == "Tiger")
            {
                string livingRegion = arrInput[3];
                string breed = arrInput[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }
            else
            {
                throw new InvalidAnimalException();
            }

            return animal;
        }
    }
}
