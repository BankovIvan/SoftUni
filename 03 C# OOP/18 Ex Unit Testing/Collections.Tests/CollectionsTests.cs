namespace Collections.Tests
{
    using NUnit.Framework;
    using System;

    //using Collections;

    public class CollectionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_01_CircuralQueue_ConstructorDefault()
        {
            CircularQueue<int> queue = new CircularQueue<int>();
            Assert.That(
                queue.ToString(),
                Is.EqualTo("[]"),
                "Queue default constructor fault <ToString>.");
            Assert.That(
                queue.Count,
                Is.EqualTo(0),
                "Queue default constructor fault <Count>.");
            Assert.That(
                queue.Capacity,
                Is.AtLeast(1),
                "Queue default constructor fault <Capacity>.");
            Assert.That(
                queue.StartIndex,
                Is.EqualTo(0),
                "Queue default constructor fault <StartIndex>.");
            Assert.That(
                queue.EndIndex,
                Is.EqualTo(0),
                "Queue default constructor fault <EndIndex>.");
        }

        [Test]
        public void Test_02_CircuralQueue_ConstructorWithCapacity()
        {
            CircularQueue<int> queue = new CircularQueue<int>(10);
            Assert.That(
                queue.ToString(),
                Is.EqualTo("[]"),
                "Queue constructor (10) fault <ToString>.");
            Assert.That(
                queue.Count,
                Is.EqualTo(0),
                "Queue constructor (10) fault <Count>.");
            Assert.That(
                queue.Capacity,
                Is.AtLeast(10),
                "Queue constructor (10) fault <Capacity>.");
            Assert.That(
                queue.StartIndex,
                Is.EqualTo(0),
                "Queue constructor (10) fault <StartIndex>.");
            Assert.That(
                queue.EndIndex,
                Is.EqualTo(0),
                "Queue constructor (10) fault <EndIndex>.");
        }

        [Test]
        public void Test_03_CircuralQueue_Enqueue()
        {
            CircularQueue<int> queue = new CircularQueue<int>();

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Assert.That(
                queue.ToString(),
                Is.EqualTo("[10, 20, 30]"),
                "Queue Enqueue fault <ToString>.");
            Assert.That(
                queue.Count,
                Is.EqualTo(3),
                "Queue Enqueue fault <Count>.");
            Assert.That(
                queue.Capacity,
                Is.AtLeast(queue.Count),
                "Queue Enqueue fault <Capacity>.");

        }

        [Test]
        public void Test_04_CircuralQueue_EnqueueWithGrouth()
        {
            CircularQueue<int> queue = new CircularQueue<int>(10);

            for (int i = 10; i <= 100; i += 10)
            {
                queue.Enqueue(i);
            }

            queue.Enqueue(110);
            queue.Enqueue(120);

            Assert.That(
                queue.ToString(),
                Is.EqualTo("[10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120]"),
                "Queue Enqueue wit grouth fault <ToString>.");
            Assert.That(
                queue.Count,
                Is.EqualTo(12),
                "Queue Enqueue wit grouth fault <Count>.");
            Assert.That(
                queue.Capacity,
                Is.AtLeast(queue.Count),
                "Queue Enqueue wit grouth fault <Capacity>.");

        }

        [Test]
        public void Test_05_CircuralQueue_Dequeue()
        {
            CircularQueue<int> queue = new CircularQueue<int>(10);

            Assert.Throws<InvalidOperationException>(
                () => queue.Dequeue(),
                "Empty queue Enqueue wit grouth fault."
                );

            for (int i = 10; i <= 100; i += 10)
            {
                queue.Enqueue(i);
            }

            queue.Enqueue(110);
            queue.Enqueue(120);

            Assert.That(
                queue.Dequeue(),
                Is.EqualTo(10),
                "Queue Dequeue wit grouth fault <Dequeue>.");
            Assert.That(
                queue.Count,
                Is.EqualTo(11),
                "Queue Dequeue wit grouth fault <Count>.");
            Assert.That(
                queue.Capacity,
                Is.AtLeast(queue.Count),
                "Queue Dequeue wit grouth fault <Capacity>.");

            queue.Dequeue(); // 20
            queue.Dequeue(); // 30

            Assert.That(
                queue.Dequeue(),
                Is.EqualTo(40),
                "Queue Dequeue wit grouth fault <Dequeue>.");
            Assert.That(
                queue.Count,
                Is.EqualTo(8),
                "Queue Dequeue wit grouth fault <Count>.");
            Assert.That(
                queue.Capacity,
                Is.AtLeast(queue.Count),
                "Queue Dequeue wit grouth fault <Capacity>.");

            queue.Dequeue(); // 50
            queue.Dequeue(); // 60
            queue.Dequeue(); // 70
            queue.Dequeue(); // 80
            queue.Dequeue(); // 90
            queue.Dequeue(); // 100
            queue.Dequeue(); // 110

            Assert.That(
                queue.Dequeue(),
                Is.EqualTo(120),
                "Queue Dequeue wit grouth fault <Dequeue>.");
            Assert.That(
                queue.Count,
                Is.EqualTo(0),
                "Queue Dequeue wit grouth fault <Count>.");
            Assert.That(
                queue.Capacity,
                Is.AtLeast(queue.Count),
                "Queue Dequeue wit grouth fault <Capacity>.");
            Assert.That(
                queue.ToString(),
                Is.AtLeast("[]"),
                "Queue Dequeue wit grouth fault <ToString>.");
        }

        [Test]
        public void Test_06_CircuralQueue_Peek()
        {
            CircularQueue<int> queue = new CircularQueue<int>(10);

            Assert.Throws<InvalidOperationException>(
                () => queue.Peek(),
                "Empty Queue Peek wit grouth fault."
                );

            for (int i = 10; i <= 120; i += 10)
            {
                queue.Enqueue(i);
            }

            for (int i = 10; i <= 120; i += 10)
            {
                Assert.That(
                    queue.Peek(),
                    Is.EqualTo(i),
                    "Queue Peek wit grouth fault.");

                queue.Dequeue();
            }

        }

        [Test]
        public void Test_07_CircuralQueue_ToArray()
        {
            CircularQueue<int> queue = new CircularQueue<int>(10);

            Assert.That(
                queue.ToArray().Length,
                Is.EqualTo(0),
                "Empty Queue ToArray fault.");

            for (int i = 10; i <= 120; i += 10)
            {
                queue.Enqueue(i);
            }

            var arrayQueye = queue.ToArray();
            int[] arrayTest = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120 };

            CollectionAssert.AreEqual(
                arrayQueye,
                arrayTest,
                "Queue ToArray fault."
                );
        }

        [Test]
        public void Test_08_CircuralQueue_ToString()
        {
            CircularQueue<int> queue = new CircularQueue<int>(10);

            Assert.That(
                queue.ToString(),
                Is.EqualTo("[]"),
                "Empty Queue ToString fault.");

            for (int i = 10; i <= 120; i += 10)
            {
                queue.Enqueue(i);
            }

            Assert.That(
                queue.ToString(),
                Is.EqualTo("[10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120]"),
                "Queue ToString fault.");

        }
    }
}
