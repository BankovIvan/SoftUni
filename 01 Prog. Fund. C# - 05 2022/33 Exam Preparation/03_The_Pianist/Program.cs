namespace _03_The_Pianist
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        class Pianist{
            public string Piece {get; set;}
            public string Composer {get; set;}
            public string Key {get; set;}

            public Pianist(string Piece, string Composer, string Key){
                this.Piece = Piece;
                this.Composer = Composer;
                this.Key = Key;
            }

            public override string ToString()
            {
                return string.Format("{0} -> Composer: {1}, Key: {2}", this.Piece, this.Composer, this.Key);
            }

        }

        static void Main(string[] args)
        {

            Dictionary<string, Pianist> dicPianists = new Dictionary<string, Pianist>();
            string[] arrInput;
            int i, nRepeat;

            nRepeat = int.Parse(Console.ReadLine());
            for(i = 0; i < nRepeat; i++){
                arrInput = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                dicPianists.Add(arrInput[0], new Pianist(arrInput[0], arrInput[1], arrInput[2]));
            }

            while(true){
                arrInput = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                if(arrInput[0] == "Stop"){
                    break;
                }
                else if(arrInput[0] == "Add"){
                    if(dicPianists.ContainsKey(arrInput[1])){
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{0} is already in the collection!", arrInput[1]);           
                        Console.ResetColor();
                    }
                    else{
                        dicPianists.Add(arrInput[1], new Pianist(arrInput[1], arrInput[2], arrInput[3]));
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{0} by {1} in {2} added to the collection!", 
                                            arrInput[1], arrInput[2], arrInput[3]);           
                        Console.ResetColor();
                    }

                }
                else if(arrInput[0] == "Remove"){
                    if(! dicPianists.ContainsKey(arrInput[1])){
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Invalid operation! {0} does not exist in the collection.", 
                                            arrInput[1]);           
                        Console.ResetColor();
                    }
                    else{
                        dicPianists.Remove(arrInput[1]);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Successfully removed {0}!", arrInput[1]);           
                        Console.ResetColor();
                    }
                }
                else if(arrInput[0] == "ChangeKey"){
                        if(! dicPianists.ContainsKey(arrInput[1])){
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Invalid operation! {0} does not exist in the collection.", 
                                            arrInput[1]);           
                        Console.ResetColor();
                    }
                    else{
                        dicPianists[arrInput[1]].Key = arrInput[2];
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Changed the key of {0} to {1}!", arrInput[1], arrInput[2]);           
                        Console.ResetColor();
                    }
                }

            }

            foreach(var v in dicPianists){
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(v.Value);           
                Console.ResetColor();
            }

        }
    }
}
