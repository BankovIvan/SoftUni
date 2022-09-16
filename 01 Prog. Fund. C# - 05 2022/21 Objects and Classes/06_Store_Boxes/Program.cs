using System;
using System.Collections.Generic;
using System.Numerics;

namespace _06_Store_Boxes
{
    class Program
    {
        class Item {
            public string Name {get; set;}
            public double Price{get; set;}
        }

        class Box{
            public Item objItem {get; set;}
            public string sSerialNumber {get; set;}

            public int nQuantity {get; set;}

            public decimal dPriceBox {get; set;}

            public Box(){
                objItem = new Item();
            }

        }

        static void Main(string[] args)
        {
            string[] arrInput;
            List<Box> lstBoxes = new List<Box>();
            Box objNextBox;

            arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while(! String.Equals(arrInput[0], "End", StringComparison.OrdinalIgnoreCase)){

                objNextBox = new Box();

                objNextBox.sSerialNumber = arrInput[0];
                objNextBox.objItem.Name = arrInput[1];
                objNextBox.nQuantity = int.Parse(arrInput[2]);
                objNextBox.objItem.Price = double.Parse(arrInput[3]);
                objNextBox.dPriceBox = (decimal) (objNextBox.nQuantity * objNextBox.objItem.Price);

                lstBoxes.Add(objNextBox);

                arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            lstBoxes.Sort(delegate(Box x, Box y){
                return y.dPriceBox.CompareTo(x.dPriceBox);
            });

            foreach(Box objCurrentBox in lstBoxes){
                Console.WriteLine(objCurrentBox.sSerialNumber);
                Console.WriteLine("-- {0} - ${1:F2}: {2}", 
                    objCurrentBox.objItem.Name, objCurrentBox.objItem.Price, objCurrentBox.nQuantity);
                Console.WriteLine("-- ${0:F2}", objCurrentBox.dPriceBox);
            }

        }
    }
}