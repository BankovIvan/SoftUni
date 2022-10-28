namespace Animals
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> lstAnimals = new List<Animal>();

            string command;

            while((command = Console.ReadLine()) != "Beast!")
            {
                string[] arrInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command)
                {
                    case "Cat":
                        lstAnimals.Add(new Cat(arrInput[0], int.Parse(arrInput[1]), arrInput[2]));
                        break;
                    case "Dog":
                        lstAnimals.Add(new Dog(arrInput[0], int.Parse(arrInput[1]), arrInput[2]));
                        break;
                    case "Frog":
                        lstAnimals.Add(new Frog(arrInput[0], int.Parse(arrInput[1]), arrInput[2]));
                        break;
                    case "Kitten":
                        lstAnimals.Add(new Kitten(arrInput[0], int.Parse(arrInput[1])));
                        break;
                    case "Tomcat":
                        lstAnimals.Add(new Tomcat(arrInput[0], int.Parse(arrInput[1])));
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                        break;
                }

            }

            foreach(var v in lstAnimals)
            {
                Console.WriteLine(v.ToString());
            }

        }
    }
}
