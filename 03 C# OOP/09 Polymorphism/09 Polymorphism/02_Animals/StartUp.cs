namespace Animals
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Animal cat = new Cat("Peter", "Whiskas");
            Animal dog = new Dog("George", "Meat");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());
            Console.ResetColor();

        }
    }
}
