namespace _03_Merge_Sort
{
    using System;
    using System.Runtime.CompilerServices;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrInput = Array.ConvertAll(
                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                new Converter<string, int>(int.Parse));

            Mergesort<int>.Sort(arrInput);

            Console.WriteLine(String.Join(' ', arrInput));
        }
    }

    public class Mergesort<T> where T : IComparable
    {
        private static T[] aux;

        private static void Merge(T[] arr, int lo, int mid, int hi)
        {
            // arr[mid] < arr[mid+1]
            if (arr[mid].CompareTo(arr[mid + 1]) < 0)
            {
                return;
            }

            for(int index = lo; index <= hi; index++)
            {
                aux[index] = arr[index];
            }

            int i = lo;
            int j = mid+1;
            for(int k = lo; k <= hi; k++)
            {
                if(j > hi)
                {
                    arr[k] = aux[i++];
                }
                else if(i > mid)
                {
                    arr[k] = aux[j++];
                }
                else if (aux[i].CompareTo(aux[j]) < 0) //aux[i] < aux[j]
                {
                    arr[k] = aux[i++];
                }
                else
                {
                    arr[k] = aux[j++];
                }
            }
        }

        private static void Sort(T[] arr, int lo, int hi)
        {
            if(lo >= hi)
            {
                return;
            }

            int mid = ((hi - lo) / 2) + lo;

            Sort(arr, lo, mid);
            Sort(arr, mid + 1, hi);
            Merge(arr, lo, mid, hi);

        }

        public static void Sort(T[] arr)
        {
            aux = new T[arr.Length];
            Sort(arr, 0, arr.Length - 1);
        }
    }
}
