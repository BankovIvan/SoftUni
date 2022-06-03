using System;

namespace _09_Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrSequence;
            int i, nColons, 
                nCurrentLength, nCurrentIndex, nCurrentSum, nCurrentRow, 
                nMaxLength, /*nMaxSum,*/ nMaxIndex, /*nMaxRow,*/ 
                nBestLength, nBestIndex, nBestSum, nBestRow;
            string sInput, sBestSample;

            nColons = int.Parse(Console.ReadLine());

            sInput = Console.ReadLine();

            nCurrentRow = 0;
            /*nMaxRow = 0*/;
            nBestLength = 0;
            nBestIndex = nColons - 1;
            nBestSum = -1;
            nBestRow = 0;
            sBestSample = "n/a";

            while (sInput != "Clone them!")
            {
                arrSequence = Array.ConvertAll(
                                                sInput.Split('!', StringSplitOptions.RemoveEmptyEntries),
                                                new Converter<string, int>(int.Parse)
                                                );

                nCurrentLength = 0;
                nCurrentSum = 0;
                nCurrentIndex = 0;
                nMaxLength = 0;
                //nMaxSum = 0;
                nMaxIndex = 0;

                nCurrentRow++;

                //for (i = 0; i < arrSequence.Length; i++)
                for (i = 0; i < nColons; i++)
                {
                    if (arrSequence[i] == 1)
                    {
                        if (nCurrentLength == 0)
                        {
                            nCurrentIndex = i;
                        }
                        nCurrentLength++;
                        nCurrentSum++;
                    }
                    else
                    {
                        if (nCurrentLength > nMaxLength)
                        {
                            nMaxLength = nCurrentLength;
                            nMaxIndex = nCurrentIndex;
                        }
                        nCurrentLength = 0;
                        //nCurrentSum = 0;
                        nCurrentIndex = 0;
                    }
                }

                if (nCurrentLength > nMaxLength) //Again if no zeroes found. 
                {
                    nMaxLength = nCurrentLength;
                    nMaxIndex = nCurrentIndex;
                }

                if (
                    /*
                    (nBestLength < nMaxLength) ||
                        ((nBestLength == nMaxLength) && ((nBestIndex > nMaxIndex) ||
                            ((nBestIndex == nMaxIndex) && (nBestSum < nCurrentSum))))
                    */

                    //currentMaxCountOfOnes > maxCountOfOnes || currentBestIndex < bestSequenceIndex || currentArr.Sum() > bestSequenceSum

                    (nBestLength < nMaxLength || nBestIndex > nMaxIndex || nBestSum < nCurrentSum)

                    /*
                    (nBestLength < nMaxLength) ||
                    ((nBestLength == nMaxLength) && (nBestIndex > nMaxIndex)) ||
                    ((nBestLength == nMaxLength) && (nBestIndex == nMaxIndex) && (nBestSum < nCurrentSum))
                    */

                    )
                {
                    nBestLength = nMaxLength;
                    nBestIndex = nMaxIndex;
                    nBestRow = nCurrentRow;
                    nBestSum = nCurrentSum;
                    sBestSample = string.Join(' ', arrSequence);
                }

                sInput = Console.ReadLine();
            }

            Console.WriteLine("Best DNA sample {0} with sum: {1}.", nBestRow, nBestSum);
            Console.WriteLine(sBestSample);

        }
    }
}
