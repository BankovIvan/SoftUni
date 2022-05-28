using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int index = 0;
        char[] vector, path;
        List<string> paths = new List<string>();

        path = Console.ReadLine().ToCharArray();
        vector = new char[path.Length];

        NavigatePath(paths, vector, path, index);

        Console.WriteLine(paths.Count);
        foreach (var item in paths)
        {
            Console.WriteLine(item);
        }

        return;

    }


    private static void NavigatePath(List<string> paths, char[] vector, char[] path, int index)
    {
        if(index >= path.Length)
        {
            paths.Add(new string(vector));
            return;
        }

        if (path[index] == 'L' || path[index] == '*')
        {
            vector[index] = 'L';
            NavigatePath(paths, vector, path, index + 1);
            //vector[index] = (char)0;
        }

        if (path[index] == 'R' || path[index] == '*')
        {
            vector[index] = 'R';
            NavigatePath(paths, vector, path, index + 1);
            //vector[index] = (char)0;
        }

        if (path[index] == 'S' || path[index] == '*')
        {
            vector[index] = 'S';
            NavigatePath(paths, vector, path, index + 1);
            //vector[index] = (char)0;
        }

        return;
    }
}

/*
private static HashSet<long> NavigatePath(HashSet<long> currentPositions, char path)
    {
        HashSet<long> nextPositions = new HashSet<long>();
        int x, y;
        long next;

        foreach (var item in currentPositions)
        {
            x = (int)(item / 32768);
            y = (int)(item & 32767);

            if (path == 'L' || path == '*')
            {
                next = (long)(x - 1) * 32768 + (long)(y);
                if (!nextPositions.Contains(next))
                {
                    nextPositions.Add(next);
                }
            }

            if (path == 'R' || path == '*')
            {
                next = (long)(x + 1) * 32768 + (long)(y);
                if (!nextPositions.Contains(next))
                {
                    nextPositions.Add(next);
                }
            }

            if (path == 'S' || path == '*')
            {
                next = (long)(x) * 32768 + (long)(y + 1);
                if (!nextPositions.Contains(next))
                {
                    nextPositions.Add(next);
                }
            }

        }

        return nextPositions;
    }
}
*/
