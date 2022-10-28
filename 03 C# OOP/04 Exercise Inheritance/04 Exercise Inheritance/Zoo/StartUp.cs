namespace Zoo
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Animal animal = new Animal("Animal");
            Console.WriteLine(animal.ToString());

            Reptile reptile = new Reptile("Reptile");
            Console.WriteLine(reptile.ToString());

            Mammal mammal = new Mammal("Mammal");
            Console.WriteLine(mammal.ToString());

            Lizard lizard = new Lizard("Lizard");
            Console.WriteLine(lizard.ToString());

            Snake snake = new Snake("Snake");
            Console.WriteLine(snake.ToString());

            Gorilla gorilla = new Gorilla("Gorilla");
            Console.WriteLine(gorilla.ToString());

            Bear bear = new Bear("Bear");
            Console.WriteLine(bear.ToString());

        }
    }
}