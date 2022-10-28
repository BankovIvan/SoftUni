namespace NeedForSpeed
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(100, 100.0);
            vehicle.Drive(10);
            Console.WriteLine(vehicle.Fuel);

            Motorcycle motorcycle = new Motorcycle(100, 100.0);
            motorcycle.Drive(10);
            Console.WriteLine(motorcycle.Fuel);

            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(100, 100.0);
            raceMotorcycle.Drive(10);
            Console.WriteLine(raceMotorcycle.Fuel);

            CrossMotorcycle crossMotorcycle = new CrossMotorcycle(100, 100.0);
            crossMotorcycle.Drive(10);
            Console.WriteLine(crossMotorcycle.Fuel);

            Car car = new Car(100, 100.0);
            car.Drive(10);
            Console.WriteLine(car.Fuel);

            FamilyCar familyCar = new FamilyCar(100, 100.0);
            familyCar.Drive(10);
            Console.WriteLine(familyCar.Fuel);

            SportCar sportsCar = new SportCar(100, 100.0);
            sportsCar.Drive(10);
            Console.WriteLine(sportsCar.Fuel);

        }
    }
}
