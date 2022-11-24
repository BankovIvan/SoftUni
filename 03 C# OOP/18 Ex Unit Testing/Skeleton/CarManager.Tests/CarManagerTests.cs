namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private const string DEFAULT_MAKE = "Peugeot";
        private const string DEFAULT_MODEL = "2008";
        private const double DEFAULT_FUELCONSUMPTION = 10.0;
        private const double DEFAULT_FUELAMMOUNT = 0.0;
        private const double DEFAULT_FUELCAPACITY = 100.0;

        private Car defaultCar;

        [SetUp]
        public void Setup()
        {
            defaultCar = new Car(
                                DEFAULT_MAKE, 
                                DEFAULT_MODEL,
                                DEFAULT_FUELCONSUMPTION,
                                DEFAULT_FUELCAPACITY
                                );
        }

        [Test]
        public void Test_01_Car_Constructor_ValidData()
        {
            Assert.That(
                defaultCar.Make,
                Is.EqualTo(DEFAULT_MAKE),
                String.Format("Car constructor doesn't set Make propertly <{0}>.", defaultCar.Make));

            Assert.That(
                defaultCar.Model,
                Is.EqualTo(DEFAULT_MODEL),
                String.Format("Car constructor doesn't set Model propertly <{0}>.", defaultCar.Model));

            Assert.That(
                defaultCar.FuelConsumption,
                Is.EqualTo(DEFAULT_FUELCONSUMPTION),
                String.Format("Car constructor doesn't set FuelConsumption propertly <{0}>.", defaultCar.FuelConsumption));

            Assert.That(
                defaultCar.FuelAmount,
                Is.EqualTo(DEFAULT_FUELAMMOUNT),
                String.Format("Car constructor doesn't set FuelAmount propertly <{0}>.", defaultCar.FuelAmount));

            Assert.That(
                defaultCar.FuelCapacity,
                Is.EqualTo(DEFAULT_FUELCAPACITY),
                String.Format("Car constructor doesn't set FuelCapacity propertly <{0}>.", defaultCar.FuelCapacity));

        }

        [Test]
        public void Test_02_Car_Constructor_InvalidData()
        {

            Assert.Throws<ArgumentException>(
                () => defaultCar = new Car(null, DEFAULT_MODEL, DEFAULT_FUELCONSUMPTION, DEFAULT_FUELCAPACITY),
                "Car constructor with null Make property doesn't throw.");

            Assert.Throws<ArgumentException>(
                () => defaultCar = new Car("", DEFAULT_MODEL, DEFAULT_FUELCONSUMPTION, DEFAULT_FUELCAPACITY),
                "Car constructor with empty Make property doesn't throw.");

            Assert.Throws<ArgumentException>(
                () => defaultCar = new Car(DEFAULT_MAKE, null, DEFAULT_FUELCONSUMPTION, DEFAULT_FUELCAPACITY),
                "Car constructor with null Model property doesn't throw.");

            Assert.Throws<ArgumentException>(
                () => defaultCar = new Car(DEFAULT_MAKE, "", DEFAULT_FUELCONSUMPTION, DEFAULT_FUELCAPACITY),
                "Car constructor with empty Model property doesn't throw.");

            Assert.Throws<ArgumentException>(
                () => defaultCar = new Car(DEFAULT_MAKE, DEFAULT_MODEL, -1, DEFAULT_FUELCAPACITY),
                "Car constructor with negative FuelConsumption property doesn't throw.");

            Assert.Throws<ArgumentException>(
                () => defaultCar = new Car(DEFAULT_MAKE, DEFAULT_MODEL, 0, DEFAULT_FUELCAPACITY),
                "Car constructor with zeroe FuelConsumption property doesn't throw.");

            Assert.Throws<ArgumentException>(
                () => defaultCar = new Car(DEFAULT_MAKE, DEFAULT_MODEL, DEFAULT_FUELCONSUMPTION, -1),
                "Car constructor with negative FuelCapacity property doesn't throw.");

            Assert.Throws<ArgumentException>(
                () => defaultCar = new Car(DEFAULT_MAKE, DEFAULT_MODEL, DEFAULT_FUELCONSUMPTION, 0),
                "Car constructor with zeroe FuelCapacity property doesn't throw.");

        }

        [Test]
        public void Test_03_Car_Refuel_ValidData()
        {
            defaultCar.Refuel(1);
            Assert.That(
                defaultCar.FuelAmount,
                Is.EqualTo(1),
                String.Format("Car Refuel doesn't set FuelAmmount propertly <{0}>.", defaultCar.FuelAmount));

            defaultCar.Refuel(DEFAULT_FUELCAPACITY - 2);
            Assert.That(
                defaultCar.FuelAmount,
                Is.EqualTo(DEFAULT_FUELCAPACITY - 1),
                String.Format("Car Refuel doesn't set FuelAmmount propertly <{0}>.", defaultCar.FuelAmount));

            defaultCar.Refuel(DEFAULT_FUELCAPACITY);
            Assert.That(
                defaultCar.FuelAmount,
                Is.EqualTo(DEFAULT_FUELCAPACITY),
                String.Format("Car Refuel doesn't set FuelAmmount propertly <{0}>.", defaultCar.FuelAmount));

        }

        [Test]
        public void Test_04_Car_Refuel_InvalidData()
        {

            Assert.Throws<ArgumentException>(
                () => defaultCar.Refuel(-0.0001),
                "Car Refuel with negative FuelAmmount doesn't throw.");
            
            Assert.Throws<ArgumentException>(
                () => defaultCar.Refuel(0),
                "Car Refuel with zeroe FuelAmmount doesn't throw.");

        }


        [Test]
        public void Test_05_Car_Drive_ValidData()
        {
            defaultCar.Refuel(DEFAULT_FUELCAPACITY);
            defaultCar.Drive(DEFAULT_FUELCAPACITY * DEFAULT_FUELCONSUMPTION);

            Assert.That(
                defaultCar.FuelAmount,
                Is.EqualTo(0),
                String.Format("Car Drive doesn't set FuelAmmount propertly <{0}>.", defaultCar.FuelAmount));

        }

        [Test]
        public void Test_06_Car_Drive_InvalidData()
        {
            defaultCar.Refuel(DEFAULT_FUELCAPACITY);

            Assert.Throws<InvalidOperationException>(
                () => defaultCar.Drive(DEFAULT_FUELCAPACITY * DEFAULT_FUELCONSUMPTION + 0.0001),
                "Car Drive with not enough FuelAmmount doesn't throw.");

        }

    }
}