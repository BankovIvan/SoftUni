namespace _01_Decrypting_Commands
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;
	//using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string sMessage;
            string[] arrCommand;

            sMessage = Console.ReadLine();
            
            while(true){
                arrCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if(arrCommand[0] == "Finish"){
                    break;
                }
                else if(arrCommand[0] == "Replace"){
                    sMessage = ReplaceInMessage(sMessage, arrCommand);
                }
                else if(arrCommand[0] == "Cut"){
                    sMessage = CutInMessage(sMessage, arrCommand);
                }
                else if(arrCommand[0] == "Make"){
                    sMessage = MakeInMessage(sMessage, arrCommand);
                }
                else if(arrCommand[0] == "Check"){
                    CheckInMessage(sMessage, arrCommand);
                }
                else if(arrCommand[0] == "Sum"){
                    SumInMessage(sMessage, arrCommand);
                }
                
            }

        }

        public static string ReplaceInMessage(string sMessage, string[] arrCommand){
            string ret = sMessage.Replace(arrCommand[1], arrCommand[2]);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(ret);           
            Console.ResetColor();

            return ret;
        }

        public static string CutInMessage(string sMessage, string[] arrCommand){
            string ret = sMessage;
            int nStart = int.Parse(arrCommand[1]);
            int nEnd = int.Parse(arrCommand[2]);

            if(nStart < 0 || nEnd >= sMessage.Length || nStart > nEnd){
                ret = "Invalid indices!";
            }
            else{
                ret = sMessage.Remove(nStart, (nEnd - nStart) + 1);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(ret);           
            Console.ResetColor();

            return ret;
        }

        public static string MakeInMessage(string sMessage, string[] arrCommand){
            string ret = sMessage;

            if(arrCommand[1] == "Upper"){
                ret = sMessage.ToUpper();
            }
            else if((arrCommand[1] == "Lower")){
                ret = sMessage.ToLower();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(ret);           
            Console.ResetColor();

            return ret;
        }

        public static string CheckInMessage(string sMessage, string[] arrCommand){
            string ret = sMessage;

            if(sMessage.Contains(arrCommand[1])){
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Message contains {0}", arrCommand[1]);           
                Console.ResetColor();
            }
            else{
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Message doesn't contain {0}", arrCommand[1]);           
                Console.ResetColor();
            }



            return ret;
        }

        public static string SumInMessage(string sMessage, string[] arrCommand){
            string ret = sMessage;
            int nStart = int.Parse(arrCommand[1]);
            int nEnd = int.Parse(arrCommand[2]);
            int nSum = 0;

            if(nStart < 0 || nEnd >= sMessage.Length || nStart > nEnd){
                ret = "Invalid indices!";
            }
            else{
                for(int i = nStart; i <= nEnd; i++){
                    nSum += (int)sMessage[i];
                }

                ret = string.Format("{0}", nSum);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(ret);           
            Console.ResetColor();

            return ret;
        }

    }
}