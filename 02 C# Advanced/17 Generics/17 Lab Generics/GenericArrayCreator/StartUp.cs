namespace GenericArrayCreator
{
    using System;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(10, 33);

            //Console.WriteLine(String.Join('\n', strings));
            //Console.WriteLine(String.Join('\n', integers));
        }
    }
}
