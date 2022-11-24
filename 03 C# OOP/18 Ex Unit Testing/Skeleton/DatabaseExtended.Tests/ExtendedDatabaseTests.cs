namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
    using System.Linq;
    using System;
    using ExtendedDatabase;

    [TestFixture]
    public class ExtendedDatabaseTests
    {

        private readonly Person[] EMPTY_ARRAY = new Person[] { };
        private readonly Person[] MIN_ARRAY = new Person[] {
            new Person(1, "AAA")
        };
        private readonly Person[] MAX_ARRAY = new Person[] {
            new Person(1, "AAA"),
            new Person(2, "BBB"),
            new Person(3, "CCC"),
            new Person(4, "DDD"),
            new Person(5, "EEE"),
            new Person(6, "FFF"),
            new Person(7, "GGG"),
            new Person(8, "HHH"),
            new Person(9, "III"),
            new Person(10, "JJJ"),
            new Person(11, "KKK"),
            new Person(12, "LLL"),
            new Person(13, "MMM"),
            new Person(14, "NNN"),
            new Person(15, "OOO"),
            new Person(16, "PPP")
        };
        private readonly Person[] OVERFILL_ARRAY = new Person[] {
            new Person(1, "AAA"),
            new Person(2, "BBB"),
            new Person(3, "CCC"),
            new Person(4, "DDD"),
            new Person(5, "EEE"),
            new Person(6, "FFF"),
            new Person(7, "GGG"),
            new Person(8, "HHH"),
            new Person(9, "III"),
            new Person(10, "JJJ"),
            new Person(11, "KKK"),
            new Person(12, "LLL"),
            new Person(13, "MMM"),
            new Person(14, "NNN"),
            new Person(15, "OOO"),
            new Person(16, "PPP"),
            new Person(17, "QQQ")
        };

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test_01_ExtendedDatabaseConstructorValidData()
        {
            Database database = new Database();
            Assert.That(
                database.Count,
                Is.EqualTo(0),
                "Database constructor with no elements doesn't set count propertly.");

            database = new Database(MIN_ARRAY);
            Assert.That(
                database.Count,
                Is.EqualTo(MIN_ARRAY.Length),
                String.Format("Database constructor with {0} elements doesn't set count propertly.", MIN_ARRAY.Length));

            database = new Database(MAX_ARRAY);
            Assert.That(
                database.Count,
                Is.EqualTo(MAX_ARRAY.Length),
                String.Format("Database constructor with {0} elements doesn't set count propertly.", MAX_ARRAY.Length));

        }

        [Test]
        public void Test_02_ExtendedDatabaseConstructorInvalidData()
        {
            Database database;

            Assert.Throws<ArgumentException>(
                () => database = new Database(OVERFILL_ARRAY),
                String.Format(
                    "Database constructor with {0} elements doesn't throw InvalidOperationException.",
                    OVERFILL_ARRAY.Length));

        }

        [Test]
        public void Test_03_ExtendedDatabaseStoringArrayLengthValid()
        {
            Database database = new Database(EMPTY_ARRAY);
            for (int i = 0; i < MAX_ARRAY.Length; i++)
            {
                database.Add(MAX_ARRAY[i]);
            }

            Assert.That(
                database.Count,
                Is.EqualTo(MAX_ARRAY.Length),
                String.Format("Database array doesn't have exactly {0} elements.", MAX_ARRAY.Length));

            //Exception ex = Assert.Throws<InvalidOperationException>(() => database.Add(MAX_ARRAY.Length + 1));

        }

        [Test]
        public void Test_04_ExtendedDatabaseStoringArrayLengthInvalid()
        {
            Database database = new Database(MAX_ARRAY);

            Exception ex = Assert.Throws<InvalidOperationException>(
                () => database.Add(OVERFILL_ARRAY[OVERFILL_ARRAY.Length - 1]),
                String.Format(
                    "Database array doesn't throw InvalidOperationException when adding element {0}.",
                    MAX_ARRAY.Length + 1));

        }

        [Test]
        public void Test_05_ExtendedDatabaseAddFunctionValidData()
        {
            Database database = new Database(EMPTY_ARRAY);
            for (int i = 0; i < MAX_ARRAY.Length; i++)
            {
                database.Add(MAX_ARRAY[i]);

                Assert.That(
                    database.FindById(MAX_ARRAY[i].Id).UserName,
                    Is.EqualTo(MAX_ARRAY[i].UserName),
                    String.Format("Element not added correctly at index {0}.", i));

                Assert.That(
                    database.Count,
                    Is.EqualTo(i + 1),
                    String.Format("Element not added correctly at index {0}.", i));

            }

            database.Remove();
            Assert.Throws<InvalidOperationException>(
                () => database.FindById(MAX_ARRAY[MAX_ARRAY.Length - 1].Id),
                "Element not set at the correct position in the database");


        }

        [Test]
        public void Test_06_ExtendedDatabaseAddFunctionInvalidData()
        {
            Database database = new Database(MAX_ARRAY);

            Assert.Throws<InvalidOperationException>(
                () => database.Add(OVERFILL_ARRAY[OVERFILL_ARRAY.Length - 1]),
                String.Format(
                    "Database array doesn't throw InvalidOperationException when adding element {0}.",
                    MAX_ARRAY.Length + 1));

            //database = new Database(MAX_ARRAY);

            database.Remove();

            Assert.Throws<InvalidOperationException>(
                () => database.Add(new Person(MAX_ARRAY[0].Id, MAX_ARRAY[MAX_ARRAY.Length - 1].UserName)),
                String.Format(
                    "Database array doesn't throw InvalidOperationException when adding element with existing ID.",
                    MAX_ARRAY.Length + 1));

            Assert.Throws<InvalidOperationException>(
                () => database.Add(new Person(MAX_ARRAY[MAX_ARRAY.Length - 1].Id, MAX_ARRAY[0].UserName)),
                String.Format(
                    "Database array doesn't throw InvalidOperationException when adding element with existing UserName.",
                    MAX_ARRAY.Length + 1));

        }

        [Test]
        public void Test_07_ExtendedDatabaseRemoveFunctionValidData()
        {
            Database database = new Database(MAX_ARRAY);

            for (int i = MAX_ARRAY.Length - 1; i >= 0; i--)
            {
                database.Remove();

                Assert.That(
                    database.Count,
                    Is.EqualTo(i),
                    String.Format("Element not removed correctly at index {0}.", i));

                Assert.Throws<InvalidOperationException>(
                    () => database.FindById(MAX_ARRAY[i].Id),
                    String.Format("Element not removed correctly at index {0}.", i));

                /* Assert.Throws<InvalidOperationException>(
                    () => database.FindByUsername(MAX_ARRAY[i].UserName),
                    String.Format("Element not removed correctly at index {0}.", i)); */

            }
        }

        [Test]
        public void Test_08_ExtendedDatabaseRemoveFunctionInvalidData()
        {
            Database database = new Database(EMPTY_ARRAY);

            Assert.Throws<InvalidOperationException>(
                () => database.Remove(),
                String.Format(
                    "Database array doesn't throw InvalidOperationException when removeing element {0}.",
                    MAX_ARRAY.Length + 1));

        }

        [Test]
        public void Test_09_ExtendedDatabaseFindByIdFunctionValidData()
        {
            Database database = new Database(MAX_ARRAY);

            for (int i = MAX_ARRAY.Length - 1; i >= 0; i--)
            {
                Assert.That(
                    database.FindById(MAX_ARRAY[i].Id).UserName,
                    Is.EqualTo(MAX_ARRAY[i].UserName),
                    String.Format("Element not retreived correctly by ID {0}.", MAX_ARRAY[i].Id));
            }
        }

        [Test]
        public void Test_10_ExtendedDatabaseFindByIdFunctionInvalidData()
        {
            Database database = new Database(MAX_ARRAY);

            Assert.Throws<InvalidOperationException>(
                () => database.FindById(OVERFILL_ARRAY[OVERFILL_ARRAY.Length - 1].Id),
                "Database doesn't throw InvalidOperationException when retreiving non-existing ID.");

            Assert.Throws<ArgumentOutOfRangeException>(
                () => database.FindById(-1),
                "Database doesn't throw ArgumentOutOfRangeException when retreiving negative ID.");

            database = new Database(EMPTY_ARRAY);
            Assert.Throws<InvalidOperationException>(
                () => database.FindById(0),
                "Database doesn't throw ArgumentOutOfRangeException when retreiving negative ID.");

        }

        [Test]
        public void Test_11_ExtendedDatabaseFindByUsernameFunctionValidData()
        {
            Database database = new Database(MAX_ARRAY);

            for (int i = MAX_ARRAY.Length - 1; i >= 0; i--)
            {
                Assert.That(
                    database.FindByUsername(MAX_ARRAY[i].UserName).Id,
                    Is.EqualTo(MAX_ARRAY[i].Id),
                    String.Format("Element not retreived correctly by UserName {0}.", MAX_ARRAY[i].UserName));
            }
        }

        [Test]
        public void Test_12_ExtendedDatabaseFindByUsernameFunctionInvalidData()
        {
            Database database = new Database(MAX_ARRAY);

            Assert.Throws<InvalidOperationException>(
                () => database.FindByUsername(OVERFILL_ARRAY[OVERFILL_ARRAY.Length - 1].UserName),
                "Database doesn't throw InvalidOperationException when retreiving non-existing UserName.");

            Assert.Throws<ArgumentNullException>(
                () => database.FindByUsername(null),
                "Database doesn't throw ArgumentNullException when retreiving null string UserName.");

            Assert.Throws<ArgumentNullException>(
                () => database.FindByUsername(""),
                "Database doesn't throw ArgumentNullException when retreiving empty string UserName.");

            Assert.Throws<InvalidOperationException>(
                () => database.FindByUsername(MAX_ARRAY[0].UserName.ToLower()),
                "Database doesn't throw InvalidOperationException when retreiving non-existing UserName.");

            database = new Database(EMPTY_ARRAY);
            Assert.Throws<InvalidOperationException>(
                () => database.FindByUsername("AAA"),
                "Database doesn't throw InvalidOperationException when retreiving non-existing UserName.");

        }
        
    }
}