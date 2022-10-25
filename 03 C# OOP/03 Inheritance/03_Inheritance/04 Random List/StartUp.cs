namespace CustomRandomList
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList lstRand = new RandomList();

            lstRand.Add("String 1");
            lstRand.Add("String 2");
            lstRand.Add("String 3");
            lstRand.Add("String 4");
            lstRand.Add("String 5");
            lstRand.Add("String 6");

            Console.WriteLine(lstRand.RandomString());
            Console.WriteLine(lstRand.RandomString());
            Console.WriteLine(lstRand.RandomString());

            Console.WriteLine(lstRand.Count);

        }
    }
}
