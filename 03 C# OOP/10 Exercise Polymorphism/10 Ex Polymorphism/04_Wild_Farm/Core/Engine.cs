namespace WildFarm.Core
{
    using WildFarm.Core.Interfaces;
    using WildFarm.Models;
    using WildFarm.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.IO.Interfaces;
    using WildFarm.Factories.Interfaces;
    using WildFarm.Exceptions;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;
        private List<IAnimal> animals;

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
            this.animals = new List<IAnimal>();
        }

        public void Run()
        {
            string[] arrInput;

            while((arrInput = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries))[0] != "End")
            {

                IAnimal currentAnimal = this.animalFactory.CreateAnimal(arrInput);
                this.writer.WriteLine(currentAnimal.ProduceSound());

                try
                {
                    arrInput = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    IFood currentFood = this.foodFactory.CreateFood(arrInput[0], int.Parse(arrInput[1]));
                    currentAnimal.Eat(currentFood);
                }
                catch(InvalidAnimalException e)
                {
                    this.writer.WriteLine(e.Message);
                }
                catch(InvalidFoodException e)
                {
                    this.writer.WriteLine(e.Message);
                }
                catch(FoodNotEatenException e)
                {
                    this.writer.WriteLine(e.Message);
                }
                catch(Exception)
                {
                    throw;
                }

                animals.Add(currentAnimal);

            }

            foreach(var v in animals)
            {
                this.writer.WriteLine(v.ToString());
            }
        }
    }
}
