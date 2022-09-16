namespace _02_Fancy_Barcodes
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    //using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            string sBarcode, sDigits;
            int i, j, nRepeat, nStart, nEnd;
            bool bCorrect;

            nRepeat = int.Parse(Console.ReadLine());

            for(i = 0; i < nRepeat; i++){
                sBarcode = Console.ReadLine();
                
                nStart = GetStart(sBarcode);
                nEnd = GetEnd(sBarcode);
                bCorrect = true;
                sDigits = "";
                
                if(nStart == -1 || nEnd == -1 || (nEnd - nStart) < 5 ){
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid barcode");           
                    Console.ResetColor();    
                    continue;                
                }
                
                if((!char.IsUpper(sBarcode[nStart])) || (!char.IsUpper(sBarcode[nEnd]))){
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid barcode");           
                    Console.ResetColor();    
                    continue;                
                }

                for(j = nStart; j <= nEnd; j++){
                    if(char.IsLetter(sBarcode[j])){
                        continue;
                    }
                    else if(char.IsDigit(sBarcode[j])){
                        sDigits = sDigits + sBarcode[j];
                    }
                    else{
                        bCorrect = false;
                        break;
                    }
                }

                if(bCorrect == false){
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid barcode");           
                    Console.ResetColor(); 
                    continue;
                }
                
                if(sDigits == ""){
                    sDigits = "00";
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Product group: " + sDigits);           
                Console.ResetColor(); 

            }

        }

        static int GetStart(string sBarcode){
            int ret = -1, i;

            if(sBarcode[0] != '@'){
                return ret;
            }

            if(sBarcode [1] != '#'){
                return ret;
            }

            for(i = 2; i < sBarcode.Length; i++){
                if(sBarcode[i] != '#'){
                    break;
                }
            }

            if(i < sBarcode.Length - 1){
                ret = i;
            }

            return ret;
        }

        static int GetEnd(string sBarcode){
            int ret = -1, i;

            if(sBarcode[sBarcode.Length - 1] != '#'){
                return ret;
            }

            for(i = sBarcode.Length - 2; i >= 0; i--){
                if(sBarcode[i] == '#'){
                    continue;
                }
                else if(sBarcode[i] == '@'){
                    break;
                }
                else{
                    return ret;
                }
            }

            if(i > 0){
                ret = i - 1;
            }

            return ret;
        }


    }
}
