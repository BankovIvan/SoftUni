using System;
//using System.Collections.Generic;
//using System.Numerics;
//using System.Linq;

namespace _01_Secret_Chat
{


    class Program
    {
        static void Main(string[] args)
        {

            string sTravel;
            string[]  arrCommand;

            sTravel = Console.ReadLine();
            while(true){
                arrCommand = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
                if(arrCommand[0] == "Travel" || arrCommand[0] == "Reveal"){
                    break;
                }
                else if(arrCommand[0] == "Add Stop"){
                    sTravel = AddStop(sTravel, arrCommand[1], arrCommand[2]);
                }
                else if(arrCommand[0] == "Remove Stop"){
                    sTravel = RemoveStop(sTravel, arrCommand[1], arrCommand[2]);
                }
                else if(arrCommand[0] == "Switch"){
                    sTravel = SwitchStop(sTravel, arrCommand[1], arrCommand[2]);
                }

            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ready for world tour! Planned stops: " + sTravel);           
            Console.ResetColor();

        }

        static string AddStop(string sTravel, string sIndex, string sCity){
            int index = int.Parse(sIndex);

            if(index >= 0 && index < sTravel.Length){
                sTravel = sTravel.Insert(index, sCity);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(sTravel);           
            Console.ResetColor();

            return sTravel;
        }

        static string RemoveStop(string sTravel, string sFirst, string sLast){
            int nFirst = int.Parse(sFirst);
            int nLast = int.Parse(sLast);

            if(nFirst >= 0 && nFirst < sTravel.Length && nFirst < nLast && nLast < sTravel.Length)
            {
                sTravel = sTravel.Remove(nFirst, (nLast - nFirst) + 1);
            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(sTravel);           
            Console.ResetColor();

            return sTravel;
        }

        static string SwitchStop(string sTravel, string sOld, string sNew){

            sTravel = sTravel.Replace(sOld, sNew);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(sTravel);           
            Console.ResetColor();

            return sTravel;
        }
    }
}