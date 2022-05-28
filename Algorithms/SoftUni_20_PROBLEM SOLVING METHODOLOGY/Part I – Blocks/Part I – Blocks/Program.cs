using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int i;
        int nLetters = 0;
        int nCount = 4;
        char[] block;
        char[] alphabet;
        long total = 0;
        HashSet<string> blocks = new HashSet<string>();
        /*2*HashSet<string> rotation = new HashSet<string>();*/
        bool[] used;

        nLetters = int.Parse(Console.ReadLine());

        if (nLetters < nCount || nLetters > 26)
        {
            //Console.WriteLine("Number of blocks: 0");
            return;
        }

        block = new char[nCount];
        used = new bool[nLetters];
        alphabet = new char[nLetters];
        for (i = 0; i < nLetters; i++)
        {
            alphabet[i] = (char)('A' + i);
        }


        total = ComputeNext(blocks, /*2*rotation,*/ block, alphabet, used, nLetters, 0);

        Console.WriteLine("Number of blocks: {0}", total);

        foreach (var item in blocks)
        {
            Console.WriteLine(string.Join("", item));
        }

        return;

    }

    private static long ComputeNext(HashSet<string> blocks, /*2*HashSet<string> rotation,*/ char[] block, char[] alphabet, bool[] used, int nLetters, int index)
    {
        int i;
        long ret = 0;
        string s;
        char c;

        if (index >= block.Length)
        {
            s = string.Join("", block);
            /*2*if (!rotation.Contains(s))
            {*/
                blocks.Add(s);
                /*2*rotation.Add(s);*/

            /*
            c = block[0];
            block[0] = block[1];
            block[1] = block[2];
            block[2] = block[3];
            block[3] = c;
            s = string.Join("", block);
            rotation.Add(s);

            c = block[0];
            block[0] = block[1];
            block[1] = block[2];
            block[2] = block[3];
            block[3] = c;
            s = string.Join("", block);
            rotation.Add(s);

            c = block[0];
            block[0] = block[1];
            block[1] = block[2];
            block[2] = block[3];
            block[3] = c;
            s = string.Join("", block);
            rotation.Add(s);

            c = block[0];
            block[0] = block[1];
            block[1] = block[2];
            block[2] = block[3];
            block[3] = c;
            s = string.Join("", block);
            rotation.Add(s);
            */

            //Console.WriteLine(s);
                return 1;
            /*2*}

            else
            {
                return 0;
            }
            */
        }
        // If rotation return 0;

        for (i = 0; i < nLetters; i++)
        {
            if(used[i] != true)
            {
                used[i] = true;
                block[index] = alphabet[i];
                ret += ComputeNext(blocks, /*2*rotation,*/ block, alphabet, used, nLetters, index + 1);
                used[i] = false;
            }

            if(index == 0)
            {
                used[i] = true;
            }

        }

        return ret;
    }
}
