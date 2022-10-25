namespace Farm
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Eat();
            dog.Bark();

            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();

        }

        static void _2_Main(string[] args)
        {
            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();


        }

        static void _01_Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Bark();
            dog.Bark();

            //dog.Eat();

        }
    }
}
