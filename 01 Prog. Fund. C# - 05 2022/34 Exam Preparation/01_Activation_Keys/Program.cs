namespace _01_Activation_Keys
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            string sKey;
            string[] arrCommand;

            sKey = Console.ReadLine();

            while(true){
                arrCommand = Console.ReadLine().Split('>', StringSplitOptions.RemoveEmptyEntries);
                if(arrCommand[0] == "Generate"){
                    break;
                }
                else if(arrCommand[0] == "Contains"){
                    KeyContains(sKey, arrCommand[1]);
                }
                else if(arrCommand[0] == "Flip"){
                    sKey = KeyFlip(sKey, arrCommand[1], arrCommand[2], arrCommand[3]);
                }
                else if(arrCommand[0] == "Slice"){
                    sKey = KeySlice(sKey, arrCommand[1], arrCommand[2]);
                }


            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Your activation key is: {0}", sKey);           
            Console.ResetColor();

        }

        public static string KeyContains(string sKey, string sSubstring){
            string ret = sKey;

            if(sKey.Contains(sSubstring)){
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} contains {1}", sKey, sSubstring);           
                Console.ResetColor();
            }
            else{
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Substring not found!");           
                Console.ResetColor();                
            }

            return ret;
        }

        public static string KeyFlip(string sKey, string sType, string sStart, string sEnd){
            string ret = "";
            char[] arrKey = sKey.ToCharArray();
            int nStart = int.Parse(sStart);
            int nEnd = int.Parse(sEnd);
            int i;

            if(sType == "Upper"){
                for(i = nStart; i < nEnd; i++){
                    if(char.IsLower(arrKey[i])){
                        arrKey[i] = char.ToUpper(arrKey[i]);
                    }
                }
            }
            else if(sType == "Lower"){
                for(i = nStart; i < nEnd; i++){
                    if(char.IsUpper(arrKey[i])){
                        arrKey[i] = char.ToLower(arrKey[i]);
                    }
                }              
            }

            ret = new string(arrKey);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(ret);           
            Console.ResetColor(); 

            return ret;
        }

        public static string KeySlice(string sKey, string sStart, string sEnd){
            string ret = "";
            int nStart = int.Parse(sStart);
            int nEnd = int.Parse(sEnd);

            ret = sKey.Remove(nStart, nEnd - nStart);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(ret);           
            Console.ResetColor(); 

            return ret;
        }

    }
}
