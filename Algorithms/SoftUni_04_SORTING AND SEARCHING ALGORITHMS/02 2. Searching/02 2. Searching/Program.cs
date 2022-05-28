using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int x = int.Parse(Console.ReadLine());

        //Console.WriteLine(BinarySearch1(arr, x, 0, arr.Length - 1));
        //Console.WriteLine(BinarySearch2(arr, x, 0, arr.Length - 1));
        Console.WriteLine(BinarySearch3(arr, x, 0, arr.Length - 1));

        /*
        StringBuilder builder = new StringBuilder();
        foreach (var num in arr)
        {
            builder.Append(num + " ");
        }

        Console.WriteLine(builder);
        */

        return;

    }
    private static int BinarySearch3(int[] arr, int x, int lo, int hi)
    {
        int mid = -1;

        while (lo <= hi)
        {
            mid = lo + (hi - lo) / 2;

            if (arr[mid] == x) return mid;
            else if (arr[mid] > x) hi = mid - 1;
            else lo = mid + 1;
        }

        return mid;

        return -1;

    }

    private static int BinarySearch2(int[] arr, int x, int lo, int hi)
    {
        int mid;

        while(lo <= hi)
        {
            mid = lo + (hi - lo) / 2;

            if (arr[mid] == x) return mid;
            else if (arr[mid] > x) hi = mid - 1;
            else lo = mid + 1;
        }

        return -1;

    }

    private static int BinarySearch1(int[] arr, int x, int lo, int hi)
    {
        int mid;

        if (lo > hi)
        {
            return -1;
        }

        mid = lo + (hi - lo) / 2;

        if (arr[mid] == x)
        {
            return mid;
        }

        else if (arr[mid] > x)
        {
            return BinarySearch1(arr, x, lo, mid - 1);
        }

        else
        {
            return BinarySearch1(arr, x, mid + 1, hi);
        }

        //return -1;

    }
}
