using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace _07_Vehicle_Catalogue
{
    class Program
    {
        class Truck
        {
            public string sBrand { get; set; }
            public string sModel { get; set; }
            public int nWeight { get; set; }
        }

        class Car
        {
            public string sBrand { get; set; }
            public string sModel { get; set; }
            public int nHP { get; set; }
        }

        class Catalogue
        {
            public List<Truck> lstTrucks { get; set; }
            public List<Car> lstCars { get; set; }

            public Catalogue()
            {
                lstTrucks = new List<Truck>();
                lstCars = new List<Car>();
            }

        }

        static void Main(string[] args)
        {
            Catalogue objCatalogue = new Catalogue();
            string[] arrInput;

            arrInput = Console.ReadLine().Split('/', StringSplitOptions.RemoveEmptyEntries);

            //while(! String.Equals(arrInput[0], "End", StringComparison.OrdinalIgnoreCase)){
            while (arrInput[0] != "end")
            {

                if (arrInput[0] == "Truck")
                {
                    objCatalogue.lstTrucks.Add(new Truck()
                    {
                        sBrand = arrInput[1],
                        sModel = arrInput[2],
                        nWeight = int.Parse(arrInput[3])
                    });
                }
                else if (arrInput[0] == "Car")
                {
                    objCatalogue.lstCars.Add(new Car()
                    {
                        sBrand = arrInput[1],
                        sModel = arrInput[2],
                        nHP = int.Parse(arrInput[3])
                    });
                }

                arrInput = Console.ReadLine().Split('/', StringSplitOptions.RemoveEmptyEntries);
            }

            //            objCatalogue.lstCars.Sort(delegate(Car x, Car y){
            //                                        return x.sBrand.CompareTo(y.sBrand);});

            //            objCatalogue.lstCars.Sort((x, y) => string.Compare(x.sBrand, y.sBrand));

            //            objCatalogue.lstTrucks.Sort(delegate(Truck x, Truck y){
            //                                        return x.sBrand.CompareTo(y.sBrand);});

            //            objCatalogue.lstTrucks.Sort((x, y) => string.Compare(x.sBrand, y.sBrand));

            //
            // !!! STABLE SORT REQUIRED BY JUDGE !!!
            //
            // USING LINQ !
            //
            if (objCatalogue.lstCars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car x in objCatalogue.lstCars.OrderBy(y => y.sBrand))
                {
                    Console.WriteLine("{0}: {1} - {2}hp", x.sBrand, x.sModel, x.nHP);
                }
            }

            if (objCatalogue.lstTrucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck x in objCatalogue.lstTrucks.OrderBy(y => y.sBrand))
                {
                    Console.WriteLine("{0}: {1} - {2}kg", x.sBrand, x.sModel, x.nWeight);
                }
            }

        }
    }
}