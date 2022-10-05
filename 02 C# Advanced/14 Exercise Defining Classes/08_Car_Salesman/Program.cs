namespace _08_Car_Salesman
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            int nRepeat = int.Parse(Console.ReadLine());
            Dictionary<string, EngineClass> dicEngines = new Dictionary<string, EngineClass>();
            List<CarClass> lstCars = new List<CarClass>();

            for(int i = 0; i < nRepeat; i++)
            {
                string[] arrEngines = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if(arrEngines.Length > 3)
                {
                    dicEngines.Add(arrEngines[0], new EngineClass(
                                                        arrEngines[0],
                                                        int.Parse(arrEngines[1]),
                                                        arrEngines[2],
                                                        arrEngines[3]
                                                        ));
                }
                else if(arrEngines.Length > 2)
                {
                    dicEngines.Add(arrEngines[0], new EngineClass(
                                                        arrEngines[0],
                                                        int.Parse(arrEngines[1]),
                                                        arrEngines[2]
                                                        ));
                }
                else if(arrEngines.Length > 1)
                {
                    dicEngines.Add(arrEngines[0], new EngineClass(
                                                        arrEngines[0],
                                                        int.Parse(arrEngines[1])
                                                        ));
                }
            }

            nRepeat = int.Parse(Console.ReadLine());
            for (int i = 0; i < nRepeat; i++)
            {
                string[] arrCars = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (arrCars.Length > 3)
                {
                    lstCars.Add(new CarClass(arrCars[0], dicEngines[arrCars[1]], arrCars[2], arrCars[3]));
                }
                else if (arrCars.Length > 2)
                {
                    lstCars.Add(new CarClass(arrCars[0], dicEngines[arrCars[1]], arrCars[2]));
                }
                else if (arrCars.Length > 1)
                {
                    lstCars.Add(new CarClass(arrCars[0], dicEngines[arrCars[1]]));
                }

            }

            foreach(var v in lstCars)
            {
                Console.WriteLine(v);
            }
        }
    }
}
