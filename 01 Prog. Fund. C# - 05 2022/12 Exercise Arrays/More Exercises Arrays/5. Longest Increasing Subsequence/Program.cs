using System;

namespace _5._Longest_Increasing_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums, len, prev;
            int i, j, nMaxValue, nMaxIndex;
            string sResult;

            nums = Array.ConvertAll(
                            Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                            new Converter<string, int>(int.Parse)
                        );

            len = new int[nums.Length];
            prev = new int[nums.Length];

            len[0] = 1;
            prev[0] = -1;
            nMaxValue = 0;
            nMaxIndex = 0;

            for (i = 1; i < nums.Length; i++)
            {
                //nMaxLen = 0;
                len[i] = 1;
                prev[i] = -1;

                //for(j = i - 1; j >= 0; j--)
                for (j = 0; j < i; j++)
                {
                    if(nums[i] > nums[j] && len[i] <= len[j])
                    {
                        //nMaxLen = len[j];
                        len[i] = len[j] + 1;
                        prev[i] = j;

                    }

                }

            }

            for (i = len.Length - 1; i >= 0; i--)
            {
                if (nMaxValue <= len[i])
                {
                    nMaxValue = len[i];
                    nMaxIndex = i;
                }
            }

            sResult = "";

            for (i = nMaxIndex; i >= 0; i = prev[i])
            {
                sResult = nums[i] + " " + sResult;
            }

            Console.WriteLine(sResult);

        }
    }
}
