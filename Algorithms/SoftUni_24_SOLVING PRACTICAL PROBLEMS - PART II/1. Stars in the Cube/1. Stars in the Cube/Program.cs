using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

class Program
{
    static BigInteger total = 0;

    static void Main(string[] args)
    {
        int N;
        char[,,] cube;
        SortedDictionary<char, BigInteger> counts;

        N = int.Parse(Console.ReadLine());

        cube = ReadCube(N);

        counts = CheckCube(cube, N);

        Console.WriteLine(total.ToString());
        foreach (var item in counts)
        {
            if (item.Value > 0)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value.ToString());
            }
        }

        return;
    }

    private static SortedDictionary<char, BigInteger> CheckCube(char[,,] cube, int N)
    {
        int i, j, k;
        SortedDictionary<char, BigInteger> counts = new SortedDictionary<char, BigInteger>();

        for (i = 0; i < N; i++)
        {
            for (j = 0; j < N; j++)
            {
                for (k = 0; k < N; k++)
                {
                    if (!counts.ContainsKey(cube[i, j, k]))
                    {
                        counts.Add(cube[i, j, k], 0);
                    }

                    if (CheckStar(cube, N, i, j, k))
                    {
                        counts[cube[i, j, k]] = counts[cube[i, j, k]] + 1;
                        total = total + 1;
                    }
                }
            }
        }

        return counts;

    }

    private static bool CheckStar(char[,,] cube, int N, int i, int j, int k)
    {
        int x, y, z;

        //TOP
        x = i - 1;
        y = j;
        z = k;
        if ((x < 0 || x >= N) || (y < 0 || y >= N) || (z < 0 || z >= N))
        {
            return false;
        }
        if (cube[i, j, k] != cube[x, y, z])
        {
            return false;
        }

        //BOTTOM
        x = i + 1;
        y = j;
        z = k;
        if ((x < 0 || x >= N) || (y < 0 || y >= N) || (z < 0 || z >= N))
        {
            return false;
        }
        if (cube[i, j, k] != cube[x, y, z])
        {
            return false;
        }

        //UP
        x = i;
        y = j - 1;
        z = k;
        if ((x < 0 || x >= N) || (y < 0 || y >= N) || (z < 0 || z >= N))
        {
            return false;
        }
        if (cube[i, j, k] != cube[x, y, z])
        {
            return false;
        }

        //DOWN
        x = i;
        y = j + 1;
        z = k;
        if ((x < 0 || x >= N) || (y < 0 || y >= N) || (z < 0 || z >= N))
        {
            return false;
        }
        if (cube[i, j, k] != cube[x, y, z])
        {
            return false;
        }

        //LEFT
        x = i;
        y = j;
        z = k - 1;
        if ((x < 0 || x >= N) || (y < 0 || y >= N) || (z < 0 || z >= N))
        {
            return false;
        }
        if (cube[i, j, k] != cube[x, y, z])
        {
            return false;
        }

        //RIGHT
        x = i;
        y = j;
        z = k + 1;
        if ((x < 0 || x >= N) || (y < 0 || y >= N) || (z < 0 || z >= N))
        {
            return false;
        }
        if (cube[i, j, k] != cube[x, y, z])
        {
            return false;
        }

        return true;
    }

    private static char[,,] ReadCube(int N)
    {
        int i, j, k, m;
        string[] s;
        char[] separators = { '|', ' ' };
        char[,,] cube = new char[N, N, N];

        for (i = 0; i < N; i++)
        {
            //Console.Write("    ");
            s = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            m = 0;

            for (j = 0; j < N; j++)
            {

                for (k = 0; k < N; k++)
                {
                    cube[j, i, k] = s[m].First();
                    m++;

                }
            }

        }

        return cube;

    }
}

    /*private static void PrintCube(char[,,] cube)
    {
        int i, j, k;
        string s;

        for(i = 0; i < cube.GetLength(0); i++)
        {
            s = " | ";

            for (j = 0; j < cube.GetLength(1); j++)
            {
                

                for (k = 0; k < cube.GetLength(2); k++)
                {
                    s = s + cube[j, i, k].ToString() + " ";
                }

                s = s + " | ";
            }

            Console.WriteLine(s);
        }
    }

}
*/