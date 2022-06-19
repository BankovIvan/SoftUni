using System;
using System.Collections.Generic;

namespace _04_List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {


            string[] sCommand;
            List<int> lstNumbers; // = new List<int>();
            int nParam, nIndex;

            lstNumbers = new List<int>(Array.ConvertAll(
                                    Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                                    new Converter<string, int>(int.Parse)
                                    ));

            sCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (sCommand[0] != "End")
            {
                switch (sCommand[0])
                {
                    case "Add":
                        nParam = int.Parse(sCommand[1]);
                        AddListElement(lstNumbers, nParam);
                        break;

                    case "Insert":
                        nParam = int.Parse(sCommand[1]);
                        nIndex = int.Parse(sCommand[2]);
                        if(!InsertListElement(lstNumbers, nParam, nIndex))
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;

                    /*
                    case "Remove":
                        nParam = int.Parse(sCommand[1]);
                        RemoveListElement(lstNumbers, nParam);
                        break;
                    */

                    /////////////////////////////////////////////////
                    //case "RemoveAt":
                    case "Remove":
                        nIndex = int.Parse(sCommand[1]);
                        if (!RemoveAtIndexListElement(lstNumbers, nIndex))
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;

                    case "Shift":
                        nParam = int.Parse(sCommand[2]);
                        ShiftListElement(lstNumbers, nParam, sCommand[1]);
                        break;

                        /*
                    case "RemoveAll":
                        nParam = int.Parse(sCommand[1]);
                        RemoveAllMatchingListElements(lstNumbers, nParam);
                        break;
                        */

                    default:

                        break;
                }

                sCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(' ', lstNumbers));

        }

        private static bool RemoveAtIndexListElement(List<int> lstNumbers, int nIndex)
        {
            bool bRet = false;

            if (lstNumbers.Count <= 1)
            {
                return bRet;
            }

            if( nIndex >= 0 && nIndex < lstNumbers.Count)
            {
                lstNumbers.RemoveAt(nIndex);
                bRet = true;
            }

            return bRet;
        }

        private static void RemoveAllMatchingListElements(List<int> lstNumbers, int nParam)
        {
            // LAMBDA FUNCTION
            // bool MyLambda( int nCheck ) { return nCheck == nParam; }
            lstNumbers.RemoveAll(nCheck => nCheck == nParam);

            return;

        }

        private static void ShiftListElement(List<int> lstNumbers, int nParam, string sDirection)
        {
            if(sDirection == "left")
            {
                ShiftLeftListElement(lstNumbers, nParam);
            }
            else if (sDirection == "right")
            {
                ShiftRightListElement(lstNumbers, nParam);
            }

            return;

        }

        private static void ShiftRightListElement(List<int> lstNumbers, int nParam)
        {
            int i;

            if(lstNumbers.Count <= 1)
            {
                return;
            }

            for (i = 0; i < nParam; i++)
            {
                lstNumbers.Insert(0, lstNumbers[lstNumbers.Count-1]);
                lstNumbers.RemoveAt(lstNumbers.Count - 1);
            }

            return;

        }

        private static void ShiftLeftListElement(List<int> lstNumbers, int nParam)
        {
            int i;

            if (lstNumbers.Count <= 1)
            {
                return;
            }

            for (i = 0; i < nParam; i++)
            {
                lstNumbers.Add(lstNumbers[0]);
                lstNumbers.RemoveAt(0);
            }

            return;

        }

        private static void RemoveListElement(List<int> lstNumbers, int nParam)
        {

            lstNumbers.Remove(nParam);

            return;
        }

        private static bool InsertListElement(List<int> lstNumbers, int nParam, int nIndex)
        {

            bool bRet = false;

            if (nIndex >= 0 && nIndex <= lstNumbers.Count)
            {
                lstNumbers.Insert(nIndex, nParam);
                bRet = true;
            }

            return bRet;
        }

        private static void AddListElement(List<int> lstNumbers, int nParam)
        {
            lstNumbers.Add(nParam);
            return;
        }
    }
}
