namespace GenericScale
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> testScale = new EqualityScale<int>(10, 10);

            Console.WriteLine(testScale.AreEqual());
        }
    }
}
