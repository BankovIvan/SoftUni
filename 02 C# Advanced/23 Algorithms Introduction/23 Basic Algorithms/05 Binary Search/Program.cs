namespace _05_Binary_Search
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrInput = Array.ConvertAll(
                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                new Converter<string, int>(int.Parse));

            int key = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch.IndexOf(arrInput, key));
        }
    }

    public class BinarySearch
    {
        public static int IndexOf(int[] arr, int key)
        {
            int ret = -1;

            int lo = 0;
            int hi = arr.Length - 1;
            while(lo <= hi)
            {
                int mid = ((hi - lo) / 2) + lo;
                
                if(key < arr[mid])
                {
                    hi = mid - 1;
                }
                else if(key > arr[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    ret = mid;
                    break;
                }
            }

            return ret;
        }
    }
}
