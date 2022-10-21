namespace _04_Qucksort
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    //using System.Reflection.Metadata.Ecma335;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrInput = Array.ConvertAll(
                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                new Converter<string, int>(int.Parse));

            List<int> lst = new List<int>(arrInput);
            lst.Sort();

            //Quick.Sort(arrInput);
            //QuickSortHelper(arrInput, 0, arrInput.Length - 1);

            //Console.WriteLine(String.Join(' ', arrInput));
            Console.WriteLine(String.Join(' ', lst));
        }

        public static void QuickSortHelper(int[] array, int startIdx, int endIdx)
        {
            if (startIdx >= endIdx) return;

            var pivotIdx = startIdx;
            var leftIdx = startIdx + 1;
            var rightIdx = endIdx;
            while (leftIdx <= rightIdx)
            {
                if (array[leftIdx] > array[pivotIdx] && array[rightIdx] < array[pivotIdx])
                {
                    int tmp1 = array[leftIdx];
                    array[leftIdx] = array[rightIdx];
                    array[rightIdx] = tmp1;
                }

                if (array[leftIdx] <= array[pivotIdx])
                {
                    leftIdx += 1;
                }

                if (array[rightIdx] >= array[pivotIdx])
                {
                    rightIdx -= 1;
                }

            }

            int tmp2 = array[pivotIdx];
            array[pivotIdx] = array[rightIdx];
            array[rightIdx] = tmp2;

            var isLeftSubArraysSmaller = rightIdx - 1 - startIdx < endIdx - (rightIdx + 1);
            if (isLeftSubArraysSmaller)
            {
                QuickSortHelper(array, startIdx, rightIdx - 1);
                QuickSortHelper(array, rightIdx + 1, endIdx);
            }
            else
            {
                QuickSortHelper(array, rightIdx + 1, endIdx);
                QuickSortHelper(array, startIdx, rightIdx - 1);
            }

        }

    }

    public class Quick
    {
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort<T>(T[] arr, int lo, int hi) where T: IComparable<T>
        {
            if(lo >= hi)
            {
                return;
            }

            int p = Partition(arr, lo, hi);
            Sort(arr, lo, p - 1);
            Sort(arr, p + 1, hi);

        }

        private static int Partition<T>(T[] arr, int lo, int hi) where T: IComparable<T>
        {
            int ret = lo;

            if(lo >= hi)
            {
                return ret;
            }

            int i = lo;
            int j = hi + 1;
            while (true)
            {
                while (arr[++i].CompareTo(arr[lo]) < 0)
                {
                    if (i == hi) break;
                }

                while (arr[lo].CompareTo(arr[--j]) < 0)
                {
                    if(j == lo) break;
                }

                if(i >= j) break;
                Swap(arr, i, j);

            }

            Swap(arr, lo, j);
            ret = j;

            return ret;
        }

        private static void Swap<T>(T[] arr, int i, int j) where T: IComparable<T>
        {
            T tmp = arr[i];
            arr[i] = arr[j];    
            arr[j] = tmp;
        }

    }
}
