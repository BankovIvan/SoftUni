using System;
using System.Text;

namespace _07_String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sInput, sOutput;
            int i, nExplosionStrength;

            sInput = new StringBuilder(Console.ReadLine());
            sOutput = new StringBuilder();

            //sOutput.Append(sInput[0]);
            nExplosionStrength = 0;

            for (i = 0; i < sInput.Length; i++)
            {
                if(sInput[i] == '>')
                {
                    sOutput.Append(sInput[i]);
                    nExplosionStrength += (int)(sInput[i+1] - '0');
                }
                else
                {
                    if(nExplosionStrength == 0)
                    {
                        sOutput.Append(sInput[i]);
                    }
                    else
                    {
                        nExplosionStrength--;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(sOutput);
            Console.ResetColor();
        }
    }
}
