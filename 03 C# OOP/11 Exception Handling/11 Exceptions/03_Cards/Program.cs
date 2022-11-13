namespace _03_Cards
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> lstCards = new List<Card>();
            string[] arrInput = Console.ReadLine().Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);

            for(int i = 0; i < arrInput.Length; i += 2)
            {
                try
                {
                    lstCards.Add(new Card(arrInput[i], arrInput[i + 1]));
                }
                catch(ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(String.Join(' ', lstCards));
            Console.ResetColor();

        }
    }

    public class Card
    {
        public string face;
        public string suit;

        public Card(string face, string suit)
        {
            if(face == "2" || face == "3" || face == "4" || face == "5" || face == "6" || 
                face == "7" || face == "8" || face == "9" || face == "10" ||
                face == "J" || face == "Q" || face == "K" || face == "A")
            {
                this.face = face;
            }
            else
            {
                throw new ArgumentException("Invalid card!");
            }
            
            if(suit == "S") this.suit = "\u2660";
            else if (suit == "H") this.suit = "\u2665";
            else if(suit == "D") this.suit = "\u2666";
            else if(suit == "C") this.suit = "\u2663";
            else throw new ArgumentException("Invalid card!");
        }

        public override string ToString()
        {
            return String.Format("[{0}{1}]", this.face, this.suit);
        }
    }
}
