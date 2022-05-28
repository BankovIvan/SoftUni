using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{

    static int count = 0;
    static int[] arr;
    static int[] aux;

    static void Main(string[] args)
    {
        arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        aux = new int[arr.Length];

        //Mergesort<int>.Sort(arr);

        SortAndCount(0, arr.Length - 1);

        /*
        StringBuilder builder = new StringBuilder();
        foreach (var num in arr)
        {
            builder.Append(num + " ");
        }

        Console.WriteLine(builder);
        */

        Console.WriteLine(count);

        return;

    }

    private static void SortAndCount(int lo, int hi)
    {
        int mid;
        if (lo >= hi)
        {
            return;
        }

        mid = lo + (hi - lo) / 2;
        SortAndCount(lo, mid);
        SortAndCount(mid + 1, hi);
        MergeAndCount(lo, mid, hi);
    }

    private static void MergeAndCount(int left, int mid, int right)
    {
        int index, i, j, k;

        if (arr[mid] <= arr[mid + 1]) return;

        for (index = left; index <= right; index++)
        {
            aux[index] = arr[index];
        }

        i = left;
        j = mid + 1;
        for (k = left; k <= right; k++)
        {
            if (i > mid)
            {
                arr[k] = aux[j++];
            }

            else if (j > right)
            {
                arr[k] = aux[i++];
            }

            else if (aux[i] <= aux[j])
            {
                arr[k] = aux[i++];
            }
            else
            {
                arr[k] = aux[j++];
                count = count + 1 + (mid - i);
                //j++;
            }
        }

    }
}
