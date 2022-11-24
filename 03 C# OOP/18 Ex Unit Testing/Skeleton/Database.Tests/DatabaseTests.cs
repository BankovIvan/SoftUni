namespace Database.Tests
{
    using NUnit.Framework;
    using System.Reflection;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private readonly int[] EMPTY_ARRAY = new int[] { };
        private readonly int[] MIN_ARRAY = new int[] { 1 };
        private readonly int[] MAX_ARRAY = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private readonly int[] OVERFILL_ARRAY = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test_01_DatabaseConstructorValidData()
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
        public void Test_02_DatabaseConstructorInvalidData()
        {
            Database database;

            Exception ex = Assert.Throws<InvalidOperationException>(
                () => database = new Database(OVERFILL_ARRAY),
                String.Format(
                    "Database constructor with {0} elements doesn't throw InvalidOperationException.",
                    OVERFILL_ARRAY.Length));

        }

        [Test]
        public void Test_03_DatabaseStoringArrayLengthValid()
        {
            Database database = new Database(EMPTY_ARRAY);
            for(int i = 0; i < MAX_ARRAY.Length; i++)
            {
                database.Add(i);
            }

            Assert.That(
                database.Count,
                Is.EqualTo(MAX_ARRAY.Length),
                String.Format("Database array doesn't have exactly {0} elements.", MAX_ARRAY.Length));

            //Exception ex = Assert.Throws<InvalidOperationException>(() => database.Add(MAX_ARRAY.Length + 1));

        }

        [Test]
        public void Test_04_DatabaseStoringArrayLengthInvalid()
        {
            Database database = new Database(MAX_ARRAY);

            Exception ex = Assert.Throws<InvalidOperationException>(
                () => database.Add(MAX_ARRAY.Length + 1),
                String.Format(
                    "Database array doesn't throw InvalidOperationException when adding element {0}.", 
                    MAX_ARRAY.Length + 1));

        }

        [Test]
        public void Test_05_DatabaseAddFunctionValidData()
        {
            Database database = new Database(EMPTY_ARRAY);
            for (int i = 0; i < MAX_ARRAY.Length; i++)
            {
                database.Add(MAX_ARRAY[i]);
            }

            int[] ints = database.Fetch();

            CollectionAssert.AreEqual(MAX_ARRAY, ints, "Element not set correctly in the database");

        }

        [Test]
        public void Test_06_DatabaseAddFunctionInvalidData()
        {
            Database database = new Database(MAX_ARRAY);

            Exception ex = Assert.Throws<InvalidOperationException>(
                () => database.Add(MAX_ARRAY.Length + 1),
                String.Format(
                    "Database array doesn't throw InvalidOperationException when adding element {0}.",
                    MAX_ARRAY.Length + 1));

        }

        [Test]
        public void Test_07_DatabaseRemoveFunctionValidData()
        {
            Database database = new Database(MAX_ARRAY);

            for (int i = MAX_ARRAY.Length - 1; i >= 0; i--)
            {
                database.Remove();

                Assert.That(
                    database.Count,
                    Is.EqualTo(i),
                    String.Format("Element not removed correctly at index {0}.", i));

                int[] fetch = database.Fetch();
                for(int j = 0; j < i; j++)
                {
                    Assert.That(
                        fetch[j],
                        Is.EqualTo(MAX_ARRAY[j]),
                        String.Format("Element not removed correctly at index {0}.", j));
                }
            }
        }

        [Test]
        public void Test_08_DatabaseRemoveFunctionInvalidData()
        {
            Database database = new Database(EMPTY_ARRAY);

            Exception ex = Assert.Throws<InvalidOperationException>(
                () => database.Remove(),
                String.Format(
                    "Database array doesn't throw InvalidOperationException when removeing element {0}.",
                    MAX_ARRAY.Length + 1));

        }

        [Test]
        public void Test_09_DatabaseFetchFunctionValidData()
        {
            Database database = new Database(MAX_ARRAY);
            int[] fetch = database.Fetch();

            CollectionAssert.AreEqual(MAX_ARRAY, fetch, "Element not fetched correctly from the database");

            database = new Database(MIN_ARRAY);
            fetch = database.Fetch();

            CollectionAssert.AreEqual(MIN_ARRAY, fetch, "Element not fetched correctly from the database");

        }

        [Test]
        public void Test_10_DatabaseFetchFunctionInvalidData()
        {
            Database database = new Database(EMPTY_ARRAY);
            int[] fetch = database.Fetch();

            Assert.That(
                fetch.Count,
                Is.EqualTo(0),
                "Elements not fetched correctly from empty database.");

        }

    }
}
