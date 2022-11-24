namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        private const int DEFAULT_MIN_ATTACK_HP = 30;
        private const string DEFAULT_NAME = "Bai Ivan";
        private const int DEFAULT_DAMAGE = 100;
        private const int DEFAULT_HP = 100;

        private Warrior defaultWarrior;
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            defaultWarrior = new Warrior(DEFAULT_NAME, DEFAULT_DAMAGE, DEFAULT_HP);
            arena = new Arena();
        }

        [Test]
        public void Test_01_Arena_Constructor_ValidData()
        {
            Assert.That(
                arena.Warriors,
                !Is.EqualTo(null),
                "Warrior constructor doesn't initialize Warriors collection.");

            Assert.That(
                arena.Count,
                Is.EqualTo(0),
                "Warrior constructor doesn't initialize Warriors collection.");

        }

        [Test]
        public void Test_02_Arena_Enroll_ValidData()
        {
            Warrior kungFuWarrior = new Warrior("Hon Gil Don", DEFAULT_DAMAGE + 1, DEFAULT_HP);
            Warrior lowHPWarrior = new Warrior("Bruce Lee", DEFAULT_DAMAGE, DEFAULT_MIN_ATTACK_HP - 1);

            arena.Enroll(defaultWarrior);
            Assert.That(
                arena.Count,
                Is.EqualTo(1),
                "Arena Warrior Enroll doesn't add Warrior to collection.");

            arena.Enroll(kungFuWarrior);
            arena.Enroll(lowHPWarrior);

            Assert.That(
                arena.Count,
                Is.EqualTo(3),
                "Arena Warrior Enroll doesn't add Warrior to collection.");

            List<Warrior> warriors = new List<Warrior>(arena.Warriors);

            Assert.That(
                warriors[0].Name,
                Is.EqualTo(defaultWarrior.Name),
                "Arena Warrior Enroll doesn't add Warrior to collection at expected index.");

            Assert.That(
                warriors[2].Name,
                Is.EqualTo(lowHPWarrior.Name),
                "Arena Warrior Enroll doesn't add Warrior to collection at expected index.");

        }


        [Test]
        public void Test_03_Arena_Enroll_InvalidData()
        {
            Warrior kungFuWarrior = new Warrior(defaultWarrior.Name, DEFAULT_DAMAGE + 1, DEFAULT_HP - 1);
            Warrior lowHPWarrior = new Warrior("Bruce Lee", DEFAULT_DAMAGE, DEFAULT_MIN_ATTACK_HP - 1);

            arena.Enroll(defaultWarrior);
            arena.Enroll(lowHPWarrior);

            Assert.Throws<InvalidOperationException>(
                () => arena.Enroll(defaultWarrior),
                "Arena existing Warrior Enroll doesn't throw.");

            Assert.Throws<InvalidOperationException>(
                () => arena.Enroll(kungFuWarrior),
                "Arena existing Warrior Enroll doesn't throw.");

        }

        [Test]
        public void Test_04_Arena_Fight_ValidData()
        {
            Warrior kungFuWarrior = new Warrior("Hon Gil Don", DEFAULT_DAMAGE + 1, DEFAULT_HP);
            Warrior lowHPWarrior = new Warrior("Bruce Lee", DEFAULT_DAMAGE, DEFAULT_HP);

            arena.Enroll(defaultWarrior);
            arena.Enroll(kungFuWarrior);
            arena.Enroll(lowHPWarrior);

            arena.Fight(kungFuWarrior.Name, defaultWarrior.Name);

            Assert.That(
                kungFuWarrior.HP,
                Is.EqualTo(0),
                String.Format("Arena Fight doesn't set HP propertly <{0}>.", kungFuWarrior.HP));

            Assert.That(
                defaultWarrior.HP,
                Is.EqualTo(0),
                String.Format("Arena Fight doesn't set HP propertly <{0}>.", defaultWarrior.HP));


        }

        [Test]
        public void Test_05_Arena_Fight_InvalidData()
        {
            Warrior kungFuWarrior = new Warrior("Hon Gil Don", DEFAULT_DAMAGE + 1, DEFAULT_HP);
            Warrior lowHPWarrior = new Warrior("Bruce Lee", DEFAULT_DAMAGE, DEFAULT_HP);
            Warrior theBestWarrior = new Warrior("Chuck Norris", DEFAULT_DAMAGE, DEFAULT_HP);

            arena.Enroll(defaultWarrior);
            arena.Enroll(kungFuWarrior);
            arena.Enroll(lowHPWarrior);

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight(defaultWarrior.Name, theBestWarrior.Name),
                "Arena fight with non-enrolled warrior doesn't throw.");

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight(theBestWarrior.Name, defaultWarrior.Name),
                "Arena fight with non-enrolled warrior doesn't throw.");

        }

    }
}
