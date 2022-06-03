using System;

namespace _10_LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nPosition, nMove, nNext, nSize;
            int[] arrField, arrInitial;
            string sInput;
            string[] sCommands;

            nSize = int.Parse(Console.ReadLine());

            arrField = new int[nSize];

            arrInitial = Array.ConvertAll(
                                                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                                                new Converter<string, int>(int.Parse)
                                                );

            for(i = 0; i < arrInitial.Length; i++)
            {
                if(arrInitial[i] >= 0 && arrInitial[i] < nSize)
                {
                    arrField[arrInitial[i]] = 1;
                }
            }

            sInput = Console.ReadLine();
            sCommands = new string[3];

            while(sInput != "end")
            {

                sCommands = sInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                nPosition = int.Parse(sCommands[0]);
                nMove = int.Parse(sCommands[2]);

                if(sCommands[1] == "left")
                {
                    nMove *= -1;
                }

                nNext = nPosition + nMove;

                if (nPosition >= 0 && nPosition < nSize)
                {
                    if(arrField[nPosition] == 1)
                    {

                        arrField[nPosition] = 0;

                        while (nNext >= 0 && nNext < nSize)
                        {

                            if(arrField[nNext] == 0)
                            {
                                arrField[nNext] = 1;
                                break;
                            }

                            nNext += nMove;
                        }
                    }
                }


                sInput = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', arrField));

        }
    }
}
