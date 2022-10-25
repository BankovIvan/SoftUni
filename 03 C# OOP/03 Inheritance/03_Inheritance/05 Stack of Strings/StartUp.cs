namespace CustomStack
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {

            StackOfStrings strings = new StackOfStrings();

            strings.AddRange(new string[] { "String 1", "String 2", "String 3", "Stirng 4", "String 5", "String 6" });

            while (!strings.IsEmpty())
            {
                Console.WriteLine(strings.Pop());
            }
            
        }
    }
}
