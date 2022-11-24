using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;

        private const int AXE_ATTACK_DEFAULT = 10;
        private const int AXE_DURABILITY_DEFAULT = 10;
        private const int DUMMY_HEALTH_DEFAULT = 10;
        private const int DUMMY_EXPERIENCE_DEFAULT = 10;

        private const string EXCEPTION_MSG_DEAD = "Dummy is dead.";
        private const string EXCEPTION_MSG_ALIVE = "Target is not dead.";

        [SetUp]
        public void Setup()
        {
            axe = new Axe(AXE_ATTACK_DEFAULT, AXE_DURABILITY_DEFAULT);
            dummy = new Dummy(DUMMY_HEALTH_DEFAULT, DUMMY_EXPERIENCE_DEFAULT);

            //axe.Attack(dummy);
        }

        [Test]
        public void Test_DummyConstructor()
        {
            Assert.That(
                dummy.Health,
                Is.EqualTo(DUMMY_HEALTH_DEFAULT),
                "Dummy Health not set correctly by constructor.");

            ///
            /// Cannot test experience directly.
            ///
        }

        [Test]
        public void Test_DummyLosesHealthIfAttacked()
        {
            axe.Attack(dummy);

            Assert.That(
                dummy.Health, 
                Is.EqualTo(DUMMY_HEALTH_DEFAULT - AXE_ATTACK_DEFAULT), 
                "Dummy doesn't loose expected ammount of points.");
        }

        [Test]
        public void Test_DeadDummyThrowsExceptionIfAttacked()
        {
            axe.Attack(dummy);

            Exception ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
            Assert.That(
                ex.Message, 
                Is.EqualTo(EXCEPTION_MSG_DEAD), 
                "Dummy doesn't loose expected ammount of points.");

            //InvalidOperationException("Dummy is dead.")

        }

        [Test]
        public void Test_DeadDummyCanGiveXP()
        {
            axe.Attack(dummy);

            //Assert.That(dummy.IsDead(), Is.EqualTo(true), "Dead Dummy doesn't give XP");
            Assert.That(
                dummy.GiveExperience(), 
                Is.EqualTo(DUMMY_HEALTH_DEFAULT), 
                "Dead Dummy doesn't give XP");
        }

        [Test]
        public void Test_AliveDummyCantGiveXP()
        {
            dummy = new Dummy(DUMMY_HEALTH_DEFAULT, DUMMY_EXPERIENCE_DEFAULT);

            //Assert.That(dummy.IsDead(), Is.EqualTo(false), "Alive Dummy can't give XP");
            Exception ex = Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
            Assert.That(
                ex.Message, 
                Is.EqualTo(EXCEPTION_MSG_ALIVE), 
                "Alive Dummy can't give XP");
        }

    }
}