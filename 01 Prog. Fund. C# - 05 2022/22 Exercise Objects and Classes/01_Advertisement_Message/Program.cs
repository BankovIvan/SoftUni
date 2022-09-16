using System;
using System.Collections.Generic;
using System.Numerics;

namespace _01_Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrPhrases = new string[] {"Excellent product.", 
                                            "Such a great product.", 
                                            "I always use that product.", 
                                            "Best product of its category.", 
                                            "Exceptional product.", 
                                            "I can't live without this product."};
            string[] arrEvents = new string[] {"Now I feel good.", 
                                            "I have succeeded with this product.", 
                                            "Makes miracles. I am happy of the results!", 
                                            "I cannot believe but now I feel awesome.", 
                                            "Try it yourself, I am very satisfied.", 
                                            "I feel great!"};
            string[] arrAuthors = new string[] {"Diana", "Petya", "Stella", "Elena", 
                                            "Katya", "Iva", "Annie", "Eva"};
            string[] arrCities = new string[] {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

            int i, nRepeat;
            Random objRandom = new Random(); 

            nRepeat = int.Parse(Console.ReadLine());

            for(i = 0; i < nRepeat; i++){
                Console.WriteLine(arrPhrases[objRandom.Next(arrPhrases.Length)] + " " + 
                                    arrEvents[objRandom.Next(arrEvents.Length)] + " " +
                                    arrAuthors[objRandom.Next(arrAuthors.Length)] + " - " +
                                    arrCities[objRandom.Next(arrCities.Length)] + ".");
            }
        
        }
    }
}