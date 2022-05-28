using System;

namespace _02._Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {

            int nTempIn;
            string sDayTime, sOutfit, sShoes;

            nTempIn = int.Parse(Console.ReadLine());
            sDayTime = Console.ReadLine();
            sOutfit = "";
            sShoes = "";

            switch (sDayTime)
            {
                case "Morning":

                    if(nTempIn >= 10 && nTempIn <= 18)
                    {
                        sOutfit = "Sweatshirt";
                        sShoes = "Sneakers";
                    }
                    else if (nTempIn > 18 && nTempIn <= 24)
                    {
                        sOutfit = "Shirt";
                        sShoes = "Moccasins";
                    }
                    else if (nTempIn > 24)
                    {
                        sOutfit = "T-Shirt";
                        sShoes = "Sandals";
                    }

                    break;

                case "Afternoon":

                    if (nTempIn >= 10 && nTempIn <= 18)
                    {
                        sOutfit = "Shirt";
                        sShoes = "Moccasins";
                    }
                    else if (nTempIn > 18 && nTempIn <= 24)
                    {
                        sOutfit = "T-Shirt";
                        sShoes = "Sandals";
                    }
                    else if (nTempIn > 24)
                    {
                        sOutfit = "Swim Suit";
                        sShoes = "Barefoot";
                    }

                    break;

                case "Evening":

                    if (nTempIn >= 10 && nTempIn <= 18)
                    {
                        sOutfit = "Shirt";
                        sShoes = "Moccasins";
                    }
                    else if (nTempIn > 18 && nTempIn <= 24)
                    {
                        sOutfit = "Shirt";
                        sShoes = "Moccasins";
                    }
                    else if (nTempIn > 24)
                    {
                        sOutfit = "Shirt";
                        sShoes = "Moccasins";
                    }

                    break;

                default:

                    break;
            }

            Console.WriteLine($"It's {nTempIn} degrees, get your {sOutfit} and {sShoes}.");

        }
    }
}
