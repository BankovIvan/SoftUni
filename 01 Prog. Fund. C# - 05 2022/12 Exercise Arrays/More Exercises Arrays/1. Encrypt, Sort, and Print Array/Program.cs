using System;

namespace _1._Encrypt__Sort__and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            //A, E, I, O and U

            int i, j, nSum, nLines;
            string sName;
            //char c;
            int[] arrSequence;

            nLines = int.Parse(Console.ReadLine());
            arrSequence = new int[nLines];

            for (i = 0; i < nLines; i++)
            {
                sName = Console.ReadLine();
                nSum = 0;

                for(j = 0; j < sName.Length; j++)
                {
                    //c = sName[i];

                    switch (sName[j])
                    {
                        case 'A':
                        case 'a':
                        case 'E':
                        case 'e':
                        case 'I':
                        case 'i':
                        case 'O':
                        case 'o':
                        case 'U':
                        case 'u':

                            nSum += (int)sName[j] * sName.Length;
                            break;

                        default:

                            nSum += (int)sName[j] / sName.Length;
                            break;


                    }

                }

                arrSequence[i] = nSum;
            }

            Array.Sort(arrSequence);

            for(i = 0; i < arrSequence.Length; i++)
            {
                Console.WriteLine(arrSequence[i]);
            }
            

        }
    }
}
