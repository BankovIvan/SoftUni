using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int i, j, N, tmp = 0, total = 0;
        bool ix, iy;
        int[] intersect;
        List<int[]> rectangles = new List<int[]>();
        List<int[]> intersects = new List<int[]>();
        string[] data;

        N = int.Parse(Console.ReadLine());
        intersect = new int[4];

        for (i = 0; i < N; i++)
        {
            Console.Write("    ");
            /*
            data = Console.ReadLine().Split(' ');

            j = 0;
            foreach (var item in data)
            {
                if(int.TryParse(item, out tmp))
                {
                    intersect[j] = tmp;
                    j++;
                }
                
            }

            if(j == 4)
            {
                rectangles.Add((int[]) intersect.Clone());
            }
            */
            rectangles.Add(Console.ReadLine().Split().Select(int.Parse).ToArray());

        }

        for(i = -2000; i <= 2000; i++)  // X
        {
            for (j = -2000; j <= 2000; j++)  // Y
            {
                tmp = 0;
                foreach (var item in rectangles)
                {
                    if(item[0] <= i && item[1] > i && item[2] <= j && item[3] > j)
                    {
                        tmp++;

                    }
                }

                if (tmp > 1)
                {
                    total++;
                }

            }
        }

        Console.WriteLine(total);















        /*
        while (rectangles.Count > 1)
        {
            i = rectangles.Count - 1;

            for(j = i - 1; j >= 0; j--)
            {
                //Check for intersection:
                ix = (rectangles[i][1] > rectangles[j][0]) && (rectangles[i][0] < rectangles[j][1]);
                iy = (rectangles[i][3] > rectangles[j][2]) && (rectangles[i][2] < rectangles[j][3]);

                if (ix && iy)
                {
                    intersects.Add(new int[] {
                        Math.Max(rectangles[i][0], rectangles[j][0]),
                        Math.Min(rectangles[i][1], rectangles[j][1]),
                        Math.Max(rectangles[i][2], rectangles[j][2]),
                        Math.Min(rectangles[i][3], rectangles[j][3])
                    });
                }

            }

            rectangles.RemoveAt(i);
        }

        rectangles = null;

        Console.WriteLine(CycleIntersects(intersects));
        */




        return;

    }

    private static long CycleIntersects(List<int[]> rectangles)
    {
        int i, j;
        bool ix, iy;
        long areaTotal = 0;
        List<int[]> intersects; // = new List<int[]>();

        if (rectangles.Count == 0)
        {
            //Nothing to return;
            //Should never happend!
            return 0;
        }

        //List[0] element;
        areaTotal = (rectangles[0][1] - rectangles[0][0]) * (rectangles[0][3] - rectangles[0][2]);

        if (rectangles.Count == 1)
        {
            //Intersect area;
            return areaTotal;
        }

        while (rectangles.Count > 1)
        {
            intersects = new List<int[]>();
            i = rectangles.Count - 1;
            areaTotal = areaTotal + (rectangles[i][1] - rectangles[i][0]) * (rectangles[i][3] - rectangles[i][2]);

            for (j = i - 1; j >= 0; j--)
            {
                //Check for intersection:
                ix = (rectangles[i][1] > rectangles[j][0]) && (rectangles[i][0] < rectangles[j][1]);
                iy = (rectangles[i][3] > rectangles[j][2]) && (rectangles[i][2] < rectangles[j][3]);

                if (ix && iy)
                {
                    intersects.Add(new int[] {
                        Math.Max(rectangles[i][0], rectangles[j][0]),
                        Math.Min(rectangles[i][1], rectangles[j][1]),
                        Math.Max(rectangles[i][2], rectangles[j][2]),
                        Math.Min(rectangles[i][3], rectangles[j][3])
                    });
                }

            }

            areaTotal = areaTotal - CycleIntersects(intersects);

            intersects = null;

            rectangles.RemoveAt(i);
        }

        return areaTotal;

    }
}
