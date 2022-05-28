using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Mergesort<int>.Sort(arr);

        StringBuilder builder = new StringBuilder();
        foreach (var num in arr)
        {
            builder.Append(num + " ");
        }

        Console.WriteLine(builder);

        return;

    }

}

public class Mergesort<T> where T : IComparable
{
    private static T[] aux;

    public static void Sort(T[] arr)
    {
        aux = new T[arr.Length];
        Sort(arr, 0, arr.Length - 1);

    }

    private static void Sort(T[] arr, int lo, int hi)
    {
        int mid;
        if (lo >= hi)
        {
            return;
        }

        mid = lo + (hi - lo) / 2;
        Sort(arr, lo, mid);
        Sort(arr, mid + 1, hi);
        Merge(arr, lo, mid, hi);

    }

    private static void Merge(T[] arr, int left, int mid, int right)
    {
        int index, i, j, k;

        if (IsLess(arr[mid], arr[mid + 1])) return;

        for (index = left; index <= right; index++)
        {
            aux[index] = arr[index];
        }

        i = left;
        j = mid + 1;
        for(k = left; k <= right; k++)
        {
            if(i > mid)
            {
                arr[k] = aux[j++];
            }

            else if (j > right)
            {
                arr[k] = aux[i++];
            }

            else if (IsLess(aux[i], aux[j]))
            {
                arr[k] = aux[i++];
            }
            else
            {
                arr[k] = aux[j++];
            }
        }

    }

    private static bool IsLess(T i, T j)
    {
        return i.CompareTo(j) < 0;
    }

    private static bool IsSorted(T[] a, int lo, int hi)
    {
        int i;

        for(i = lo + 1; i < hi; i++)
        {
            if(IsLess(a[i], a[i - 1]))
            {
                return false;
            }
        }

        return true;
    }
}