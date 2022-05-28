using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{

    //static int count = 0;
    static int[] CN;
    static int[] arr;
    static int[] needles;
    static int[] aux;  //Cost!
    //static int FirstNumberPosition = -1;
    //static int LastNumberPosition = -1;

    static void Main(string[] args)
    {
        int elements = -1;

        CN = Console.ReadLine().Split().Select(int.Parse).ToArray();
        arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        needles = Console.ReadLine().Split().Select(int.Parse).ToArray();
        aux = Enumerable.Repeat(0, arr.Length).ToArray();

        //Check with 1 element length;
        elements = BucketMove();
        BinarySearch(0, elements);

        Console.WriteLine(string.Join(" ", needles.Take(CN[1])));

        //Console.ReadLine();

        return;

    }

    private static int BucketMove()
    {
        int i = 0;
        int j = 0;
        int tmp = 0;

        //arr -> Input data array, modified to remove zeroes and duplicates;
        //aux -> Array to hol cost of each element;

 //       for (i = 0; i < arr.Length; i++)
 //       {

        while (i < arr.Length)
            {

            //if (arr[i] < arr[i + 1] && arr[i] > 0)
            if (arr[i] > 0)
            {

                //if (FirstNumberPosition < 0) FirstNumberPosition = i;
                //LastNumberPosition = i;

                if (arr[i] > tmp)
                {
                    tmp = arr[i];

                    arr[j] = arr[i];
                    aux[j] = i;
                    j++;
                    //break;
                }
                else if (arr[i] == tmp)
                {
                    aux[j - 1] = i;
                }


            }

            i++;
        }
//        }
        
        return j - 1;
    }

    private static void BinarySearch(int loIn, int hiIn)
    {
        int i, lo, mid, hi, tmp;
        int Temp1, Temp2;

        

        for (i = 0; i < needles.Length; i++)
        {
            Temp1 = needles[i];


            lo = loIn;
            hi = hiIn;
            tmp = 0;

            while (hi >= lo)
            {

                mid = lo + (hi - lo) / 2;

                Temp2 = arr[mid];

                if (needles[i] == arr[mid])
                {
                    //CalcResult(i, j);
                    tmp = mid;
                    break;
                }
                else if (hi == lo)
                {
                    if (needles[i] > arr[mid]) tmp = mid;
                    else tmp = mid - 1;

                    break;
                }
                else if (needles[i] > arr[mid])
                {
                    lo = mid + 1;
                    tmp = lo;
                }
                else
                {
                    hi = mid - 1;
                    tmp = hi;
                }

            }

            if (tmp <= loIn)
            {
                //if (FirstNumberPosition > 0) FirstNumberPosition--;
                //else FirstNumberPosition = 0;

                if(needles[i] <= arr[loIn] || arr[loIn] == 0) needles[i] = loIn;
                else needles[i] = aux[loIn] + 1;

            }
            else if (tmp > hiIn)
            {
                needles[i] = aux[hiIn] + 1;
            }
            else
            {

                if (needles[i] == arr[tmp]) needles[i] = aux[tmp-1] + 1;
                else needles[i] = aux[tmp] + 1;


            }


            Temp1 = needles[i];

        }
    }

}
