namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private const int DEFAULT_MIN_ATTACK_HP = 30;
        private const string DEFAULT_NAME = "Bai Ivan";
        private const int DEFAULT_DAMAGE = 100;
        private const int DEFAULT_HP = 100;

        private Warrior defaultWarrior;

        [SetUp]
        public void Setup()
        {
            defaultWarrior = new Warrior(
                                DEFAULT_NAME,
                                DEFAULT_DAMAGE,
                                DEFAULT_HP
                                );
        }

        [Test]
        public void Test_01_Warrior_Constructor_ValidData()
        {
            Assert.That(
                defaultWarrior.Name,
                Is.EqualTo(DEFAULT_NAME),
                String.Format("Warrior constructor doesn't set Name propertly <{0}>.", defaultWarrior.Name));

            Assert.That(
                defaultWarrior.Damage,
                Is.EqualTo(DEFAULT_DAMAGE),
                String.Format("Warrior constructor doesn't set Damage propertly <{0}>.", defaultWarrior.Damage));

            Assert.That(
                defaultWarrior.HP,
                Is.EqualTo(DEFAULT_HP),
                String.Format("Warrior constructor doesn't set HP propertly <{0}>.", defaultWarrior.HP));

        }

        [Test]
        public void Test_02_Warrior_Constructor_InvalidData()
        {

            Assert.Throws<ArgumentException>(
                () => defaultWarrior = new Warrior(null, DEFAULT_DAMAGE, DEFAULT_HP),
                "Warrior constructor with null Name property doesn't throw.");

            Assert.Throws<ArgumentException>(
                () => defaultWarrior = new Warrior("", DEFAULT_DAMAGE, DEFAULT_HP),
                "Warrior constructor with empty Name property doesn't throw.");

            Assert.Throws<ArgumentException>(
                () => defaultWarrior = new Warrior(DEFAULT_NAME, -1, DEFAULT_HP),
                "Warrior constructor with negative Damage property doesn't throw.");

            Assert.Throws<ArgumentException>(
                () => defaultWarrior = new Warrior(DEFAULT_NAME, 0, DEFAULT_HP),
                "Warrior constructor with zeroe Damage property doesn't throw.");

            Assert.Throws<ArgumentException>(
                () => defaultWarrior = new Warrior(DEFAULT_NAME, DEFAULT_DAMAGE, -1),
                "Warrior constructor with negative HP property doesn't throw.");

        }

        [Test]
        public void Test_03_Warrior_Attack_ValidData1()
        {
            Warrior kungFuWarrior = new Warrior("Hon Gil Don", DEFAULT_DAMAGE, DEFAULT_HP);
            kungFuWarrior.Attack(defaultWarrior);

            Assert.That(
                kungFuWarrior.HP,
                Is.EqualTo(0),
                String.Format("Warrior Attack doesn't set HP propertly <{0}>.", kungFuWarrior.HP));

            Assert.That(
                defaultWarrior.HP,
                Is.EqualTo(0),
                String.Format("Warrior Attack doesn't set HP propertly <{0}>.", defaultWarrior.HP));

        }

        [Test]
        public void Test_04_Warrior_Attack_ValidData2()
        {
            Warrior kungFuWarrior = new Warrior("Hon Gil Don", DEFAULT_DAMAGE + 1, DEFAULT_HP);
            kungFuWarrior.Attack(defaultWarrior);

            Assert.That(
                kungFuWarrior.HP,
                Is.EqualTo(0),
                String.Format("Warrior Attack doesn't set HP propertly <{0}>.", kungFuWarrior.HP));

            Assert.That(
                defaultWarrior.HP,
                Is.EqualTo(0),
                String.Format("Warrior Attack doesn't set HP propertly <{0}>.", defaultWarrior.HP));

        }

        [Test]
        public void Test_05_Warrior_Attack_InvalidData()
        {
            Warrior kungFuWarrior = new Warrior("Hon Gil Don", DEFAULT_DAMAGE + 1, DEFAULT_HP);
            Warrior lowHPWarrior = new Warrior("Bruce Lee", DEFAULT_DAMAGE, DEFAULT_MIN_ATTACK_HP - 1);

            Assert.Throws<InvalidOperationException>(
                () => lowHPWarrior.Attack(defaultWarrior),
                "Warrior Attack with low HP property doesn't throw.");

            Assert.Throws<InvalidOperationException>(
                () => defaultWarrior.Attack(lowHPWarrior),
                "Warrior Attack with low HP property doesn't throw.");

            Assert.Throws<InvalidOperationException>(
                () => defaultWarrior.Attack(kungFuWarrior),
                "Warrior Attack on stronger enemy doesn't throw.");


        }

    }
}